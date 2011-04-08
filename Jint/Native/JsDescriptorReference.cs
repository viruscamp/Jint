using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public class JsDescriptorReference: JsReference {
        Descriptor m_proeprty;

        public JsDescriptorReference(JsObject target, Descriptor d)
            : base(target) {
            m_proeprty = d;
        }

        public override string propertyName {
            get { return m_proeprty.Name; }
        }

        public override JsObject GetObject() {
            // TODO: remove type cast
            return (JsObject)m_proeprty.Get(targetObject);
        }

        public override void SetObject(JsObject value) {
            m_proeprty.Set(targetObject,value);
        }
    }
}
