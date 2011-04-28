using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public abstract class JsFunctionBase: JsObjectBase, IFunction {
        public const string CONSTRUCTOR = "constructor";
        public const string PROTOTYPE = "prototype";
        public const string ARGUMENTS = "arguments";
        public const string THIS = "this";
        public const string LENGTH = "length";
        public const string CALLER = "caller";
        public const string CALL = "call";
        public const string APPLY = "apply";

        public JsFunctionBase(IJsObject prototype)
            : base(prototype) {
            DefineOwnProperty(new NativeValueDescriptor(this, LENGTH, delegate(IJsObject that) { return Length; }), true);
        }

        public static IJsObject[] NormalizeParameters(IJsInstance[] parameters, int length) {
            if (length <= 0)
                return new IJsInstance[0];

            IJsObject[] res = new IJsObject[length];

            if (parameters == null || parameters.Length == 0) {
                for (int i = 0; i < length; i++)
                    res[i] = JsUndefined.Instance;
                return res;
            } else {
                for (int i = 0; i < length; i++)
                    res[i] = i < parameters.Length ? parameters[i].GetObject() : JsUndefined.Instance;
                return res;
            }
        }

        public override bool IsClr {
            get { return false; }
        }

        public override object Value {
            get {
                return null;
            }
            set {
                ;
            }
        }

        public override string Class {
            get { return JsInstance.CLASS_FUNCTION; }
        }

        #region IFunction Members

        public virtual string Name {
            get { return String.Empty; }
        }

        public abstract IList<string> Arguments {
            get;
        }

        public abstract int Length {
            get;
        }

        public abstract IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext);

        public virtual string ToStringImpl() {
            return String.Format(
                "function {0} ({1}) {{ {2} }}",
                that.Name,
                String.Join(", ", new List<string>(that.Arguments).ToArray()),
                GetBody()
            );
        }

        public abstract string GetBody();

        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}
