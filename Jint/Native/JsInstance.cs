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
            return Value != null ? Value.GetHashCode() : base.GetHashCode();
        }

        public const string CLASS_NULL = "null";
        public const string CLASS_OBJECT = "object";
        public const string CLASS_NUMBER = "number";
        public const string CLASS_STRING = "string";
        public const string CLASS_BOOLEAN = "boolean";
        public const string CLASS_UNDEFINED = "undefined";

        /// <summary>
        /// Result of the typeof operator for functions
        /// </summary>
        public const string TYPEOF_FUNCTION = "function";

        public abstract string Class { get; }

        /// <summary>
        /// This is a shortcut to a function call by name.
        /// </summary>
        /// <remarks>
        /// Since this method requires a visitor it's not a very usefull, so this method is deprecated.
        /// </remarks>
        /// <param name="visitor"></param>
        /// <param name="function"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Obsolete("will be removed in the 1.2 version",true)]
        public virtual object Call(IJintVisitor visitor, string function, params JsInstance[] parameters) {
            if (function == "toString")
                return visitor.Global.StringClass.New(ToString());
            return JsUndefined.Instance;
        }
    }
}
