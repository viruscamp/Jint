using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Class represents a global scope which is binded to the global object.
    /// </summary>
    public class JsGlobalScope: JsObjectScope {
        public JsGlobalScope(IGlobal global, Options options)
            : base(global, JsNull.Instance, options) {
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

            return new JsUnresolvedReference(GlobalObject, name, IsStrict);
        }
    }
}
