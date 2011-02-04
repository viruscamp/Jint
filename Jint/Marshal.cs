using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;
using System.Reflection;
using System.Reflection.Emit;
using Jint.Marshal;
using Jint.Delegates;
using System.Text.RegularExpressions;

namespace Jint
{
    /// <summary>
    /// Marshals clr objects to js objects and back
    /// </summary>
    /// <remarks>
    /// <pre>
    ///     Automaticly discovers a prototype of a clr object, and caches this information.
    /// </pre>
    /// <pre>
    ///     Also discovers an object constructors, and creates an appropriate constructor function.
    /// </pre>
    /// <pre>
    ///     A native clr function can be a generic and may have some overloads, all this members
    ///     with a same name are transformed to a single function object.
    /// </pre>
    /// <pre>
    ///     A clr types are marshalled to functions. Js functions marshaled to the delegates
    /// </pre>
    /// </remarks>
    public class Marshaller
    {
        struct MarshalledParameter
        {
            public LocalBuilder tempLocal;
            public int index;

            public MarshalledParameter(LocalBuilder temp, int index)
            {
                tempLocal = temp;
                this.index = index;
            }
        };

        IGlobal m_global;
        Dictionary<Type, NativeConstructor> m_typeCache = new Dictionary<Type,NativeConstructor>();
        Dictionary<Type, Delegate> m_arrayMarshllers = new Dictionary<Type, Delegate>();
        NativeTypeConstructor m_typeType;

