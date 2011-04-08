using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    [Serializable]
    public class JsException : Exception {
        public IJsInstance Value { get; set; }

        public JsException() {
        }

        public JsException(IJsInstance value) {
            Value = value;
            //if (value is JsDictionaryObject)
            //    ((JsDictionaryObject)value)["jintException"] = new JsClr(this);
        }
    }
}
