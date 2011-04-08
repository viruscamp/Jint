using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using Jint.Delegates;

namespace Jint.Native {
    [Serializable]
    public class JsFunctionWrapper : JsFunction {
        public Func<IJsInstance[], IJsInstance> Delegate { get; set; }

        public JsFunctionWrapper(Func<IJsInstance[], IJsInstance> d, JsObject prototype)
            : base(prototype) {
            Delegate = d;
        }

        public override IJsInstance Execute(IJintVisitor visitor, JsObjectBase that, IJsInstance[] parameters) {
            try {
                //visitor.CurrentScope["this"] = visitor.Global;
                IJsInstance result = Delegate( parameters );
                visitor.Return(result == null ? JsUndefined.Instance : result);

                return that;
            }
            catch (Exception e) {
                if (e.InnerException is JsException) {
                    throw e.InnerException;
                }

                throw;
            }
        }

        public override string ToString() {
            return String.Format("function {0}() {{ [native code] }}", Delegate.Method.Name);
        }
    }
}
