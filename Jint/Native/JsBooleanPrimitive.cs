using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// A primitive boolean type
    /// </summary>
    public class JsBooleanPrimitive : JsPrimitiveValue {

        bool m_value;

        public JsBooleanPrimitive(bool value, IJsObject prototype)
            : base(prototype) {
            m_value = value;
        }

        public override bool ToBoolean() {
            return m_value;
        }

        public override double ToNumber() {
            return m_value ? 1 : 0;
        }

        public override int ToInteger() {
            return m_value ? 1 : 0;
        }

        public override uint ToUInt32() {
            return m_value ? 1 : 0;
        }

        public override ushort ToUInt16() {
            return m_value ? 1 : 0;
        }

        public override IJsObject ToObject(IGlobal global) {
            if (global == null)
                throw new ArgumentNullException("global");
            global.BooleanClass.New(m_value);
        }

        public override string ToString() {
            return m_value ? "true" : "false";
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (bool)m_value;
            }
        }

        public override string Class {
            get { return JsInstance.CLASS_BOOLEAN; }
        }

        public override JsObjectType Type {
            get { return JsObjectType.Boolean; }
        }
    }
}
