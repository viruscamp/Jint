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
        protected JsScope m_outer;
        Options m_options;

        public JsScope(JsScope outer)
            : base(outer) {
            m_outer = outer;
        }

        public Options Options {
            get { return m_options; }
        }

        public bool IsStrict {
            get { return m_options & Options.Strict; }
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

        public virtual IJsInstance ResolveIdentifier(string name) {
            Descriptor d = GetOwnProperty(name);
            
            if (d == null || d.DescriptorType == DescriptorType.None)
                return m_outer.ResolveIdentifier(name);

            return new JsIdentifierReference(d);
        }
    }
}
