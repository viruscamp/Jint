using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;

namespace Jint.Native {
    [Serializable]
    public class JsBooleanConstructor : JsConstructor {
        public JsBoolean False { get; private set; }
        public JsBoolean True { get; private set; }

        public JsBooleanConstructor(IGlobal global)
            : base(global) {
            Name = "Boolean";

            DefineOwnProperty(PROTOTYPE, global.ObjectClass.New(this), PropertyAttributes.DontEnum | PropertyAttributes.DontDelete | PropertyAttributes.ReadOnly);

            True = New(true);
            False = New(false);
        }

        public override void InitPrototype(IGlobal global) {
            var Prototype = PrototypeProperty;

            Prototype.DefineOwnProperty("toString", global.FunctionClass.New<JsObjectBase>(ToString2), PropertyAttributes.DontEnum);
            Prototype.DefineOwnProperty("toLocaleString", global.FunctionClass.New<JsObjectBase>(ToString2), PropertyAttributes.DontEnum);
        }

        public JsBoolean New() {
            return New(false);
        }

        public JsBoolean New(bool value) {
            return new JsBoolean(value, PrototypeProperty);
        }

        public override IJsInstance Execute(IJintVisitor visitor, JsObjectBase that, IJsInstance[] parameters) {
            // e.g., var foo = Boolean(true);
            if (that == null || (that as IGlobal) == visitor.Global)
            {
                visitor.Return(parameters.Length > 0 ? new JsBoolean(parameters[0].ToBoolean(), PrototypeProperty) : new JsBoolean(PrototypeProperty));
            }
            else // e.g., var foo = new Boolean(true);
            {
                if (parameters.Length > 0) {
                    that.Value = parameters[0].ToBoolean();
                }
                else {
                    that.Value = false;
                }

                visitor.Return(that);
            }

            return that;
        }


        public IJsInstance ToString2(JsObjectBase target, IJsInstance[] parameters) {
            return Global.StringClass.New(target.ToString());
        }
    }
}
