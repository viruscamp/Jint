using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Boolean class
    /// </summary>
    public sealed class JsBoolean : JsObjectBase {

        bool m_value;

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
                m_value = (bool)value;
            }
        }

        public override IJsObject ToPrimitive(IGlobal global) {
            if (global == null)
                throw new ArgumentNullException("global");

            return global.NewPrimitive(m_value);
        }

        public override string Class {
            get { return JsInstance.CLASS_BOOLEAN; }
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

        public override string ToString() {
            return m_value ? "true" : "false";
        }
    }
}
