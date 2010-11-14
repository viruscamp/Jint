using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;

namespace Jint.Marshal
{
    interface INativeGetterWrapper
    {
        JsGetter GetMethod();
    }

    class NativeGetterWrapper<TThat, TVal>: INativeGetterWrapper
    {
        Marshaller m_marshaller;
        NativeGetter<TThat, TVal> m_method;
        public NativeGetterWrapper(Marshaller marshaller, NativeGetter<TThat, TVal> method)
        {
            if (marshaller == null)
                throw new ArgumentNullException("marshaller");
            if (method == null)
                throw new ArgumentNullException("method");
            m_marshaller = marshaller;
            m_method = method;
        }

        JsInstance Invoke(JsDictionaryObject that)
        {
            return m_marshaller.MarshalClrValue<TVal>(
                m_method(
                    m_marshaller.MarshalJsValue<TThat>(that)
                )
            );
        }

        public JsGetter GetMethod()
        {
            return new JsGetter(this.Invoke);
        }
    }
}
