using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native
{
    class NativeArrayIndexer<T>: INativeIndexer
    {
        Marshaller m_marshller;
        public NativeArrayIndexer(Marshaller marshaller)
        {
            if (marshaller == null)
                throw new ArgumentNullException("marshaller");
            m_marshller = marshaller;
        }
        #region INativeIndexer Members

        public IJsObject get(IJsObject that, IJsObject index)
        {
            return m_marshller.MarshalClrValue<T>( m_marshller.MarshalJsValue<T[]>(that)[m_marshller.MarshalJsValue<int>(index)] );
        }

        public void set(IJsObject that, IJsObject index, IJsObject value)
        {
            m_marshller.MarshalJsValue<T[]>(that)[m_marshller.MarshalJsValue<int>(index)] = m_marshller.MarshalJsValue<T>(value);
        }

        #endregion
    }
}