        /* Assuming that Object supports IConvertable
         *
         */
        static bool[,] IntegralTypeConvertions = {
        //      Empty   Object  DBNull  Boolean Char    SByte   Byte    Int16   UInt16  Int32   UInt32  Int64   UInt64  Single  Double  Decimal DateTim -----   String
/*Empty*/   {   false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  true    },
/*Objec*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  true    },
/*DBNul*/   {   false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  true    },
/*Boole*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Char */   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  false,  false,  false,  true    },
/*SByte*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Byte */   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Int16*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*UInt1*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Int32*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*UInt3*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Int64*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*UInt6*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Singl*/   {   false,  false,  false,  true,   false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Doubl*/   {   false,  false,  false,  true,   false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*Decim*/   {   false,  false,  false,  true,   false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  false,  true    },
/*DateT*/   {   false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  true,   false,  true    },
/*-----*/   {   false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false,  false   },
/*Strin*/   {   false,  false,  false,  true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   true,   false,  true    }
        };

        /// <summary>
        /// Constaructs a new marshaller object.
        /// </summary>
        /// <param name="global">A global object which can be used for constructing new JsObjects due marshalling.</param>
        public Marshaller(IGlobal global)
        {
            this.m_global = global;
        }

        public void InitTypes()
        {
            // we cant initize a m_typeType property since m_global.Marshller should be initialized
            m_typeType = NativeTypeConstructor.CreateNativeTypeConstructor(m_global);

            m_typeCache[typeof(Type)] = m_typeType;

            //TODO: replace a native contructors with apropriate js constructors
            foreach (var t in new Type[] {
                typeof(Int16),
                typeof(Int32),
                typeof(Int64),
                typeof(UInt16),
                typeof(UInt32),
                typeof(UInt64),
                typeof(Single),
                typeof(Double), // NumberConstructor
                typeof(Byte),
                typeof(SByte)
            })
                m_typeCache[t] = CreateConstructor(t, m_global.NumberClass.PrototypeProperty);

            m_typeCache[typeof(String)] = CreateConstructor(typeof(String), m_global.StringClass.PrototypeProperty);
            m_typeCache[typeof(Char)] = CreateConstructor(typeof(Char), m_global.StringClass.PrototypeProperty);
            m_typeCache[typeof(Boolean)] = CreateConstructor(typeof(Boolean), m_global.BooleanClass.PrototypeProperty);
            m_typeCache[typeof(DateTime)] = CreateConstructor(typeof(DateTime), m_global.DateClass.PrototypeProperty);
            m_typeCache[typeof(Regex)] = CreateConstructor(typeof(Regex), m_global.RegExpClass.PrototypeProperty);

        }

        /// <summary>
        /// Marshals a native value to a JsInstance
        /// </summary>
        /// <typeparam name="T">A type of a native value</typeparam>
        /// <param name="value">A native value</param>
        /// <returns>A marshalled JsInstance</returns>
        public JsInstance MarshalClrValue<T>(T value)
        {
            if (value == null)
                return JsNull.Instance;

            if (value is JsInstance)
                return value as JsInstance;

            if (value is Type)
            {
                Type t = value as Type;
                if (t.IsGenericTypeDefinition)
                {
                    // Generic defenitions aren't types is the meaning of js
                    // but they are instances of System.Type
                    var res = new NativeGenericType(t, m_typeType.PrototypeProperty);
                    m_typeType.SetupNativeProperties(res);
                    return res;
                }
                else
                {
                    return MarshalType(value as Type);
                }
            }
            else
            {
                return MarshalType(value.GetType()).Wrap(value);
            }
        }

        public JsConstructor MarshalType(Type t)
        {
            NativeConstructor res;
            if (m_typeCache.TryGetValue(t, out res))
                return res;
            
            return m_typeCache[t] = CreateConstructor(t);
        }

        NativeConstructor CreateConstructor(Type t)
        {
            // TODO: Move this code to NativeTypeConstructor.Wrap
            /* NativeConstructor res;
            res = new NativeConstructor(t, m_global);
            res.InitPrototype(m_global);
            m_typeType.SetupNativeProperties(res);
            return res;
            */
            return (NativeConstructor)m_typeType.Wrap(t);
        }

        NativeConstructor CreateConstructor(Type t, JsObject prototypePropertyPrototype)
        {
            /* NativeConstructor res;
            res = new NativeConstructor(t, m_global,prototypeProperty);
            res.InitPrototype(m_global);
            m_typeType.SetupNativeProperties(res);
            return res; */
            return (NativeConstructor)m_typeType.WrapSpecialType(t, prototypePropertyPrototype);
        }

        TElem[] MarshalJsArrayHelper<TElem>(JsObject value)
        {
            int len = (int)value["length"].ToNumber();
            if (len < 0)
                len = 0;

            TElem[] res = new TElem[len];
            for (int i = 0; i < len; i++)
                res[i] = MarshalJsValue<TElem>(value[new JsNumber(i, JsUndefined.Instance)]);

            return res;
        }

        object MarshalJsFunctionHelper(JsFunction func,Type delegateType)
        {
            JsFunctionDelegate wrapper = new JsFunctionDelegate(m_global.Visitor, func, JsNull.Instance , delegateType);
            return wrapper.GetDelegate();

        }

        /// <summary>
        /// Marshals a JsInstance to a native value.
        /// </summary>
        /// <typeparam name="T">A native object type</typeparam>
        /// <param name="value">A JsInstance to marshal</param>
        /// <returns>A converted native velue</returns>
        public T MarshalJsValue<T>(JsInstance value)
        {
            if (value.Value is T)
            {
                return (T)value.Value;
            }
            else
            {
                if (typeof(T).IsArray)
                {
                    if (value == null || value == JsUndefined.Instance || value == JsNull.Instance)
                        return default(T);
                    if (m_global.ArrayClass.HasInstance(value as JsObject))
                    {
                        Delegate marshller;
                        if (!m_arrayMarshllers.TryGetValue(typeof(T), out marshller))
                            m_arrayMarshllers[typeof(T)] = marshller = Delegate.CreateDelegate(
                                typeof(Func<JsObject, T>),
                                this,
                                typeof(Marshaller)
                                    .GetMethod("MarshalJsFunctionHelper")
                                    .MakeGenericMethod(typeof(T).GetElementType())
                            );

                        return ((Func<JsObject, T>)marshller)(value as JsObject);
                    }
                    else
                    {
                        throw new JintException("Array is required");
                    }
                }
                else if (typeof(Delegate).IsAssignableFrom(typeof(T)))
                {
                    if (value == null || value == JsUndefined.Instance || value == JsNull.Instance)
                        return default(T);

                    if (! (value is JsFunction) )
                        throw new JintException("Can't convert a non function object to a delegate type");
                    return (T)MarshalJsFunctionHelper(value as JsFunction, typeof(T));
                }
                else if (value != JsNull.Instance && value != JsUndefined.Instance && value is T)
                {
                    return (T)(object)value;
                }
                else
                {
                    // JsNull and JsUndefined will fall here and become a nulls
                    return (T)Convert.ChangeType(value.Value, typeof(T));
                }
            }
        }

        /// <summary>
        /// This is a temporary solution... Used when calling a members on value types.
        /// </summary>
        /// <remarks>
        /// This method used to get a reference to the boxed value type, then a reference is
        /// unboxed to managed pointer and then is used as the first argument in a method call.
        /// </remarks>
        /// <typeparam name="T">Type of value type, which we desire to get</typeparam>
        /// <param name="value">A js value which should be marshalled</param>
        /// <returns>A reference to a boxed value</returns>
        public object MarshalJsValueBoxed<T>(JsInstance value)
        {
            if (value.Value is T)
                return value.Value;
            else
                return null;
        }


        /// <summary>
        /// Gets a type of a native object represented by the current JsInstance.
        /// If JsInstance is a pure JsObject than returns a type of js object itself.
        /// </summary>
        /// <remarks>
        /// If a value is a wrapper around native value (like String, Number or a marshaled native value)
        /// this method returns a type of a stored value.
        /// If a value is an js object (constructed with a pure js function) this method returns
        /// a type of this value (for example JsArray, JsObject)
        /// </remarks>
        /// <param name="value">JsInstance value</param>
        /// <returns>A Type object</returns>
        public Type GetInstanceType(JsInstance value)
        {
            if (value == null || value == JsUndefined.Instance || value == JsNull.Instance )
                return null;

            if (value.Value != null )
                return value.Value.GetType();

            return value.GetType();
        }

        #region wrappers

        /// <summary>
        /// Converts a native method to a standard delegate.
        /// </summary>
        /// <param name="info">A method to wrap</param>
        /// <param name="passGlobal">If this paramerter is true and the first argument of the constructor
        /// is IGlobal, a wrapper delegate will pass a Global JS object in the first parameter.</param>
        /// <returns>A wrapper delegate</returns>
        public JsMethodImpl WrapMethod(MethodInfo info, bool passGlobal)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            if (info.ContainsGenericParameters)
                throw new InvalidOperationException("Can't wrap an unclosed generic");

            LinkedList<ParameterInfo> parameters = new LinkedList<ParameterInfo>(info.GetParameters());
            LinkedList<MarshalledParameter> outParams = new LinkedList<MarshalledParameter>();

            DynamicMethod jsWrapper = new DynamicMethod("jsWrapper", typeof(JsInstance), new Type[] { typeof(IGlobal), typeof(JsInstance), typeof(JsInstance[]) }, this.GetType());
            var code = jsWrapper.GetILGenerator();

            code.DeclareLocal(typeof(int)); // local #0: count of the passed arguments
            code.DeclareLocal(typeof(Marshaller));

            code.Emit(OpCodes.Ldarg_0);
            code.Emit(OpCodes.Call, typeof(IGlobal).GetProperty("Marshaller").GetGetMethod());

            if (!info.ReturnType.Equals(typeof(void)) )
            {
                // push the global.Marshaller object
                // for the future use
                code.Emit(OpCodes.Dup);
            }

            code.Emit(OpCodes.Stloc_1);

            if (!info.IsStatic)
            {
                var lblDesired = code.DefineLabel();
                var lblWrong = code.DefineLabel();

                // push the global.Marshaller object
                code.Emit(OpCodes.Ldloc_1);

                code.Emit(OpCodes.Ldarg_1); // 'that' parameter

                if (info.DeclaringType.IsValueType)
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(info.DeclaringType));
                else
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(info.DeclaringType));

