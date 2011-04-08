using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Jint.Marshal;

namespace Jint.Native
{
    /// <summary>
    /// Represent a set of native overloads to set and get values using indexers.
    /// </summary>
    public class NativeIndexer : INativeIndexer
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
            m_setOverload = new NativeOverloadImpl<MethodInfo, JsIndexerSetter>(
                marshaller,
                delegate(Type[] genericArgs, int Length)
                {
                    return Array.FindAll<MethodInfo>(setters, mi => mi.GetParameters().Length == Length);
                },
                new NativeOverloadImpl<MethodInfo,JsIndexerSetter>.WrapMmemberDelegate(marshaller.WrapIndexerSetter)
            );
        }

        public IJsInstance get(IJsInstance that, IJsInstance index)
        {
            JsIndexerGetter getter = m_getOverload.ResolveOverload(new IJsInstance[] { index }, null);
            if (getter == null)
                throw new JintException("No matching overload found");
            return getter(that, index);
        }

        public void set(IJsInstance that, IJsInstance index, IJsInstance value)
        {
            JsIndexerSetter setter = m_setOverload.ResolveOverload(new IJsInstance[] { index, value }, null);
            if (setter == null)
                throw new JintException("No matching overload found");

            setter(that, index, value);
        }
    }
}
