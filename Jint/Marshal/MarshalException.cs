using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Marshal
{
    class MarshalException: JintException
    {
        MarshalException()
            : base()
        {
        }

        MarshalException(string msg)
            : base(msg)
        {
        }

        MarshalException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
