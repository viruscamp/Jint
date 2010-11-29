using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    [Serializable]
    public sealed class JsBoolean : JsObject, ILiteral {
        private bool value;

        public override object Value {
            get { return value; }
        }

        public JsBoolean(JsObject prototype)
            : this(false, prototype) {
            value = false;
        }

        public JsBoolean(bool boolean, JsObject prototype)
            : base(prototype) {
            value = boolean;
        }

        public const string TYPEOF = "boolean";

        public override string Class {
            get { return TYPEOF; }
        }

        public override bool ToBoolean() {
            return value;
        }

        public override string ToString() {
            return value ? "true" : "false";
        }

        public static double BooleanToNumber(bool value) {
            return value ? 1 : 0;
        }

        public override double ToNumber() {
            return BooleanToNumber(value);
        }
    }
}
