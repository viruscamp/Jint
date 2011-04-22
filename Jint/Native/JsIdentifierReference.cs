using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// This class represents references to identifiers from declarative environment records
    /// </summary>
    class JsIdentifierReference: JsReference {
        Descriptor m_binding;

        public JsIdentifierReference(Descriptor binding) {
            Debug.Assert(binding != null);

            m_binding = binding;
        }

        public override IJsObject BaseObject {
            get { return JsUndefined.Instance; }
        }

        public override string ReferencedProperty {
            get { m_binding.Name; }
        }

        public override IJsObject GetObject() {
            return m_binding.Get(m_binding.Owner);
        }

        public override void SetObject(IJsObject value) {
            m_binding.Set(m_binding.Owner,value);
        }
    }
}
