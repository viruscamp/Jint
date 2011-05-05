using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using System.Diagnostics;

namespace Jint.Native {
    [Serializable]
    public class JsComparer : IComparer<IJsObject> {
        public IFunction Function { get; set; }

        public JsComparer(IFunction function) {
            Function = function;
        }

        public int Compare(IJsObject x, IJsObject y) {
            Debug.Assert(x != null && y != null);
            if (x == JsUndefined.Instance && y == JsUndefined.Instance)
                return 0;
            if (x == JsUndefined.Instance)
                return 1;
            if (y == JsUndefined.Instance)
                return -1;

            if (Function != null)
                return Math.Sign(Function.Invoke(JsUndefined.Instance, new IJsInstance[] { x, y }, null).ToNumber());
            else 
                return Math.Sign(x.ToString().CompareTo(y.ToString()));
        }
    }
}
