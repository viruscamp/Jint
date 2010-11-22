﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Jint.Marshal;

namespace Jint.Native
{
    /// <summary>
    /// A constructor function that reflects a native clr type to the js runtime.
    /// </summary>
    /// <remarks>
    /// <pre>
    /// When applied to the object, it fills a special slot with new clr object and defines
    /// new properties according to the netive fields and properties.
    /// </pre>
    /// <pre>
    /// Instance methods are derived through prototype.
    /// </pre>
    /// <pre>
    /// Static methods, properties and fields are defined as properties of the constructor.
    /// </pre>
    /// <pre>Generics? hm...</pre>
    /// </remarks>
    public class ClrConstructor: JsConstructor
    {
        Type reflectedType;

        LinkedList<Descriptor> m_properties = new LinkedList<Descriptor>();
        ConstructorInfo[] m_constructors;
        Marshaller m_marshaller;
        ClrOverloadBase<ConstructorInfo, ConstructorImpl> m_overloads;

        public ClrConstructor(Type type, IGlobal global) :
            this(type, global, null)
        {
        }

        public ClrConstructor(Type type, IGlobal global, JsObject PrototypePrototype) :
            base(global)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            m_marshaller = global.Marshaller;

            reflectedType = type;

            if (!type.IsAbstract)
            {
                m_constructors = type.GetConstructors();
            }

            m_overloads = new ClrOverloadBase<ConstructorInfo, ConstructorImpl>(
                m_marshaller,
                new ClrOverloadBase<ConstructorInfo, ConstructorImpl>.GetMembersDelegate(this.GetMembers),
                new ClrOverloadBase<ConstructorInfo, ConstructorImpl>.WrapMmemberDelegate(this.WrapMember)
            );

            // now we should find all static members and add them as a properties

            Dictionary< string, LinkedList<MethodInfo> > members = new Dictionary<string,LinkedList<MethodInfo>>();

            foreach (var info in type.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (!members.ContainsKey(info.Name))
                    members[info.Name] = new LinkedList<MethodInfo>();
                members[info.Name].AddLast(info);
            }

            foreach (var pair in members)
            {
                this[pair.Key] = pair.Value.Count > 1 ?
                    (JsFunction)new ClrOverload(pair.Value, Global.FunctionClass.PrototypeProperty, Global) :
                    (JsFunction)new NativeMethod(pair.Value.First.Value, Global.FunctionClass.PrototypeProperty, Global);
            }

            // find and add all static properties and fields
            foreach (var info in type.GetProperties(BindingFlags.Static | BindingFlags.Public))
                DefineOwnProperty(info.Name, Global.Marshaller.MarshalPropertyInfo(info, this));
            

            foreach (var info in type.GetFields(BindingFlags.Static | BindingFlags.Public))
                DefineOwnProperty(info.Name, Global.Marshaller.MarshalFieldInfo(info, this));

            // find all nested types
            foreach (var info in type.GetNestedTypes(BindingFlags.Public))
                this[info.Name] = Global.Marshaller.MarshalClrValue(info);

            // find all instance properties and fields
            foreach (var info in type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                ParameterInfo[] indexerParams = info.GetIndexParameters();
                if (indexerParams == null || indexerParams.Length == 0)
                    m_properties.AddLast(global.Marshaller.MarshalPropertyInfo(info, this));
                //TODO: Add indexers support
            }

            foreach (var info in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public) )
                m_properties.AddLast(global.Marshaller.MarshalFieldInfo(info,this));

            DefineOwnProperty(PROTOTYPE, PrototypePrototype == null ? Global.ObjectClass.New(this) : Global.ObjectClass.New(this,PrototypePrototype), PropertyAttributes.DontEnum | PropertyAttributes.DontDelete | PropertyAttributes.ReadOnly);

        }

        public override object Value
        {
            get
            {
                return reflectedType;
            }
            set
            {
                ;
            }
        }

        public override void InitPrototype(IGlobal global)
        {
            var proto = PrototypeProperty;

            Dictionary<string, LinkedList<MethodInfo>> members = new Dictionary<string, LinkedList<MethodInfo>>();

            foreach (var info in reflectedType.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                if (! members.ContainsKey(info.Name))
                    members[info.Name] = new LinkedList<MethodInfo>();
                members[info.Name].AddLast(info);
            }

            foreach (var pair in members)
            {
                proto[pair.Key] = pair.Value.Count > 1 ?
                    (JsFunction)new ClrOverload(pair.Value, Global.FunctionClass.PrototypeProperty, Global) :
                    (JsFunction)new NativeMethod(pair.Value.First.Value, Global.FunctionClass.PrototypeProperty, Global);
            }
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            if (that == null || that == JsUndefined.Instance || that == JsNull.Instance)
                throw new JintException("A constructor '" + reflectedType.FullName + "' should be applied to the object");

            ConstructorImpl impl = m_overloads.ResolveOverload(parameters, null);
            if (impl == null)
                throw new JintException("No matching overload found");
            that.Value = impl(visitor.Global, parameters);
            return that;
        }

        protected ConstructorImpl WrapMember(ConstructorInfo info)
        {
            return m_marshaller.WrapConstructor(info,true);
        }

        protected IEnumerable<ConstructorInfo> GetMembers(Type[] genericArguments, int argCount)
        {
            return Array.FindAll(m_constructors, con => con.GetParameters().Length == argCount);
        }
    }
}
