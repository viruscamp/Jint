using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using Jint.Delegates;
using System.Diagnostics;

namespace Jint.Native {
    [Serializable]
    public class JsFunctionConstructor : JsConstructor {


        public JsFunctionConstructor(IGlobal global, IFunction prototype)
            : base(JsInstance.CLASS_FUNCTION , global, prototype) {

            DefineOwnProperty(PROTOTYPE, prototype, PropertyAttributes.DontEnum | PropertyAttributes.DontConfigure | PropertyAttributes.ReadOnly);

            proto.DefineOwnProperty(CONSTRUCTOR, this, PropertyAttributes.DontEnum);
            proto.DefineOwnProperty(CALL, new JsMethodWrapper<IFunction>(CallImpl, 1, proto), PropertyAttributes.DontEnum);
            proto.DefineOwnProperty(APPLY, new JsMethodWrapper<IFunction>(ApplyImpl, 2, proto), PropertyAttributes.DontEnum);
            proto.DefineOwnProperty("toString", new JsMethodWrapper<IFunction>(ToStringImpl,proto), PropertyAttributes.DontEnum);
        }


        /// <summary>
        /// Apply function implementation, see ecma 262.5 15.3.4.3.
        /// </summary>
        /// <remarks>
        /// Using JsArray, JsArgumnets is much faster than other types of objects.
        /// </remarks>
        /// <param name="that"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IJsObject ApplyImpl(IFunction that, IJsInstance[] parameters) {
            Debug.Assert(that != null);
            if (parameters == null || parameters.Length < 2)
                throw new JsTypeException("Not enough parameters for apply method");

            IJsObject thisArg = parameters[0].GetObject();
            IJsObject argArray = parameters[1].GetObject();

            IJsInstance[] targetParameters;

            if (argArray is JsArray) {
                JsArray nativeArray = argArray as JsArray;

                targetParameters = new IJsInstance[nativeArray.Length];
                nativeArray.CopyTo(targetParameters, 0);
            } else if (argArray is JsArguments) {
                JsArguments nativeArguments = argArray as JsArguments;

                targetParameters = new IJsInstance[nativeArguments.Length];
                nativeArguments.CopyTo(targetParameters, 0);
            } else {
                IJsObject len = argArray["length"];
                UInt32 intLen = len.ToUInt32();
                if (len.ToNumber() != intLen )
                    throw new JsTypeException("Invalid arguments");

                targetParameters = new IJsInstance[intLen];
                for (UInt32 i = 0; i < intLen; i++)
                    targetParameters[i] = argArray.IndexerGet(Global.NewPrimitive(i));
            }

            return that.Invoke(thisArg, targetParameters);
        }

        IJsObject CallImpl(IFunction that, IJsInstance[] parameters) {
            Debug.Assert(that != null);

            if (parameters == null || parameters.Length == 0)
                throw new JsTypeException("Not enough parameters for call method");

            IJsObject thisArg = parameters[0].GetObject();

            IJsInstance[] targetParameters;

            if (parameters.Length > 1) {
                targetParameters = new IJsInstance[parameters.Length - 1];
                Array.Copy(parameters, 1, targetParameters, 0, parameters.Length - 1);
            }

            return that.Invoke(thisArg, targetParameters);
        }

        IJsObject ToStringImpl(IFunction that) {
            Debug.Assert(that != null);
            return Global.NewPrimitive( that.ToStringImpl() );
        }

        public IFunction New() {
            return new JsEmptyFunction(Global, PrototypeProperty);
        }

        public IFunction New<T>(JsMethodNoArgsDelegate<T> impl) where T : IJsObject {
            return new JsMethodWrapper<T>(impl, PrototypeProperty);
        }

        public IFunction New<T>(JsMethodDelegate<T> impl) where T : IJsObject {
            return new JsMethodWrapper<T>(impl, PrototypeProperty);
        }

        public IFunction New<T>(JsMethodDelegate<T> impl, int length) where T : IJsObject {
            return new JsMethodWrapper<T>(impl, length, PrototypeProperty);
        }

        public IFunction New(JsFunctionDelegate impl, int length) {
            return new JsFunctionWrapper(impl, String.Empty, length, PrototypeProperty);
        }

        public IFunction New(Delegate d) {
            return Global.Marshaller.MarshalDelegate(d);
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            return Construct(parameters, callingContext);
        }

        public override IJsObject Construct(IJsInstance[] parameters,JsScope callingContext) {
            if (parameters == null || parameters.Length == 0)
                return new JsEmptyFunction(Global,PrototypeProperty);

            // at least one parameter
            Program p = JintEngine.Compile(parameters[parameters.Length - 1].Value.ToString(), false);
            BlockStatement body = new BlockStatement() { Statements = p.Statements };
            
            List<string> args = new List<string>(parameters.Length -1);

            for (int i = 0; i < parameters.Length - 1; i++) {
                string arg = parameters[i].ToString();

                foreach (string a in arg.Split(','))
                    args.Add(a.Trim());
            }


            return new JsFunction(Global, new JsScope(callingContext), String.Empty, args, body, PrototypeProperty);
        }

        public override int Length {
            get { return 1; }
        }
    }
}
