using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;

namespace Jint.Native {
    [Serializable]
    public abstract class JsInstance {
        public static JsInstance[] EMPTY = new JsInstance[0];

        public abstract bool IsClr { get; }

        public abstract object Value { get; set; }

        public PropertyAttributes Attributes { get; set; }

        public JsInstance() {
        }

        public virtual JsInstance ToPrimitive(IGlobal global) {
            return JsUndefined.Instance;
        }

        public virtual bool ToBoolean() {
            return true;
        }

        public virtual double ToNumber() {
            return 0;
        }

        public virtual int ToInteger() {
            return (int)ToNumber();
        }

        public virtual object ToObject() {
            return Value;
        }

        public virtual string ToSource() {
            return ToString();
        }

        public override string ToString() {
            return (Value ?? Class).ToString();
        }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public abstract string Class { get; }

        public virtual object Call(IJintVisitor visitor, string function, params JsInstance[] parameters) {
            if (function == "toString")
                return visitor.Global.StringClass.New(ToString());
            return JsUndefined.Instance;
        }
    }
}
