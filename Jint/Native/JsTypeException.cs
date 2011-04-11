using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public class JsTypeException : Exception {
        public JsTypeException(string msg)
            : base(msg) {
        }
    }
}
