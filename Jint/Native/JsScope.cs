using System;
using System.Collections.Generic;
using System.Text;
using Jint.PropertyBags;
using System.Diagnostics;

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
        IGlobal m_global;

        public JsScope(JsScope outer)
            : base(outer) {
            m_outer = outer;
            m_options = outer.Options;
            m_global = outer.GlobalObject;
        }

        protected JsScope(IGlobal global,IJsObject prototype,Options options): base(prototype) {
            Debug.Assert(global != null);
            m_global = global;
            m_options = options;
        }

        public IGlobal GlobalObject {
            get { return m_global; }
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
