using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Boolean class, ecma 262.5 15.6
    /// </summary>
    public sealed class JsBoolean : JsObjectBase {

        bool m_value;

        public override bool IsClr {
            get { return false; }
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (bool)value;
            }
        }

        public override string Class {
            get { return JsInstance.CLASS_BOOLEAN; }
        }
    }
}
