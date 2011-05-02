using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jint.Delegates;

namespace Jint.Native {
    [Serializable]
    public sealed class JsString : JsObjectBase, IPrimitiveValue<string> {

        string m_value;

        public override bool IsClr {
            get { return false; }
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = (string) value;
            }
        }

        public override string Class {
            get { return JsInstance.CLASS_STRING; }
        }

        #region IPrimitiveValue<string> Members

        public string PrimitiveValue {
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
