using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using Jint.Delegates;
using System.Reflection;

namespace Jint.Native {
    public delegate IJsObject JsMethodNoArgsDelegate<TThat>(TThat that) where TThat : IJsObject;
    public delegate IJsObject JsMethodDelegate<TThat>(TThat that,IJsInstance[] arguments) where TThat : IJsObject;

    /// <summary>
    /// Wraps a delegate which can be called as a method on an object, with or without parameters.
    /// </summary>
    /// <remarks>
    /// Resulting object is a function and can't be used as a constructor. It doesn't have 'prototype'
    /// property.
    /// </remarks>
    public class JsMethodWrapper<T> : JsFunctionBase
        where T : IJsObject {
        
        JsMethodDelegate<T> m_impl;
        private int m_length;

        public JsMethodWrapper(JsMethodDelegate<T> impl, int length, JsObject prototype)
            : base(prototype) {
            if (impl == null)
                throw new ArgumentNullException("impl");

            m_impl = impl;
            m_length = length;
        }

        public JsMethodWrapper(JsMethodDelegate<T> impl, JsObject prototype)
            : this(impl,0,prototype) {
        }

        public JsMethodWrapper(JsMethodNoArgsDelegate<T> impl, JsObject prototype)
            : base(prototype) {
            if (impl == null)
                throw new ArgumentNullException("impl");

            m_impl = delegate(T that, IJsInstance[] args) {
                return impl(that);
            };
            m_length = 0;
        }

        public override IList<string> Arguments {
            get { return new string[0]; }
        }

        public override int Length {
            get { return m_length; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters) {
            T target = that as T;
            if (target == null)
                throw new JsTypeException("The function can't be applied to this object");
            return m_impl(target,parameters);
        }

        public override IJsObject Construct(IJsInstance[] parameters) {
            throw new JsTypeException("This function can't be used as a constructor");
        }

        public override string GetBody() {
            return "/* native code */";
        }
    }
}
