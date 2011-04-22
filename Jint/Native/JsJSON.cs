using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public class JsJSON: JsObjectBase {
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
            get { return JsInstance.CLASS_JSON; }
        }
    }
}
