using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Jint.Marshal;

namespace Jint.Native
{

    public class ClrTypePrototype : JsObject
    {
        public Type WrapType { get { return NativeConstructor.ReflectedType; } }
        public NativeConstructor NativeConstructor { get; private set; }

        internal ClrTypePrototype(NativeConstructor constructor, JsObject prototype)
            : base(prototype)
        {
            NativeConstructor = constructor;
            DefineOwnProperty(new ValueDescriptor(this, JsFunction.CONSTRUCTOR, constructor) { Enumerable = false });
        }

        public override string ToString()
        {
            return this.GetType().Name + " : " + WrapType.ToString();
        }
    }

    /// <summary>
    /// A constructor function that reflects a native clr type to the js runtime.
    /// </summary>
    /// <remarks>
    /// This class doesn't used to wrap open generics, since open generics can't be
    /// used to create instances they are not considered as functions (constructors).
    /// </remarks>
    public class NativeConstructor: JsConstructor
    {
        Type reflectedType;

        public Type ReflectedType { get { return reflectedType; } }

        public Type WrapType { get { return reflectedType.GetType(); } }

        LinkedList<NativeDescriptor> m_properties = new LinkedList<NativeDescriptor>();
        INativeIndexer m_indexer;

        ConstructorInfo[] m_constructors;
        Marshaller m_marshaller;
        NativeOverloadImpl<ConstructorInfo, ConstructorImpl> m_overloads;

        // TODO: native constructors should have an own prototype rather then the function prototype
        public NativeConstructor(Type type, IGlobal global) :
            this(type, global, null,global.FunctionClass.PrototypeProperty)
        {
        }

        public NativeConstructor(Type type, IGlobal global, JsObject PrototypePrototype) :
            this(type, global, PrototypePrototype, global.FunctionClass.PrototypeProperty)
        {
        }

        public NativeConstructor(Type type, IGlobal global, JsObject prototypePrototype, JsObject prototype) :
            base(global,prototype)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (type.IsGenericType && type.ContainsGenericParameters)
                throw new InvalidOperationException("A native constructor can't be built against an open generic");

            m_marshaller = global.Marshaller;

            reflectedType = type;
            Name = type.FullName;

            if (!type.IsAbstract && !type.IsInterface)
            {
                m_constructors = type.GetConstructors();
            }
            
            // wrap CLR interface method 1: links of prototypes
            // assume that i1 is I1, the actual type is C1, C1.IsVisible = false
            // 包装 CLR 接口方法1: 原型链
            // 假设 i1 实现 I1 接口，实际类型为 C1, C1对外不可见, C1.IsVisible = false

            // the links of prototypes after the patch
            // 更改后原型链如下
            // jsclrobject(value=i1) --> jsobject(hold I1 methods) --> jsobject(hold clr object methods)
            // --> jsobject(hold js object methods) --> jsnull --> null

            // the links of prototypes before the patch
            // 更改前原型链
            // jsclrobject(value=i1) --> jsobject(hold C1 methods)
            // --> jsobject(hold js object methods) --> jsnull --> null
            if (type.IsInterface)
            {
                var objctor = Global.Marshaller.MarshalType(typeof(object));
                prototypePrototype = objctor.PrototypeProperty;
            }
            if (prototypePrototype == null)
            {
                prototypePrototype = Global.ObjectClass.PrototypeProperty;
            }
            var clrTypePrototype = new ClrTypePrototype(this, prototypePrototype);
            DefineOwnProperty(PROTOTYPE, clrTypePrototype, 
                PropertyAttributes.DontEnum | PropertyAttributes.DontDelete | PropertyAttributes.ReadOnly);

            m_overloads = new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>(
                m_marshaller,
                new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>.GetMembersDelegate(this.GetMembers),
                new NativeOverloadImpl<ConstructorInfo, ConstructorImpl>.WrapMmemberDelegate(this.WrapMember)
            );

            // if this is a value type, define a default constructor
            if (type.IsValueType)
            {
                m_overloads.DefineCustomOverload(
                    new Type[0],
                    new Type[0],
                    (ConstructorImpl)Delegate.CreateDelegate(
                        typeof(ConstructorImpl),
                        typeof(NativeConstructor).GetMethod("CreateStruct", BindingFlags.NonPublic | BindingFlags.Static ).MakeGenericMethod(type)
                    )
                );
            }

