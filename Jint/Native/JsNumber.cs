using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Jint.Native {
    [Serializable]
    public sealed class JsNumber : JsObject, ILiteral {
        private double value;

        public override object Value {
            get {
                return value;
            }
        }

        public JsNumber(JsObject prototype)
            : this(0d, prototype) {
        }

        public JsNumber(double num, JsObject prototype)
            : base(prototype) {
            value = num;
        }

        public JsNumber(int num, JsObject prototype)
            : base(prototype) {
            value = num;
        }

        public static bool NumberToBoolean(double value) {
            return value != 0;
        }

        public override bool ToBoolean() {
            return NumberToBoolean(value);
        }

        public override double ToNumber() {
            return value;
        }

        public override string ToString() {
            return value.ToString(CultureInfo.InvariantCulture).ToLower();
        }

        public override object ToObject() {
            return value;
        }

        public const string TYPEOF = "number";

        public override string Class {
            get { return TYPEOF; }
        }
    }
}
