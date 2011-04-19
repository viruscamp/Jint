using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Jint.Native {
    [Serializable]
    public sealed class JsNumber : JsObjectBase {

        double m_value;

        public JsNumber(double value, IJsObject prototype)
            : base(prototype) {
            m_value = value;
        }

        public override bool IsClr {
            get { return false; }
        }

        public override IJsObject DefaultValue(IGlobal global, DefaultValueHints hint) {
            if (global == null)
                throw new ArgumentNullException("global");

            switch (hint) {
                case DefaultValueHints.String:
                    return global.NewPrimitive(ToString());

                case DefaultValueHints.Number:
                    return global.NewPrimitive(m_value);
            }
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (double)value;
            }
        }

        public override IJsObject ToPrimitive(IGlobal global) {
            if (global == null)
                throw new ArgumentNullException("global");
            return global.NewPrimitive(m_value);
        }

        public override string Class {
            get { return JsInstance.CLASS_NUMBER; }
        }

        public override bool ToBoolean() {
            return ConversionTraits.ToBoolean(m_value);
        }

        public override double ToNumber() {
            return m_value;
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
            return ConversionTraits.ToString(m_value);
        }
    }
}
