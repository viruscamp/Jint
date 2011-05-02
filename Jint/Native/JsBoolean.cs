using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Boolean class, ecma 262.5 15.6
    /// </summary>
    public sealed class JsBoolean : JsObjectBase, IPrimitiveValue<bool> {

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

        #region IPrimitiveValue<bool> Members

        public bool PrimitiveValue {
            get { return m_value; }
        }

        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}
