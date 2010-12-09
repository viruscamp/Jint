using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;

namespace Jint.Native {
    [Serializable]
    public class JsUndefined : JsObject {
        public static JsUndefined Instance = new JsUndefined() { Attributes = PropertyAttributes.DontEnum | PropertyAttributes.DontDelete };

        public JsUndefined() {
        }

        public override int Length {
            get {
                return 0;
            }
            set {
            }
        }

        public override bool IsClr
        {
            get
            {
                return false;
            }
        }

        public override Descriptor GetDescriptor(string index) {
            return null;
        }

        public new const string TYPEOF = "undefined";

        public override string Class {
            get { return TYPEOF; }
        }

        public override string ToString() {
            return "undefined";
        }

        public override object ToObject() {
            return null;
        }

        public override bool ToBoolean() {
            return false;
        }

        public override double ToNumber() {
            return double.NaN;
        }
    }
}
