using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    class JsEmptyFunction: JsConstructor {
        public JsEmptyFunction(IGlobal global, IJsObject prototype)
            : base("Empty", global, prototype) {
            DefineOwnProperty(PROTOTYPE, CreatePrototypeObject(), PropertyAttributes.DontEnum | PropertyAttributes.DontConfigure);
        }

        public override IJsObject Construct(IJsInstance[] parameters, JsScope callingContext) {
            return Global.ObjectClass.New(PrototypeProperty);
        }

        public override int Length {
            get { return 0; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            return JsUndefined.Instance;
        }
    }
}
