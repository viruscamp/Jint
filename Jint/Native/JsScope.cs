using System;
using System.Collections.Generic;
using System.Text;
using Jint.PropertyBags;

namespace Jint.Native {
    /// <summary>
    /// Declarative environment record, holds declared variables and functions.
    /// </summary>
    /// <remarks>
    /// A prototype chain is used to represent nested environments.
    /// </remarks>
    public class JsScope : JsObjectBase {
        JsScope m_outer;

        public JsScope(JsScope outer)
            : base(outer) {
            m_outer = outer;
        }

        public override bool IsClr {
            get { return false; }
        }

        public override object Value {
            get {
                return null;
            }
            set {
                ;
            }
        }

        public override string Class {
            get { JsInstance.CLASS_SCOPE; }
        }

        public IJsInstance ResolveIdentifier(string name) {
            Descriptor d = GetOwnProperty(name);
            
            if (d == null || d.DescriptorType == DescriptorType.None)
                return m_outer.ResolveIdentifier(name);

            return new JsIdentifierReference(d);
        }
    }
}
