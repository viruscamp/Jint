using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public abstract class JsFunctionBase: JsObjectBase, IFunction {
        public const string CONSTRUCTOR = "constructor";
        public const string PROTOTYPE = "prototype";
        public const string ARGUMENTS = "arguments";
        public const string THIS = "this";
        public const string LENGTH = "length";
        public const string CALLER = "caller";
        public const string CALL = "call";
        public const string APPLY = "apply";

        JsDescriptorReference m_prototypeReference;

        public JsFunctionBase(IJsObject prototype)
            : base(prototype) {
            DefineOwnProperty(new NativeValueDescriptor(this, LENGTH, delegate(IJsObject that) { return Length; }), true);
        }

        public static IJsObject[] NormalizeParameters(IJsInstance[] parameters, int length) {
            if (length <= 0)
                return new IJsInstance[0];

            IJsObject[] res = new IJsObject[length];

            if (parameters == null || parameters.Length == 0) {
                for (int i = 0; i < length; i++)
                    res[i] = JsUndefined.Instance;
                return res;
            } else {
                for (int i = 0; i < length; i++)
                    res[i] = i < parameters.Length ? parameters[i].GetObject() : JsUndefined.Instance;
                return res;
            }
        }

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
            get { return JsInstance.CLASS_FUNCTION; }
        }

        #region IFunction Members

        public virtual string Name {
            get { return String.Empty; }
        }

        public abstract IList<string> Arguments {
            get;
        }

        public abstract int Length {
            get;
        }

        public abstract IJsObject Invoke(IJsObject that, IJsInstance[] parameters);

        public abstract IJsObject Construct(IJsInstance[] parameters);

        public IJsObject PrototypeProperty {
            get {
                return m_prototypeReference.GetObject();
            }
            set {
                m_prototypeReference.SetObject(value);
            }
        }

        public bool HasInstance(IJsObject instance) {
            if (instance == null)
                throw new ArgumentNullException("instance");

            IJsObject proto = PrototypeProperty;
            for (IJsObject p = instance.Prototype; p != JsNull.Instance; p = p.Prototype)
                if (p == proto)
                    return true;
            return false;
        }

        public abstract string GetBody();

        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}
