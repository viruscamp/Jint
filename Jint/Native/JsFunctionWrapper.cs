using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using Jint.Delegates;

namespace Jint.Native {
    public delegate IJsObject JsFunctionDelegate(IJsInstance[] arguments);

    [Serializable]
    public class JsFunctionWrapper : JsFunctionBase {
        JsFunctionDelegate m_delegate;
        int m_length;
        string m_name;

        public JsFunctionWrapper(JsFunctionDelegate impl,string name, int length, JsObject prototype)
            : base(prototype) {
            if (impl == null)
                throw new ArgumentNullException("impl");
            m_delegate = impl;
            m_length = length;
            m_name = name;
        }



        public override IList<string> Arguments {
            get { return new string[0]; }
        }

        public override int Length {
            get { return m_length; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters) {
            return m_delegate(parameters);
        }

        public override IJsObject Construct(IJsInstance[] parameters) {
            throw new JsTypeException("This function can't be used as a constructor");
        }

        public override string GetBody() {
            return "/* native code */";
        }
    }
}
