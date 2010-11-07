using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native
{
    class ClrOverload : JsFunction
    {
        public ClrOverload(IEnumerable<JsFunction> overloads, JsObject prototype)
            : base(prototype)
        {
        }
    }
}
