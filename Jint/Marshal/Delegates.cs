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
    public delegate JsInstance JsMethodImpl(IGlobal global, JsInstance that, JsInstance[] arguments);

    /// <summary>
    /// A wrapper around native constructor
    /// </summary>
    /// <param name="global">A reference to the global object</param>
    /// <param name="parameters">A list of arguments</param>
    /// <returns>A newly created object</returns>
    public delegate object ConstructorImpl(IGlobal global, JsInstance[] parameters);

    /// <summary>
    /// A wrapper around native property getter
    /// </summary>
    /// <param name="that">A target object</param>
    /// <returns>A value of a property</returns>
    public delegate JsInstance JsGetter(JsDictionaryObject that);

    /// <summary>
    /// A wrapper around native property setter
    /// </summary>
    /// <param name="that">A target object</param>
    /// <param name="value">A new value for the property</param>
    public delegate void JsSetter(JsDictionaryObject that, JsInstance value);

    /// <summary>
    /// A delegate representing a property getter for a reference type
    /// </summary>
    /// <typeparam name="TTarget">A type of a target object</typeparam>
    /// <typeparam name="TVal">A type of a property</typeparam>
    /// <param name="that">A target object</param>
    /// <returns>A value of a property</returns>
    public delegate TVal NativeGetter<TTarget, TVal>(TTarget that);

    /// <summary>
    /// A delegate representing a property getter for a value type
    /// </summary>
    /// <typeparam name="TTarget">A type of a target object</typeparam>
    /// <typeparam name="TVal">A type of a property</typeparam>
    /// <param name="that">A target object</param>
    /// <returns>A value of a property</returns>
    public delegate TVal NativeGetterByRef<TTarget, TVal>(ref TTarget that);

    /// <summary>
    /// A delegate representing a property setter for a reference types
    /// </summary>
    /// <typeparam name="TTarget">A type of a target object</typeparam>
    /// <typeparam name="TVal">A type of a property</typeparam>
    /// <param name="that">A target object</param>
    /// <param name="value">A value of a property</param>
    public delegate void NativeSetter<TTarget, TVal>(TTarget that, TVal value);

    /// <summary>
    /// A delegate representing a property setter for a value types
    /// </summary>
    /// <typeparam name="TTarget">A type of a target object</typeparam>
    /// <typeparam name="TVal">A type of a property</typeparam>
    /// <param name="that">A target object</param>
    /// <param name="value">A value of a property</param>
    public delegate void NativeSetterByRef<TTarget, TVal>(ref TTarget that, TVal value);

    public delegate void StaticNativeSetter<TVal>(TVal value);

    public delegate TVal StaticNativeGetter<TVal>();

}
