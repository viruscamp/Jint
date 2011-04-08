using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Represents a reference.
    /// </summary>
    public abstract class JsReference {
        JsObject m_base;

        protected JsReference(JsObject target) {
            m_base = target;
        }

        public JsObject targetObject {
            get {
                return m_base;
            }
        }

        public abstract string propertyName {
            get;
        }

        public abstract JsObject GetObject();
        public abstract void SetObject(JsObject value);
    }
}
