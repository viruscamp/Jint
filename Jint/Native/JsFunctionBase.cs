using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public abstract class JsFunctionBase: JsObjectBase, IFunction {
        public static string CONSTRUCTOR = "constructor";
        public static string PROTOTYPE = "prototype";
        public static string ARGUMENTS = "arguments";
        public static string THIS = "this";
        public static string LENGTH = "length";
        public static string CALLER = "caller";

        JsDescriptorReference m_prototypeReference;

        public JsFunctionBase(IJsObject prototype)
            : base(prototype) {

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

        public string Name {
            get { throw new NotImplementedException(); }
        }

        public abstract IList<string> Arguments {
            get;
        }

        public abstract int Length {
            get;
        }

        public abstract IJsObject Invoke(IJsObject that, IJsInstance[] parameters);

        public IJsObject Construct(IJsInstance[] parameters) {
            throw new NotImplementedException();
        }

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


        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}