            // now we should find all static members and add them as a properties

            // members are grouped by their names
            Dictionary< string, LinkedList<MethodInfo> > members = new Dictionary<string,LinkedList<MethodInfo>>();

            foreach (var info in type.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (info.ReturnType.IsByRef)
                    continue;
                if (!members.ContainsKey(info.Name))
                    members[info.Name] = new LinkedList<MethodInfo>();
                
                members[info.Name].AddLast(info);
            }

            // add the members to the object
            foreach (var pair in members)
                DefineOwnProperty( pair.Key, ReflectOverload(pair.Value) );

            // find and add all static properties and fields
            foreach (var info in type.GetProperties(BindingFlags.Static | BindingFlags.Public))
                DefineOwnProperty(Global.Marshaller.MarshalPropertyInfo(info, this));
            
            foreach (var info in type.GetFields(BindingFlags.Static | BindingFlags.Public))
                DefineOwnProperty(Global.Marshaller.MarshalFieldInfo(info, this));

            if (type.IsEnum)
            {
                string[] names = Enum.GetNames(type);
                object[] values = new object[names.Length];
                Enum.GetValues(type).CopyTo(values,0);

                for (int i = 0; i < names.Length; i++)
                    DefineOwnProperty(names[i], Global.ObjectClass.New(values[i], PrototypeProperty));
                
            }

            // find all nested types
            foreach (var info in type.GetNestedTypes(BindingFlags.Public))
                DefineOwnProperty(info.Name,Global.Marshaller.MarshalClrValue(info),PropertyAttributes.DontEnum);

            // find all instance properties and fields
            LinkedList<MethodInfo> getMethods = new LinkedList<MethodInfo>();
            LinkedList<MethodInfo> setMethods = new LinkedList<MethodInfo>();
            foreach (var info in type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                ParameterInfo[] indexerParams = info.GetIndexParameters();
                if (indexerParams == null || indexerParams.Length == 0)
                    m_properties.AddLast(global.Marshaller.MarshalPropertyInfo(info, this));
                else if (info.Name == "Item" && indexerParams.Length == 1)
                {
                    if (info.CanRead)
                        getMethods.AddLast(info.GetGetMethod());
                    if (info.CanWrite)
                        setMethods.AddLast(info.GetSetMethod());
                }
            }

            if (getMethods.Count > 0 || setMethods.Count > 0)
            {
                MethodInfo[] getters = new MethodInfo[getMethods.Count];
                getMethods.CopyTo(getters,0);
                MethodInfo[] setters = new MethodInfo[setMethods.Count];
                setMethods.CopyTo(setters, 0);

                m_indexer = new NativeIndexer(m_marshaller, getters, setters);
            }

            if (reflectedType.IsArray)
            {
                m_indexer = (INativeIndexer)typeof(NativeArrayIndexer<>)
                    .MakeGenericType(reflectedType.GetElementType())
                    .GetConstructor(new Type[]{typeof(Marshaller)})
                    .Invoke(new object[]{m_marshaller});
            }

