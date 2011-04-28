using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public class JsRangeException: Exception {

        public JsRangeException(string msg)
            : base(msg) {

        }
    }
}