                code.Emit(OpCodes.Dup); // remember converted result
                code.Emit(OpCodes.Ldnull);

                code.Emit(OpCodes.Beq, lblWrong);
                code.Emit(OpCodes.Br, lblDesired);

                code.MarkLabel(lblWrong);

                code.Emit(OpCodes.Ldstr, "The specified 'that' object is not acceptable for this method");
                code.Emit(OpCodes.Newobj, typeof(JintException).GetConstructor(new Type[] { typeof(string) }));
                code.Emit(OpCodes.Throw);

                code.MarkLabel(lblDesired);

                // everything is ok
                // we have a converted 'that' value in the stack now
                // if that is a value type, we need to unbox it

                if (info.DeclaringType.IsValueType)
                    code.Emit(OpCodes.Unbox, info.DeclaringType);
            }

            // if the first parameter is IGlobal and passGlobal is enabled
            if (passGlobal && parameters.First != null && typeof(IGlobal).IsAssignableFrom(parameters.First.Value.ParameterType))
            {
                parameters.RemoveFirst();
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Isinst, typeof(IGlobal));
            }

            // argsCount = arguments.Length
            code.Emit(OpCodes.Ldarg_2); // 'arguments' parameter
            code.Emit(OpCodes.Ldlen);

            code.Emit(OpCodes.Stloc_0);

            int i = 0;
            foreach (var parameter in parameters)
            {
                // push the global.Marshaller object
                code.Emit(OpCodes.Ldloc_1);

                // if ( argsCount > i )
                var lblDefaultValue = code.DefineLabel();
                var lblEnd = code.DefineLabel();

                code.Emit(OpCodes.Ldloc_0);
                code.Emit(OpCodes.Ldc_I4, i);
                code.Emit(OpCodes.Ble, lblDefaultValue);

                // push arguments[i]
                code.Emit(OpCodes.Ldarg_2);
                code.Emit(OpCodes.Ldc_I4, i);
                code.Emit(OpCodes.Ldelem, typeof(JsInstance));

                code.Emit(OpCodes.Br, lblEnd);
                code.MarkLabel(lblDefaultValue);
                // else

                // push JsUndefined.Instance
                code.Emit(OpCodes.Ldsfld, typeof(JsUndefined).GetField("Instance"));

                code.MarkLabel(lblEnd);

                // convert current parameter to a proper type
                if (parameter.ParameterType.IsByRef)
                {
                    Type paramType = parameter.ParameterType.GetElementType();
                    LocalBuilder tempLocal = code.DeclareLocal(paramType);
                    // marshall
                    code.Emit(
                        OpCodes.Call,
                        typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(paramType)
                    );
                    // store value in the temp variable
                    code.Emit(OpCodes.Stloc, tempLocal.LocalIndex);
                    // load a reference to the variable
                    code.Emit(OpCodes.Ldloca, tempLocal.LocalIndex);

                    if (parameter.IsOut)
                        outParams.AddLast(new MarshalledParameter(tempLocal,i));
                }
                else
                {
                    code.Emit(
                        OpCodes.Call,
                        typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameter.ParameterType)
                    );
                }

                i++;
            }

            // now we have an optional 'that' parameter followed by the sequence of converted arguments
            if (!info.IsStatic)
                code.Emit(OpCodes.Callvirt, info);
            else
                code.Emit(OpCodes.Call, info);

            // unmarshal out parameters
            foreach( var param in outParams)
            {
                // if (argcount > i)
                var lblEnd = code.DefineLabel();

                code.Emit(OpCodes.Ldloc_0);
                code.Emit(OpCodes.Ldc_I4, param.index);
                code.Emit(OpCodes.Ble, lblEnd);

                // set arguments[i] = marshaller.MarshalClrValue(tempLocal);
                code.Emit(OpCodes.Ldarg_2);
                code.Emit(OpCodes.Ldc_I4, param.index);

                code.Emit(OpCodes.Ldloc_1);
                code.Emit(OpCodes.Ldloc, param.tempLocal);
                code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(param.tempLocal.LocalType));
                
                code.Emit(OpCodes.Stelem, typeof(JsInstance));

                code.MarkLabel(lblEnd);
            }

            if (!info.ReturnType.Equals( typeof(void) ) )
            {
                // convert a result into JsInstance
                code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(info.ReturnType));
            }
            else
            {
                // push JsUndefined.Instance
                code.Emit(OpCodes.Ldnull);
                code.Emit(OpCodes.Ldfld, typeof(JsUndefined).GetField("Instance"));
            }

            code.Emit(OpCodes.Ret);

            return (JsMethodImpl)jsWrapper.CreateDelegate(typeof(JsMethodImpl));
        }

        /// <summary>
        /// Converts a constructor to a standart delegate
        /// </summary>
        /// <param name="info">A constructor to wrap</param>
        /// <param name="passGlobal">If this paramerter is true and the first argument of the constructor
        /// is IGlobal, a wrapper delegate will pass a Global JS object in the first parameter.</param>
        /// <returns>A wrapper delegate</returns>
        public ConstructorImpl WrapConstructor(ConstructorInfo info,bool passGlobal)
        {
            LinkedList<ParameterInfo> parameters = new LinkedList<ParameterInfo>(info.GetParameters());

            DynamicMethod dm = new DynamicMethod("clrConstructor", typeof(object), new Type[] { typeof(IGlobal), typeof(JsInstance[]) }, this.GetType());
            var code = dm.GetILGenerator();

            code.DeclareLocal(typeof(int)); // local #0: count of the passed arguments

            if (passGlobal && parameters.First != null && typeof(IGlobal).IsAssignableFrom(parameters.First.Value.ParameterType))
            {
                parameters.RemoveFirst();
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Isinst, typeof(IGlobal));
            }

            // argsCount = arguments.Length
            code.Emit(OpCodes.Ldarg_1); // 'arguments' parameter
            code.Emit(OpCodes.Ldlen);

            code.Emit(OpCodes.Stloc_0);

            int i = 0;
            foreach (var parameter in parameters)
            {

                // push the global.Marshaller object
                code.Emit(OpCodes.Ldarg_0);
                code.EmitCall(OpCodes.Call, typeof(IGlobal).GetProperty("Marshaller").GetGetMethod(), null);

                // if ( argsCount > i )
                var lblDefaultValue = code.DefineLabel();
                var lblEnd = code.DefineLabel();

                code.Emit(OpCodes.Ldloc_0);
                code.Emit(OpCodes.Ldc_I4, i);
                code.Emit(OpCodes.Ble, lblDefaultValue);

                // push arguments[i]
                code.Emit(OpCodes.Ldarg_1);
                code.Emit(OpCodes.Ldc_I4, i);
                code.Emit(OpCodes.Ldelem, typeof(JsInstance));

                code.Emit(OpCodes.Br, lblEnd);
                code.MarkLabel(lblDefaultValue);
                // else

                // push JsUndefined.Instance
                code.Emit(OpCodes.Ldsfld, typeof(JsUndefined).GetField("Instance"));

                code.MarkLabel(lblEnd);

                // convert current parameter to a proper type
                if (parameter.ParameterType.IsByRef)
                {
                    Type paramType = parameter.ParameterType.GetElementType();
                    LocalBuilder tempLocal = code.DeclareLocal(paramType);
                    // marshall
                    code.Emit(
                        OpCodes.Call,
                        typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(paramType)
                    );
                    // store value in the temp variable
                    code.Emit(OpCodes.Stloc, tempLocal.LocalIndex);
                    // load a reference to the variable
                    code.Emit(OpCodes.Ldloca, tempLocal.LocalIndex);
                }
                else
                {
                    code.Emit(
                        OpCodes.Call,
                        typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameter.ParameterType)
                    );
                }

                i++;
            }

            // now we have a sequence of converted arguments

            code.Emit(OpCodes.Newobj, info);

            if (info.DeclaringType.IsValueType)
                code.Emit(OpCodes.Box, info.DeclaringType);

            code.Emit(OpCodes.Ret);

            return (ConstructorImpl)dm.CreateDelegate(typeof(ConstructorImpl));
        }

        public JsGetter WrapGetProperty(PropertyInfo prop)
        {
            DynamicMethod dm = new DynamicMethod("dynamicPropertyGetter", typeof(JsInstance) , new Type[] { typeof(Marshaller), typeof(JsDictionaryObject) }, typeof(Marshaller) );
            MethodInfo info = prop.GetGetMethod();

            var code = dm.GetILGenerator();

            code.Emit(OpCodes.Ldarg_0);

            if (!info.IsStatic)
            {
                code.Emit(OpCodes.Dup);
                code.Emit(OpCodes.Ldarg_1);

                if (prop.DeclaringType.IsValueType)
                {
                    //LocalBuilder temp = code.DeclareLocal(prop.DeclaringType);
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(prop.DeclaringType));
                    code.Emit(OpCodes.Unbox, prop.DeclaringType);
                    //code.Emit(OpCodes.Stloc,temp);
                    //code.Emit(OpCodes.Ldloca,temp);
                }
                else
                {
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(prop.DeclaringType));
                }
                code.Emit(OpCodes.Callvirt, info);
            }
            else
            {
                // static methods should be invoked with OpCodes.Call
                code.Emit(OpCodes.Call, info);
            }
            
            code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(prop.PropertyType));

            code.Emit(OpCodes.Ret);

            return (JsGetter)dm.CreateDelegate(typeof(JsGetter), this);
        }

        public JsGetter WrapGetField(FieldInfo field)
        {
            DynamicMethod dm = new DynamicMethod("dynamicFieldGetter", typeof(JsInstance), new Type[] { typeof(Marshaller), typeof(JsDictionaryObject) }, typeof(Marshaller));
            var code = dm.GetILGenerator();

            code.Emit(OpCodes.Ldarg_0);

            if (!field.IsStatic)
            {
                code.Emit(OpCodes.Dup);
                code.Emit(OpCodes.Ldarg_1);

                if (field.DeclaringType.IsValueType)
                {
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(field.DeclaringType));
                    code.Emit(OpCodes.Unbox, field.DeclaringType);
                }
                else
                {
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(field.DeclaringType));
                }
                code.Emit(OpCodes.Ldfld, field);
            }
            else
            {
                code.Emit(OpCodes.Ldsfld, field);
            }

            code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(field.FieldType));

            code.Emit(OpCodes.Ret);

            return (JsGetter)dm.CreateDelegate(typeof(JsGetter), this);
        }

        public JsSetter WrapSetProperty(PropertyInfo prop)
        {
            DynamicMethod dm = new DynamicMethod("dynamicPropertySetter", null, new Type[] { typeof(Marshaller), typeof(JsDictionaryObject), typeof(JsInstance) },typeof(Marshaller));
            MethodInfo info = prop.GetSetMethod();

            var code = dm.GetILGenerator();

            if (!info.IsStatic)
            {
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_1);

                if (prop.DeclaringType.IsValueType)
                {
                    //LocalBuilder temp = code.DeclareLocal(prop.DeclaringType);
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(prop.DeclaringType));
                    code.Emit(OpCodes.Unbox, prop.DeclaringType);
                    //code.Emit(OpCodes.Stloc, temp);
                    //code.Emit(OpCodes.Ldloca, temp);
                }
                else
                {
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(prop.DeclaringType));
                }
            }

            code.Emit(OpCodes.Ldarg_0);
            code.Emit(OpCodes.Ldarg_2);
            code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(prop.PropertyType));

            if (info.IsStatic)
                code.Emit(OpCodes.Call, info);
            else
                code.Emit(OpCodes.Callvirt, info);

            code.Emit(OpCodes.Ret);

            return (JsSetter)dm.CreateDelegate(typeof(JsSetter), this);
        }

        public JsSetter WrapSetField(FieldInfo field)
        {
            DynamicMethod dm = new DynamicMethod("dynamicPropertySetter", null, new Type[] { typeof(Marshaller), typeof(JsDictionaryObject), typeof(JsInstance) }, typeof(Marshaller));

            var code = dm.GetILGenerator();

            if (!field.IsStatic)
            {
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_1);

                if (field.DeclaringType.IsValueType)
                {
                    //LocalBuilder temp = code.DeclareLocal(prop.DeclaringType);
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(field.DeclaringType));
                    code.Emit(OpCodes.Unbox, field.DeclaringType);
                    //code.Emit(OpCodes.Stloc, temp);
                    //code.Emit(OpCodes.Ldloca, temp);
                }
                else
                {
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(field.DeclaringType));
                }
            }

            code.Emit(OpCodes.Ldarg_0);
            code.Emit(OpCodes.Ldarg_2);
            code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(field.FieldType));

            if (field.IsStatic)
                code.Emit(OpCodes.Stsfld, field);
            else
                code.Emit(OpCodes.Stfld, field);

            code.Emit(OpCodes.Ret);

            return (JsSetter)dm.CreateDelegate(typeof(JsSetter), this);
        }

        public JsIndexerGetter WrapIndexerGetter(MethodInfo getMethod)
        {
            if (getMethod == null)
                throw new ArgumentNullException("getMethod");
            if (getMethod.GetParameters().Length != 1 || getMethod.ReturnType.Equals(typeof(void)))
                throw new ArgumentException("Invalid getter", "getMethod");

            DynamicMethod dm = new DynamicMethod("dynamicIndexerSetter", typeof(JsInstance), new Type[] { typeof(Marshaller), typeof(JsInstance), typeof(JsInstance) });

            ILGenerator code = dm.GetILGenerator();

            code.Emit(OpCodes.Ldarg_0);

            if (!getMethod.IsStatic)
            {
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_1);

                if (getMethod.DeclaringType.IsValueType)
                {
                    //LocalBuilder temp = code.DeclareLocal(prop.DeclaringType);
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(getMethod.DeclaringType));
                    code.Emit(OpCodes.Unbox, getMethod.DeclaringType);
                    //code.Emit(OpCodes.Stloc, temp);
                    //code.Emit(OpCodes.Ldloca, temp);
                }
                else
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(getMethod.DeclaringType));
                }
            }

            {
                var param = getMethod.GetParameters()[0];
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_2);

                if (param.ParameterType.IsByRef)
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(param.ParameterType));
                    code.Emit(OpCodes.Unbox, param.ParameterType);
                }
                else
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(param.ParameterType));
                }
            }

            if (getMethod.IsStatic)
                code.Emit(OpCodes.Call, getMethod);
            else
                code.Emit(OpCodes.Callvirt, getMethod);

            code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(getMethod.ReturnType));

            code.Emit(OpCodes.Ret);

            return (JsIndexerGetter)dm.CreateDelegate(typeof(JsIndexerGetter), this);
        }

        public JsIndexerSetter WrapIndexerSetter(MethodInfo setMethod)
        {
            if (setMethod == null)
                throw new ArgumentNullException("getMethod");
            if (!(setMethod.GetParameters().Length == 2 && setMethod.ReturnType.Equals(typeof(void))))
                throw new ArgumentException("Invalid getter", "getMethod");

            DynamicMethod dm = new DynamicMethod("dynamicIndexerSetter", typeof(void), new Type[] { typeof(Marshaller), typeof(JsInstance), typeof(JsInstance), typeof(JsInstance) });

            ILGenerator code = dm.GetILGenerator();

            if (!setMethod.IsStatic)
            {
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_1);

                if (setMethod.DeclaringType.IsValueType)
                {
                    //LocalBuilder temp = code.DeclareLocal(prop.DeclaringType);
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(setMethod.DeclaringType));
                    code.Emit(OpCodes.Unbox, setMethod.DeclaringType);
                    //code.Emit(OpCodes.Stloc, temp);
                    //code.Emit(OpCodes.Ldloca, temp);
                }
                else
                {
                    code.Emit(OpCodes.Callvirt, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(setMethod.DeclaringType));
                }
            }

            {
                var param = setMethod.GetParameters()[0];
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_2);

                if (param.ParameterType.IsByRef)
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(param.ParameterType));
                    code.Emit(OpCodes.Unbox, param.ParameterType);
                }
                else
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(param.ParameterType));
                }
            }

            {
                var param = setMethod.GetParameters()[1];
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Ldarg_3);

                if (param.ParameterType.IsByRef)
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(param.ParameterType));
                    code.Emit(OpCodes.Unbox, param.ParameterType);
                }
                else
                {
                    code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(param.ParameterType));
                }
            }

            if (setMethod.IsStatic)
                code.Emit(OpCodes.Call, setMethod);
            else
                code.Emit(OpCodes.Callvirt, setMethod);

            code.Emit(OpCodes.Ret);

            return (JsIndexerSetter)dm.CreateDelegate(typeof(JsIndexerSetter), this);
        }

        /// <summary>
        /// Marshals a native property to a descriptor
        /// </summary>
        /// <param name="prop">Property to marshal</param>
        /// <param name="owner">Owner of the returned descriptor</param>
        /// <returns>A descriptor</returns>
        public NativeDescriptor MarshalPropertyInfo(PropertyInfo prop, JsDictionaryObject owner)
        {
            JsGetter getter;
            JsSetter setter = null;

            if (prop.CanRead)
            {
                getter = WrapGetProperty(prop);
            }
            else
            {
                getter = delegate(JsDictionaryObject that)
                {
                    return JsUndefined.Instance;
                };
            }

            if (prop.CanWrite)
            {
                setter = (JsSetter)WrapSetProperty(prop);
            }

            return setter == null ? new NativeDescriptor(owner, prop.Name, getter) { Enumerable = true } : new NativeDescriptor(owner, prop.Name, getter, setter) { Enumerable = true };
        }

        /// <summary>
        /// Marshals a native field to a JS Descriptor
        /// </summary>
        /// <param name="prop">Field info to marshal</param>
        /// <param name="owner">Owner for the descriptor</param>
        /// <returns>Descriptor</returns>
        public NativeDescriptor MarshalFieldInfo(FieldInfo prop, JsDictionaryObject owner)
        {
            JsGetter getter;
            JsSetter setter;

            if (prop.IsLiteral)
            {
                JsInstance value = null; // this demand initization should prevent a stack overflow while reflecting types
                getter = delegate(JsDictionaryObject that) {
                    if (value == null)
                        value = (JsInstance)typeof(Marshaller)
                            .GetMethod("MarshalClrValue")
                            .MakeGenericMethod(prop.FieldType)
                            .Invoke(this, new object[] { prop.GetValue(null) });
                    return value;
                };
                setter = delegate(JsDictionaryObject that, JsInstance v) { };
            }
            else
            {
                getter = (JsGetter)WrapGetField(prop);
                setter = (JsSetter)WrapSetField(prop);
            }

            return new NativeDescriptor(owner, prop.Name, getter, setter) { Enumerable = true };
        }

        #endregion

        public bool IsAssignable(Type target, Type source)
        {
            return
                (typeof(IConvertible).IsAssignableFrom(source) && IntegralTypeConvertions[(int)Type.GetTypeCode(source), (int)Type.GetTypeCode(target)])
                || target.IsAssignableFrom(source);
        }
    }
}
