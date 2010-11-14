using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace Jint.Native
{
    /// <summary>
    /// Wrapper around a clr constructor
    /// </summary>
    public class ClrConstructorWrapper: JsFunction
    {

        public delegate object ConstructorImpl(IGlobal global,JsInstance[] parameters);

        ConstructorImpl impl;

        public ClrConstructorWrapper(ConstructorInfo info, JsObject prototype, bool passGlobal)
            : base(prototype)
        {
            LinkedList< ParameterInfo > parameters = new LinkedList<ParameterInfo> ( info.GetParameters() );

            DynamicMethod dm = new DynamicMethod("clrConstructor", typeof(object), new Type[] { typeof(IGlobal), typeof(JsInstance[]) }, this.GetType() );
            var code = dm.GetILGenerator();

            code.DeclareLocal(typeof(int)); // local #0: count of the passed arguments

            if (passGlobal && parameters.First != null && typeof(IGlobal).IsAssignableFrom( parameters.First.Value.ParameterType ) )
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
                Arguments.Add(parameter.Name);

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
                code.Emit(OpCodes.Box, info.DeclaringType );

            code.Emit(OpCodes.Ret);

            impl = (ConstructorImpl)dm.CreateDelegate(typeof(ConstructorImpl));
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            that.Value = impl(visitor.Global,parameters);
            visitor.Return(that);
            return that;
        }

        
    }
}
