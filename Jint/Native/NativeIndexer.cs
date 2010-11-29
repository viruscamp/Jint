using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Jint.Marshal;

namespace Jint.Native
{
    class NativeIndexer
    {
        NativeOverloadImpl<MethodInfo, JsIndexerGetter> m_getOverload;
        NativeOverloadImpl<MethodInfo, JsIndexerSetter> m_setOverload;

        public NativeIndexer(Marshaller marshaller, MethodInfo[] getters, MethodInfo[] setters)
        {
            m_getOverload = new NativeOverloadImpl<MethodInfo, JsIndexerGetter>(
                marshaller,
                delegate(Type[] genericArgs, int Length)
                {
                    return Array.FindAll<MethodInfo>(getters, mi => mi.GetParameters().Length == Length);
                },
                new NativeOverloadImpl<MethodInfo, JsIndexerGetter>.WrapMmemberDelegate(marshaller.WrapIndexerGetter)
            );
        }

        public JsInstance get(JsInstance that, JsInstance index)
        {
            return JsUndefined.Instance;
        }

        public void set(JsInstance that, JsInstance index, JsInstance value)
        {

        }
    }
}
