using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;

namespace Jint.Marshal
{
    interface INativeSetterWrapper
    {
        JsSetter GetMethod();
    }

    class NativeSetterWrapper<TThat, TVal>: INativeSetterWrapper
    {
        Marshaller m_marshaller;
        NativeSetter<TThat, TVal> m_method;
        public NativeSetterWrapper(Marshaller marshaller, NativeSetter<TThat, TVal> method)
        {
            if (marshaller == null)
                throw new ArgumentNullException("marshaller");
            if (method == null)
                throw new ArgumentNullException("method");
            m_marshaller = marshaller;
            m_method = method;
        }

        void Invoke(JsDictionaryObject that, JsInstance value)
        {
            m_method(
                m_marshaller.MarshalJsValue<TThat>(that),
                m_marshaller.MarshalJsValue<TVal>(value)
            );
        }

        public JsSetter GetMethod()
        {
            return new JsSetter(this.Invoke);
        }
    }
}
