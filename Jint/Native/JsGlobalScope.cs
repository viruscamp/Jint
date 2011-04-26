using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Class represents a global scope which is binded to the global object.
    /// </summary>
    public class JsGlobalScope: JsObjectScope {
        IGlobal m_global;
        bool m_strict;

        public JsGlobalScope(IGlobal global, bool strict)
            : base(global, JsNull.Instance) {
            m_strict = strict;
            m_global = global;
        }

        public override IJsInstance ResolveIdentifier(string name) {
            Descriptor d = GetOwnProperty(name);

            if (d != null) {
                if (d.isReference) {
                    LinkedDescriptor link = d as LinkedDescriptor;
                    Debug.Assert(link != null);

                    return new JsDescriptorReference(link.targetObject, link.targetDescriptor);
                } else {
                    return new JsIdentifierReference(d);
                }
            }

            return new JsUnresolvedReference(m_bag, name, m_strict);
        }
    }
}
