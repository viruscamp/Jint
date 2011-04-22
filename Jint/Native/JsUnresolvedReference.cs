using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Represents a logic of an unresolvable reference, see ecma 262.5 8.7.2.
    /// </summary>
    /// <remarks>
    /// Attempt to get a value of an unresolvable reference throws an exception.
    /// Attempt to put a value to an unresolvable reference will add a new property to the global
    /// object or will throw an exception if this is a strict reference.
    /// </remarks>
    class JsUnresolvedReference: JsReference {
        string m_identifier;
        IJsObject m_global;
        bool m_strict;

        public JsUnresolvedReference(IJsObject global, string identifier, bool strict) {
            Debug.Assert(!String.IsNullOrEmpty(identifier));
            Debug.Assert(global != null);

            m_strict = strict;
            m_global = global;
            m_identifier = identifier;
        }

        public override IJsObject BaseObject {
            get { return JsUndefined.Instance; }
        }

        public override string ReferencedProperty {
            get { return null; }
        }

        public override IJsObject GetObject() {
            throw new JsReferenceException(m_identifier);
        }

        public override void SetObject(IJsObject value) {
            if (m_strict)
                throw new JsReferenceException(m_identifier);
            m_global.Put(m_identifier, value, false);
        }
    }
}
