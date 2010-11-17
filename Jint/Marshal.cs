using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;
using System.Reflection;
using System.Reflection.Emit;
using Jint.Marshal;

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

        IGlobal global;

        public Marshaller(IGlobal global)
        {
            this.global = global;
        }

        public JsInstance MarshalClrValue<T>(T value)
        {
            return global.WrapClr(value);
        }

        
        public T MarshalJsValue<T>(JsInstance value)
        {
            return (T)Convert.ChangeType(value.Value, typeof(T));
        }

        public Type GetNativeType(JsInstance value)
        {
            if (value == null)
                return null;

            if (value is JsObject)
            {
                return ((JsObject)value).Value == null ? null : ((JsObject)value).Value.GetType();
            }
            return value.GetType();
        }

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

                code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("JsToClrValue").MakeGenericMethod(info.DeclaringType));

                // check result
                code.Emit(OpCodes.Dup); // remember converted result
                code.Emit(OpCodes.Ldnull);

                code.Emit(OpCodes.Beq, lblWrong);
                code.Emit(OpCodes.Br, lblDesired);

                code.MarkLabel(lblWrong);

                code.Emit(OpCodes.Ldstr, "The specified 'that' object is not acceptable for this method");
                code.Emit(OpCodes.Newobj, typeof(Exception).GetConstructor(new Type[] { typeof(string) }));
                code.Emit(OpCodes.Throw);

                code.MarkLabel(lblDesired);

                // everything is ok
                // we have a converted 'that' value in the stack now
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
                code.Emit(
                    OpCodes.Call,
                    typeof(Marshaller).GetMethod("JsToClrValue").MakeGenericMethod(parameter.ParameterType)
                );

                i++;
            }

            // now we have an optional 'that' parameter followed by the sequence of converted arguments
            code.Emit(OpCodes.Call, info);

            if (info.ReturnType != null)
            {
                // convert a result into JsInstance
                code.Emit(OpCodes.Call, typeof(Marshaller).GetMethod("ClrToJsValue").MakeGenericMethod(info.ReturnType));
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

        ConstructorImpl WrapConstructor(ConstructorInfo info,bool passGlobal)
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
                code.Emit(OpCodes.Ldarg_1);
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
                code.Emit(
                    OpCodes.Call,
                    typeof(Marshaller).GetMethod("JsToClrValue").MakeGenericMethod(parameter.ParameterType)
                );

                i++;
            }

            // now we have a sequence of converted arguments

            code.Emit(OpCodes.Newobj, info);

            if (info.DeclaringType.IsValueType)
                code.Emit(OpCodes.Box, info.DeclaringType);

            code.Emit(OpCodes.Ret);

            return (ConstructorImpl)dm.CreateDelegate(typeof(ConstructorImpl));
        }

        JsGetter GenGetProperty<T, V>(PropertyInfo prop)
        {
            NativeGetter<T,V> func = (NativeGetter<T,V>) Delegate.CreateDelegate(typeof(NativeGetter<T,V>), prop.GetGetMethod());
            return delegate(JsDictionaryObject that)
            {
                return MarshalClrValue<V>(func(MarshalJsValue<T>(that)));
            };
        }

        JsSetter GetSetProperty<T, V>(PropertyInfo prop)
        {
            NativeSetter<T, V> func = (NativeSetter<T, V>) Delegate.CreateDelegate(typeof(NativeSetter<T,V>), prop.GetSetMethod() );
            return delegate(JsDictionaryObject that, JsInstance value)
            {
                func(MarshalJsValue<T>(that), MarshalJsValue<V>(value));
            };
        }

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
                    .GetMethod("GetSetProperty")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.PropertyType
                    )
                    .Invoke(this, new object[] { prop });
            }

            return setter == null ? new NativeDescriptor(owner, prop.Name, getter) : new NativeDescriptor(owner, prop.Name, getter, setter);
        }

        JsGetter GenGetField<TThat, TVal>(FieldInfo field)
        {
            return delegate(JsDictionaryObject that)
            {
                return MarshalClrValue<TVal>(
                    (TVal)field.GetValue(MarshalJsValue<TThat>( that ) )
                );
            };
        }

        JsSetter GenSetField<TThat, TVal>(FieldInfo field)
        {
            return delegate(JsDictionaryObject that, JsInstance value)
            {
                field.SetValue(MarshalJsValue<TThat>(that), MarshalJsValue<TVal>(value));
            };
        }


        public Descriptor MarshalFieldInfo(FieldInfo prop, JsDictionaryObject owner)
        {
            JsGetter getter;
            JsSetter setter;


            getter = (JsGetter)GetType()
                    .GetMethod("GenGetProperty")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.FieldType
                    )
                    .Invoke(this, new object[] { prop });
            setter = (JsSetter)GetType()
                    .GetMethod("GetSetProperty")
                    .MakeGenericMethod(
                        prop.DeclaringType,
                        prop.FieldType
                    )
                    .Invoke(this, new object[] { prop });

            return new NativeDescriptor(owner, prop.Name, getter, setter);
        }
    }
}
