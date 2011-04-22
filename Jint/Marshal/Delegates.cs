using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;

namespace Jint.Marshal
{
    /// <summary>
    /// A delegate for a native implementation for JsFunction
    /// </summary>
    /// <param name="global">A reference to the global object</param>
    /// <param name="that">A target object</param>
    /// <param name="arguments">A list of arguments</param>
    /// <returns>A result of a function invocation</returns>
    public delegate IJsObject JsMethodImpl(IGlobal global, IJsObject that, IJsInstance[] arguments);

    /// <summary>
    /// A wrapper around native constructor
    /// </summary>
    /// <param name="global">A reference to the global object</param>
    /// <param name="parameters">A list of arguments</param>
    /// <returns>A newly created object</returns>
    public delegate object ConstructorImpl(IGlobal global, IJsInstance[] parameters);

    /// <summary>
    /// A wrapper around native indexer getter
    /// </summary>
    /// <param name="that">A target js object</param>
    /// <param name="index">index</param>
    /// <returns>A value at the specified index</returns>
    public delegate IJsObject JsIndexerGetter(IJsObject that, IJsObject index);

    /// <summary>
    /// A wrapper around native indexer setter
    /// </summary>
    /// <param name="that">A target js object</param>
    /// <param name="index">index</param>
    /// <param name="value">A value which should be set at the specified index</param>
    public delegate void JsIndexerSetter(IJsObject that, IJsObject index, IJsObject value);

}
