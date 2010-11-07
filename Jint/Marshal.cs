using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;

namespace Jint
{
    /// <summary>
    /// Marshals clr objects to js objects and back
    /// </summary>
    /// <remarks>
    /// <pre>
    ///     Automaticly discovers a prototype of a clr object, and caches this information.
    /// </pre>
    /// <pre>
    ///     Also discovers an object constructors, and creates an appropriate constructor function.
    /// </pre>
    /// <pre>
    ///     A native clr function can be a generic and may have some overloads, all this members
    ///     with a same name are transformed to a single function object.
    /// </pre>
    /// <pre>
    ///     A clr types are marshalled to functions. Js functions marshaled to the delegates
    /// </pre>
    /// </remarks>
    public class Marshal
    {
        IGlobal global;

        public Marshal(IGlobal global)
        {
            this.global = global;
        }

        public JsInstance ClrToJsValue<T>(T value)
        {
            return global.WrapClr(value);
        }

        
        public T JsToClrValue<T>(JsInstance value)
        {
            return (T)Convert.ChangeType(value.Value, typeof(T));
        }
    }
}
