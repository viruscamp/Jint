using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public class JsReferenceException: JsException {
        string m_identifier;
        public JsReferenceException(string identifier) {
            m_identifier = identifier;
        }
    }
}
