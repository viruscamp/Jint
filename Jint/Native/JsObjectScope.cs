using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Class represents an object environment
    /// </summary>
    public class JsObjectScope: JsScope {
        IJsObject m_bag;

        public JsObjectScope(IJsObject bag, JsScope outer)
            : base(outer) {

            if (bag == null)
                throw new ArgumentNullException("bag");
            m_bag = bag;
        }

        public override Descriptor GetOwnProperty(string name) {

            Descriptor d = base.GetOwnProperty(name);

            if (d == null) {
                Descriptor objectProperty = m_bag.GetProperty(name);
                if (objectProperty != null) {
                    d = new LinkedDescriptor(this, name, objectProperty, m_bag);
                    internalDefineOwnProperty(null, d);
                }
            } else {
                Debug.Assert(!d.isDeleted);
            }

            return d;
        }

        public override IEnumerable<Descriptor> GetOwnProperties() {
            foreach (Descriptor objectProperty in m_bag.GetOwnProperties())
                yield return GetOwnProperty(objectProperty.Name);

            foreach (Descriptor d in base.GetOwnProperties())
                if (!d.isReference)
                    yield return d;
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

            return m_outer.ResolveIdentifier(name);
        }
    }
}
