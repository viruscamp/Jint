using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Constructors is a special class of functions, they are able to create
    /// new objects and always have a prototype.
    /// </summary>
    public abstract class JsConstructor : JsFunctionBase {
        IGlobal m_global;
        string m_name;
        int m_length;
        
        protected JsConstructor(string name, int length, IGlobal global, IJsObject prototype)
            : base(prototype) {

            Debug.Assert(global != null);
            Debug.Assert(length >= 0);

            m_global = global;
        }

        public IGlobal Global {
            get { return m_global; }
        }

        public override string Name {
            get {
                return m_name;
            }
        }

        public override IList<string> Arguments {
            get { return new string[0]; }
        }

        public override int Length {
            get { return m_length; }
        }

        public override string GetBody() {
            return "/* native code */";
        }
    }
}
