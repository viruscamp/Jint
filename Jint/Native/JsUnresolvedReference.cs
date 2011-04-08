using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public class JsUnresolvedReference: JsReference {
        string m_property;

        public JsUnresolvedReference(JsObject target, string propertyName): base(target) {
            m_property = propertyName;
        }

        public override string propertyName {
            get { return m_property; }
        }

        public override JsObject GetObject() {
            throw new JsReferenceException(m_property);
        }

        public override void SetObject(JsObject value) {
            targetObject[m_property] = value;
        }
    }
}
