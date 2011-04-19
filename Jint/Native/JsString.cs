using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jint.Delegates;

namespace Jint.Native {
    [Serializable]
    public sealed class JsString : JsObjectBase {

        string m_value;

        public override bool IsClr {
            get { return false; }
        }

        public override IJsObject DefaultValue(IGlobal global, DefaultValueHints hint) {
            if (global == null)
                throw new ArgumentNullException("global");

            switch (hint) {
                case DefaultValueHints.String:
                    return global.NewPrimitive(m_value);
                case DefaultValueHints.Number:
                    return global.NewPrimitive(ToNumber());
            }
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (string) value;
            }
        }

        public override IJsObject ToPrimitive(IGlobal global) {
            if (global == null)
                throw new ArgumentNullException("global");

            return global.NewPrimitive(m_value);
        }

        public override string Class {
            get { return JsInstance.CLASS_STRING; }
        }

        public override bool ToBoolean() {
            return ConversionTraits.ToBoolean(m_value);
        }

        public override double ToNumber() {
            return ConversionTraits.ToNumber(m_value);
        }

        public override int ToInteger() {
            return ConversionTraits.ToInteger(m_value);
        }

        public override uint ToUInt32() {
            return ConversionTraits.ToUInt32(m_value);
        }

        public override ushort ToUInt16() {
            return ConversionTraits.ToUInt16(m_value);
        }

        public override string ToString() {
            return m_value;
        }
    }
}