            foreach (var info in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public) )
                m_properties.AddLast(global.Marshaller.MarshalFieldInfo(info,this));

        }

        JsFunction ReflectOverload(ICollection<MethodInfo> methods)
        {
            if (methods.Count == 0)
                throw new ArgumentException("At least one method is required", "methods");

            if (methods.Count == 1)
            {
                foreach (MethodInfo info in methods)
                    if (info.ContainsGenericParameters)
                        return new NativeMethodOverload(methods, Global.FunctionClass.PrototypeProperty, Global);
                    else
                        return new NativeMethod(info, Global.FunctionClass.PrototypeProperty, Global);
            }
            else
            {
                return new NativeMethodOverload(methods, Global.FunctionClass.PrototypeProperty, Global);
            }
            // we should never come here
            throw new ApplicationException("Unexpected error");
        }

        public override bool IsClr {
            get {
                return true;
            }
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
                if (info.ReturnType.IsByRef)
                    continue;

                if (! members.ContainsKey(info.Name))
                    members[info.Name] = new LinkedList<MethodInfo>();
                
                members[info.Name].AddLast(info);
            }

            foreach (var pair in members)
                proto[pair.Key] = ReflectOverload(pair.Value);

            /*
            // wrap CLR interface method 2: add methods of CLR Object to Interface Prototype
            // 包装 CLR 接口方法2: 人工把 CLR Object 的方法加到接口原型
            if (reflectedType.IsInterface)
            {
                Type objtype = typeof(object);
                var toString = new NativeMethod(objtype.GetMethod("ToString", new Type[0]), Global.FunctionClass.PrototypeProperty, Global);
                proto["toString"] = toString;
                proto["ToString"] = toString;
                proto["Equals"] = new NativeMethod(objtype.GetMethod("Equals", new Type[]{objtype}), Global.FunctionClass.PrototypeProperty, Global);
                proto["GetHashCode"] = new NativeMethod(objtype.GetMethod("GetHashCode", new Type[0]), Global.FunctionClass.PrototypeProperty, Global);
                proto["GetType"] = new NativeMethod(objtype.GetMethod("GetType", new Type[0]), Global.FunctionClass.PrototypeProperty, Global);
            }
            else
            {
                proto["toString"] = new NativeMethod(reflectedType.GetMethod("ToString", new Type[0]), Global.FunctionClass.PrototypeProperty, Global);
            }
            */

            // wrap CLR interface method 1, continued
            // overwrite toString of jsobject(hold js object methods)
            // 包装 CLR 接口方法 1 续
            // 覆盖 js object 的 toString 方法
            if (!reflectedType.IsInterface)
            {
                proto["toString"] = new NativeMethod(reflectedType.GetMethod("ToString", new Type[0]), Global.FunctionClass.PrototypeProperty, Global);
                proto["castTo"] = new NativeMethod(new JsMethodImpl(CastTo), Global.FunctionClass.PrototypeProperty);
                proto["getWrapType"] = new NativeMethod(new JsMethodImpl(GetWrapType), Global.FunctionClass.PrototypeProperty);
            }
        }

        public static JsInstance CastTo(IGlobal global, JsInstance that, JsInstance[] args)
        {
            if (that == null)
            {
                return null;
            }
            if (!that.IsClr)
            {
                throw new JintException("cannot perform castTo on non Clr object");
            }
            var obj = that.Value;
            var t = obj.GetType();
            Type castToType = null;
            if (args == null || args.Length == 0)
            {
                castToType = t;
            }
            else
            {
                var typearg = args[0];
                if (typearg.Value is Type)
                {
                    castToType = typearg.Value as Type;
                }
                else if (typearg.Value is string)
                {
                    var typestr = typearg.Value as string;
                    castToType = GetParentType(t, typestr);
                    if (castToType == null)
                    {
                        throw new JintException(string.Format("Cannot cast '{0}' to '{1}'", t.FullName, typestr));
                    }
                }
            }
            if (castToType == null)
            {
                throw new JintException("First argument must be a System.Type or a valid type string");
            }
            var typector = global.Marshaller.MarshalType(castToType);
            return typector.Wrap(obj);
        }

        public static Type GetParentType(Type t, string typestr)
        {
            var ti = t.GetInterface(typestr);
            if (ti != null)
            {
                return ti;
            }
            var tb = t.BaseType;
            while (tb != null)
            {
                if (tb.FullName == typestr)
                {
                    return tb;
                }
                tb = tb.BaseType;
            }
            return null;
        }

        public static JsInstance GetWrapType(IGlobal global, JsInstance that, JsInstance[] args)
        {
            if (that == null)
            {
                throw new ArgumentNullException("that");
            }
            if (that.IsClr)
            {
                if (that is NativeConstructor)
                {
                    // BUG cannot castTo("System.Type") from System.RuntimeType
                    var ctor = that as NativeConstructor;
                    var type = ctor.reflectedType.GetType();
                    return global.Marshaller.MarshalType(type);
                }
                /*
                if (that is ClrImplDefinition<>)
                {
                    // TODO howto check and howto cast for clr delegate
                }
                */
                if (that is JsObject)
                {
                    var jsobj = that as JsObject;
                    var clrTypePrototype = jsobj.Prototype as ClrTypePrototype;
                    return clrTypePrototype.NativeConstructor;
                }
            }
            throw new JintException("Cannot perform getWrapType on non Clr object");
        }

        /// <summary>
        /// A helper which conforms a ConstrutorImpl signature and used as a default constructor for the value types
        /// </summary>
        /// <typeparam name="T">A value type</typeparam>
        /// <param name="global">global object</param>
        /// <param name="args">Constructor args, ignored</param>
        /// <returns>A new boxed value objec of type T</returns>
        static object CreateStruct<T>(IGlobal global,JsInstance[] args) where T : struct
        {
            return new T();
        }


        /// <summary>
        /// Peforms a construction of a CLR instance inside the specified 
        /// </summary>
        /// <param name="visitor"></param>
        /// <param name="that"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            if (that == null || that == JsUndefined.Instance || that == JsNull.Instance || (that as IGlobal) == visitor.Global)
                throw new JintException("A constructor '" + reflectedType.FullName + "' should be applied to the object");

            if (that.Value != null)
                throw new JintException("Can't apply the constructor '" + reflectedType.FullName + "' to already initialized '" + that.Value.ToString() + "'");

            that.Value = CreateInstance(visitor, parameters);
            SetupNativeProperties(that);
            ((JsObject)that).Indexer = m_indexer;
            return that;
        }

        /// <summary>
        /// Creates a new native object and wraps it with a JsObject.
        /// </summary>
        /// <remarks>
        /// This method is overriden to delegate a container creation to the <see cref="Wrap"/> method.
        /// </remarks>
        /// <param name="parameters">a constructor arguments</param>
        /// <param name="genericArgs">Ignored since this class represents a non-generic types</param>
        /// <param name="visitor">Execution visitor</param>
        /// <returns>A newly created js object</returns>
        public override JsObject Construct(JsInstance[] parameters, Type[] genericArgs, Jint.Expressions.IJintVisitor visitor)
        {
            return (JsObject)Wrap( CreateInstance( visitor, parameters ) );
        }
        
        /// <summary>
        /// Finds a best matched constructor and uses it to create a native object instance
        /// </summary>
        /// <param name="visitor">Execution visitor</param>
        /// <param name="parameters">Parameters for a constructor</param>
        /// <returns>A newly created native object</returns>
        object CreateInstance(Jint.Expressions.IJintVisitor visitor, JsInstance[] parameters)
        {
            ConstructorImpl impl = m_overloads.ResolveOverload(parameters, null);
            if (impl == null)
                throw new JintException(
                    String.Format("No matching overload found {0}({1})",
                        reflectedType.FullName,
                        String.Join(",", Array.ConvertAll<JsInstance, string>(parameters, p => p.ToString()))
                    )
                );

            return impl(visitor.Global, parameters);
        }

        public void SetupNativeProperties(JsDictionaryObject target)
        {
            if (target == null || target == JsNull.Instance || target == JsUndefined.Instance )
                throw new ArgumentException("A valid js object is required","target");
            foreach (var prop in m_properties)
                target.DefineOwnProperty(new NativeDescriptor(target, prop) );
        }

        public override JsInstance Wrap<T>(T value)
        {
            Type ttype = typeof(T);
            Type vtype = value.GetType();
            object newcomobj = null;

            if (!reflectedType.IsAssignableFrom(ttype) && !reflectedType.IsAssignableFrom(vtype))
            {
                if (System.Runtime.InteropServices.Marshal.IsComObject(value))
                {
                    newcomobj = WrapComObject(value, reflectedType);
                    if (newcomobj == null)
                    {
                        throw new JintException("Attempt to wrap 'ComObject' with '" + reflectedType.FullName + "'");
                    }
                }
                else
                {
                    throw new JintException("Attempt to wrap '" + vtype.FullName + "' with '" + reflectedType.FullName + "'");
                }
            }
            JsObject inst = Global.ObjectClass.New(PrototypeProperty);
            if (newcomobj == null)
            {
                inst.Value = value;
            }
            else
            {
                inst.Value = newcomobj;
            }
            inst.Indexer = m_indexer;
            SetupNativeProperties(inst);

            return inst;
        }

        protected ConstructorImpl WrapMember(ConstructorInfo info)
        {
            return m_marshaller.WrapConstructor(info,true);
        }

        protected IEnumerable<ConstructorInfo> GetMembers(Type[] genericArguments, int argCount) {
            if (m_constructors == null)
                return new ConstructorInfo[0];

            return Array.FindAll(m_constructors, con => con.GetParameters().Length == argCount);

        }
    }
}
