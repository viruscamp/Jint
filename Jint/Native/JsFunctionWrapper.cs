using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using Jint.Delegates;

namespace Jint.Native {
    public delegate IJsObject JsFunctionImpl(IJsInstance[] arguments);

    [Serializable]
    public class JsFunctionWrapper : JsObjectBase, IFunction {
        JsFunctionImpl m_delegate;
        int m_length;
        string m_name;

        public JsFunctionWrapper(JsFunctionImpl impl,string name, int length, JsObject prototype)
            : base(prototype) {
            if (impl == null)
                throw new ArgumentNullException("impl");
            m_delegate = impl;
            m_length = length;
            m_name = name;
        }

        public override string ToString() {
            return String.Format("function {0}() {{ [native code] }}", Delegate.Method.Name);
        }

        #region IFunction Members

        public string Name {
            get { return String.Empty; }
        }

        public IList<string> Arguments {
            get { return new string[0]; }
        }

        public int Length {
            get { return m_length; }
        }

        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters) {
            m_delegate(parameters);
        }

        public IJsObject Construct(IJsInstance[] parameters) {
            throw new JsTypeException("This function isn't able to construct new objects");
        }

        public IJsObject PrototypeProperty {
            get {
                ;
            }
            set {
                throw new NotImplementedException();
            }
        }

        public bool HasInstance(IJsObject instance) {
            return;
        }

        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
