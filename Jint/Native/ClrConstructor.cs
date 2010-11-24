using System;
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

        LinkedList<NativeDescriptor> m_properties = new LinkedList<NativeDescriptor>();
        ConstructorInfo[] m_constructors;
        Marshaller m_marshaller;
        NativeOverloadImpl<ConstructorInfo, ConstructorImpl> m_overloads;

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
            Name = type.FullName;

            if (!type.IsAbstract)
            {
                m_constructors = type.GetConstructors();
            }

            m_overloads = new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>(
                m_marshaller,
                new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>.GetMembersDelegate(this.GetMembers),
                new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>.WrapMmemberDelegate(this.WrapMember)
            );

            if (type.IsValueType)
            {
                m_overloads.DefineCustomOverload(
                    new Type[0],
                    new Type[0],
                    (ConstructorImpl)Delegate.CreateDelegate(
                        typeof(ConstructorImpl),
                        typeof(ClrConstructor).GetMethod("CreateStruct", BindingFlags.NonPublic | BindingFlags.Static ).MakeGenericMethod(type)
                    )
                );
            }

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
                DefineOwnProperty(
                    pair.Key,
                    (
                    pair.Value.Count > 1 ?
                        (JsFunction)new NativeMethodOverload(pair.Value, Global.FunctionClass.PrototypeProperty, Global) :
                        (JsFunction)new NativeMethod(pair.Value.First.Value, Global.FunctionClass.PrototypeProperty, Global)
                    ),
                    PropertyAttributes.DontEnum
                );
            }

            // find and add all static properties and fields
            foreach (var info in type.GetProperties(BindingFlags.Static | BindingFlags.Public))
                DefineOwnProperty(info.Name, Global.Marshaller.MarshalPropertyInfo(info, this));
            

            foreach (var info in type.GetFields(BindingFlags.Static | BindingFlags.Public))
                DefineOwnProperty(info.Name, Global.Marshaller.MarshalFieldInfo(info, this));

            // find all nested types
            foreach (var info in type.GetNestedTypes(BindingFlags.Public))
                DefineOwnProperty(info.Name,Global.Marshaller.MarshalClrValue(info),PropertyAttributes.DontEnum);

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
                    (JsFunction)new NativeMethodOverload(pair.Value, Global.FunctionClass.PrototypeProperty, Global) :
                    (JsFunction)new NativeMethod(pair.Value.First.Value, Global.FunctionClass.PrototypeProperty, Global);
            }

            proto["toString"] = new NativeMethod(reflectedType.GetMethod("ToString",new Type[0]), Global.FunctionClass.PrototypeProperty, Global);
        }

        static object CreateStruct<T>(IGlobal global,JsInstance[] args) where T : struct
        {
            return new T();
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            if (that == null || that == JsUndefined.Instance || that == JsNull.Instance)
                throw new JintException("A constructor '" + reflectedType.FullName + "' should be applied to the object");

            if (that.Value != null)
                throw new JintException("Can't apply the constructor '" + reflectedType.FullName + "' to already initialized '" + that.Value.ToString() + "'");

            ConstructorImpl impl = m_overloads.ResolveOverload(parameters, null);
            if (impl == null)
                throw new JintException(
                    String.Format("No matching overload found {0}({1})",
                        reflectedType.FullName,
                        String.Join(",",Array.ConvertAll<JsInstance,string>(parameters, p => p.ToString()))
                    )
                );

            that.Value = impl(visitor.Global, parameters);
            
            SetupNativeProperties(that);
            return that;
        }

        public void SetupNativeProperties(JsDictionaryObject target)
        {
            if (target == null || target == JsNull.Instance || target == JsUndefined.Instance )
                throw new ArgumentException("A valid js object is required","target");
            foreach (var prop in m_properties)
                target.DefineOwnProperty(prop.Name,new NativeDescriptor(target, prop) );
        }

        public override JsInstance Wrap<T>(T value)
        {
            if (!reflectedType.IsAssignableFrom(typeof(T)))
                throw new JintException("Attempt to wrap '" + typeof(T).FullName + "' with '" + reflectedType.FullName+ "'");
            JsObject inst = Global.ObjectClass.New(PrototypeProperty);
            inst.Value = value;
            SetupNativeProperties(inst);

            return inst;
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
