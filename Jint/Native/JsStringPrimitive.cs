using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Primitive string type
    /// </summary>
    public class JsStringPrimitive: JsPrimitiveValue {
        string m_value;

        public JsStringPrimitive(string value, IJsObject prototype) : base(prototype) {
            m_value = value;
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

        public override IJsObject ToObject(IGlobal global) {
            if (global == null)
                throw new ArgumentNullException("global");

            return global.StringClass.New(m_value);
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (string)value;
            }
        }

        public override string Class {
            get { return JsInstance.CLASS_STRING; }
        }

        public override JsObjectType Type {
            get { return JsObjectType.String; }
        }
    }
}
