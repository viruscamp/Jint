using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// A number primitive
    /// </summary>
    public class JsNumberPrimitive: JsPrimitiveValue {
        double m_value;

        public JsNumberPrimitive(double val, IJsObject prototype): base(prototype) {
            m_value = val;
        }

        public JsNumberPrimitive(IJsObject prototype)
            : this(0, prototype) {
        }

        public override bool ToBoolean() {
            if (m_value == 0 || Double.IsNaN(m_value))
                return false;
            return true;
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

        public override IJsObject ToObject(IGlobal global) {
            global.NumberClass.New(m_value);
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (double) value;
            }
        }

        public override string Class {
            get { JsInstance.CLASS_NUMBER; }
        }

        public override JsObjectType Type {
            get { return JsObjectType.Number; }
        }
    }
}
