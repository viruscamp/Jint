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

        IGlobal m_global;
        Dictionary<Type, ClrConstructor> m_typeCache = new Dictionary<Type,ClrConstructor>();
        Dictionary<Type, Delegate> m_arrayMarshllers = new Dictionary<Type, Delegate>();
        ClrConstructor m_typeType;

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
            m_typeType = new ClrConstructor(typeof(Type), m_global);
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
                m_typeCache[t] = new ClrConstructor(t, m_global, m_global.NumberClass.PrototypeProperty);

            m_typeCache[typeof(String)] = new ClrConstructor(typeof(String), m_global, m_global.StringClass.PrototypeProperty);
            m_typeCache[typeof(Char)] = new ClrConstructor(typeof(Char), m_global, m_global.StringClass.PrototypeProperty);
            m_typeCache[typeof(Boolean)] = new ClrConstructor(typeof(Boolean), m_global, m_global.BooleanClass.PrototypeProperty);
            m_typeCache[typeof(DateTime)] = new ClrConstructor(typeof(DateTime), m_global, m_global.DateClass.PrototypeProperty);
            m_typeCache[typeof(Regex)] = new ClrConstructor(typeof(Regex), m_global, m_global.RegExpClass.PrototypeProperty);
        }

        /// <summary>
        /// Marshals a native value to a JsInstance
        /// </summary>
        /// <typeparam name="T">A type of a native value</typeparam>
        /// <param name="value">A native value</param>
        /// <returns>A marshalled JsInstance</returns>
        public JsInstance MarshalClrValue<T>(T value)
        {
            return MarshalType(value.GetType()).Wrap(value);
        }

        public JsConstructor MarshalType(Type t)
        {
            ClrConstructor res;
            if (m_typeCache.TryGetValue(t, out res))
                return res;
            return m_typeCache[t] = new ClrConstructor(t, m_global);
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
                else
                {
                    return (T)Convert.ChangeType(value.Value, typeof(T));
                }
            }
        }

        /// <summary>
        /// Gets a type of a native object represented by the current JsInstance.
        /// If JsInstance is a pure JsObject than returns a native type of this object itself.
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

        /// <summary>
        /// Converts a native method to a standard delegate.
        /// </summary>
        /// <param name="info">A method to wrap</param>
        /// <param name="passGlobal">If this paramerter is true and the first argument of the constructor
        /// is IGlobal, a wrapper delegate will pass a Global JS object in the first parameter.</param>
        /// <returns>A wrapper delegate</returns>
        public JsMethodImpl WrapMethod(MethodInfo info, bool passGlobal)
        {
            LinkedList<ParameterInfo> parameters = new LinkedList<ParameterInfo>(info.GetParameters());

            DynamicMethod jsWrapper = new DynamicMethod("jsWrapper", typeof(JsInstance), new Type[] { typeof(IGlobal), typeof(JsInstance), typeof(JsInstance[]) }, this.GetType());
            var code = jsWrapper.GetILGenerator();

            code.DeclareLocal(typeof(int)); // local #0: count of the passed arguments

            if (info.ReturnType != null)
            {
                // push the global.Marshaller object
                // for the future use
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Call, typeof(IGlobal).GetProperty("Marshaller").GetGetMethod());
            }

            if (!info.IsStatic)
            {
                var lblDesired = code.DefineLabel();
                var lblWrong = code.DefineLabel();

                // push the global.Marshaller object
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Call, typeof(IGlobal).GetProperty("Marshaller").GetGetMethod());

                code.Emit(OpCodes.Ldarg_1); // 'that' parameter

                code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(info.DeclaringType));

                // check result
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
                // if that is a value type, we need to store it in a temporary value and pass it by reference

                if (info.DeclaringType.IsValueType)
                {
                    //TODO: can't update a value type
                    LocalBuilder tempLocal = code.DeclareLocal(info.DeclaringType);
                    code.Emit(OpCodes.Stloc);
                    code.Emit(OpCodes.Ldloca, tempLocal.LocalIndex);
                }
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
                code.Emit(OpCodes.Ldarg_0);
                code.EmitCall(OpCodes.Call, typeof(IGlobal).GetProperty("Marshaller").GetGetMethod(), null);

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
                code.Emit(OpCodes.Ldnull);
                code.Emit(OpCodes.Ldfld, typeof(JsUndefined).GetField("Instance"));

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

            // now we have an optional 'that' parameter followed by the sequence of converted arguments
            code.Emit(OpCodes.Call, info);

            if (info.ReturnType != typeof(void) )
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

        public JsGetter GenGetProperty<T, V>(PropertyInfo prop)
        {
            MethodInfo info = prop.GetGetMethod();

            if (info.IsStatic)
            {
                StaticNativeGetter<V> func = (StaticNativeGetter<V>)Delegate.CreateDelegate(typeof(StaticNativeGetter<V>), info);
                return delegate(JsDictionaryObject that)
                {
                    return MarshalClrValue<V>(func());
                };
            }
            else
            {
                if (typeof(T).IsValueType)
                {
                    NativeGetterByRef<T, V> func = (NativeGetterByRef<T, V>)Delegate.CreateDelegate(typeof(NativeGetterByRef<T, V>), info);
                    return delegate(JsDictionaryObject that)
                    {
                        // TODO: can't update a value type
                        T inst = MarshalJsValue<T>(that);
                        return MarshalClrValue<V>(func(ref inst));
                    };
                }
                else
                {
                    NativeGetter<T, V> func = (NativeGetter<T, V>)Delegate.CreateDelegate(typeof(NativeGetter<T, V>), info);
                    return delegate(JsDictionaryObject that)
                    {
                        return MarshalClrValue<V>(func(MarshalJsValue<T>(that)));
                    };
                }
            }
        }

        public JsSetter GenSetProperty<T, V>(PropertyInfo prop)
        {
            MethodInfo info = prop.GetSetMethod();
            
            if (info.IsStatic)
            {
                StaticNativeSetter<V> func = (StaticNativeSetter<V>)Delegate.CreateDelegate(typeof(StaticNativeSetter<V>), info);
                return delegate(JsDictionaryObject that, JsInstance value)
                {
                    func(MarshalJsValue<V>(value));
                };
            }
            else
            {
                if (typeof(T).IsValueType)
                {
                    NativeSetterByRef<T, V> func = (NativeSetterByRef<T, V>)Delegate.CreateDelegate(typeof(NativeSetterByRef<T, V>), null, info);
                    return delegate(JsDictionaryObject that, JsInstance value)
                    {
                        // TODO: method can't update a value type
                        T inst = MarshalJsValue<T>(that);
                        func(ref inst, MarshalJsValue<V>(value));
                    };
                }
                else
                {
                    NativeSetter<T, V> func = (NativeSetter<T, V>)Delegate.CreateDelegate(typeof(NativeSetter<T, V>), null, info);
                    return delegate(JsDictionaryObject that, JsInstance value)
                    {
                        func(MarshalJsValue<T>(that), MarshalJsValue<V>(value));
                    };
                }
            }
        }

        /// <summary>
        /// Marshals a native property to a descriptor
        /// </summary>
        /// <param name="prop">Property to marshal</param>
        /// <param name="owner">Owner of the returned descriptor</param>
        /// <returns>A descriptor</returns>
        public Descriptor MarshalPropertyInfo(PropertyInfo prop,JsDictionaryObject owner)
        {
            JsGetter getter;
            JsSetter setter = null;

            if (prop.CanRead)
            {
                getter = (JsGetter) GetType()
                    .GetMethod("GenGetProperty")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.PropertyType
                    )
                    .Invoke(this, new object[] { prop });
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
                setter = (JsSetter) GetType()
                    .GetMethod("GenSetProperty")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.PropertyType
                    )
                    .Invoke(this, new object[] { prop });
            }

            return setter == null ? new NativeDescriptor(owner, prop.Name, getter) : new NativeDescriptor(owner, prop.Name, getter, setter);
        }

        /// <summary>
        /// Helper to wrap a field with getter
        /// </summary>
        /// <typeparam name="TThat">Type of the target object</typeparam>
        /// <typeparam name="TVal">Type of the field value</typeparam>
        /// <param name="field">FieldInfo</param>
        /// <returns>A wrapper getter</returns>
        public JsGetter GenGetField<TThat, TVal>(FieldInfo field)
        {
            return delegate(JsDictionaryObject that)
            {
                return MarshalClrValue<TVal>(
                    (TVal)field.GetValue(MarshalJsValue<TThat>(that))
                );
            };

        }

        /// <summary>
        /// Helper function to wrap a field with setter
        /// </summary>
        /// <typeparam name="TThat">Type of the target object</typeparam>
        /// <typeparam name="TVal">Type of the field value</typeparam>
        /// <param name="field">FieldInfo</param>
        /// <returns>A wrapper setter</returns>
        public JsSetter GenSetField<TThat, TVal>(FieldInfo field)
        {
            return delegate(JsDictionaryObject that, JsInstance value)
            {
                field.SetValue(MarshalJsValue<TThat>(that), MarshalJsValue<TVal>(value));
            };
        }


        /// <summary>
        /// Marshals a native field to a JS Descriptor
        /// </summary>
        /// <param name="prop">Field info to marshal</param>
        /// <param name="owner">Owner for the descriptor</param>
        /// <returns>Descriptor</returns>
        public Descriptor MarshalFieldInfo(FieldInfo prop, JsDictionaryObject owner)
        {
            JsGetter getter;
            JsSetter setter;


            getter = (JsGetter)GetType()
                    .GetMethod("GenGetField")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.FieldType
                    )
                    .Invoke(this, new object[] { prop });
            setter = (JsSetter)GetType()
                    .GetMethod("GenSetField")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.FieldType
                    )
                    .Invoke(this, new object[] { prop });

            return new NativeDescriptor(owner, prop.Name, getter, setter);
        }
    }
}
