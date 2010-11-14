using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;
using System.Reflection;
using System.Reflection.Emit;

namespace Jint.Native
{
    public class ClrMethodWrapper: JsFunction {
        public delegate JsInstance ClrMethodImpl(IGlobal global, JsInstance that, JsInstance[] arguments);

        ClrMethodImpl impl;

        public ClrMethodWrapper(MethodInfo info, JsObject prototype)
            : this(info, prototype, false)
        {

        }

        /// <summary>
        /// Constructs a new JsFunction with supplied implementation
        /// </summary>
        /// <param name="info">Method info</param>
        /// <param name="prototype">A function prototype</param>
        /// <param name="passGlobal">Flag indicates that the function accepts
        /// a global object as the first parameter</param>
        public ClrMethodWrapper(MethodInfo info, JsObject prototype, bool passGlobal)
            : base(prototype)
        {

            ParameterInfo[] parameters = info.GetParameters();

            DynamicMethod jsWrapper = new DynamicMethod("jsWrapper", typeof(JsInstance), new Type[] {typeof(IGlobal), typeof(JsInstance), typeof(JsInstance[]) }, this.GetType());
            var code = jsWrapper.GetILGenerator();
            
            code.DeclareLocal( typeof(int) ); // local #0: count of the passed arguments

            if (info.ReturnType != null) {
                // push the global.Marshaller object
                // for the future use
                code.Emit(OpCodes.Ldarg_0);
                code.Emit(OpCodes.Call,typeof(IGlobal).GetProperty("Marshaller").GetGetMethod());
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
                code.Emit(OpCodes.Newobj, typeof(Exception).GetConstructor(new Type[] { typeof(string) } ));
                code.Emit(OpCodes.Throw);

                code.MarkLabel(lblDesired);

                // everything is ok
                // we have a converted 'that' value in the stack now
            }

            if (passGlobal)
            {
                code.Emit(OpCodes.Ldarg_0);
            }

            // argsCount = arguments.Length
            code.Emit(OpCodes.Ldarg_2); // 'arguments' parameter
            code.Emit(OpCodes.Ldlen);
            
            code.Emit(OpCodes.Stloc_0);

            for (int i = 0; i < parameters.Length; i++ )
            {
                Arguments.Add(parameters[i].Name);

                // push the global.Marshaller object
                code.Emit(OpCodes.Ldarg_0);
                code.EmitCall(OpCodes.Call,typeof(IGlobal).GetProperty("Marshaller").GetGetMethod(),null);

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
                code.Emit(OpCodes.Ldfld,typeof(JsUndefined).GetField("Instance"));

                code.MarkLabel(lblEnd);

                // convert current parameter to a proper type
                code.Emit(
                    OpCodes.Call,
                    typeof(Marshaller).GetMethod("JsToClrValue").MakeGenericMethod(parameters[i].ParameterType)
                );
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

            impl = (ClrMethodImpl)jsWrapper.CreateDelegate(typeof(ClrMethodImpl));
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            visitor.Return( impl(visitor.Global, that, parameters) );
            return that;
        }

        public override JsObject Construct(JsInstance[] parameters, Type[] genericArgs, ExecutionVisitor visitor)
        {
            throw new JintException("This method can't be used as a constructor");
        }
    }
    
}
