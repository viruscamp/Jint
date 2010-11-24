using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using Jint.Marshal;

namespace Jint.Native
{
    /// <summary>
    /// Wraps a single method which is implemented by the delegate
    /// </summary>
    public class NativeMethod: JsFunction {

        MethodInfo m_nativeMethod;
        JsMethodImpl m_impl;

        public NativeMethod(JsMethodImpl impl, MethodInfo nativeMethod , JsObject prototype) :
            base(prototype)
        {
            if (impl == null)
                throw new ArgumentNullException("impl");
            m_nativeMethod = nativeMethod;
            m_impl = impl;
            Name = nativeMethod.Name;
        }

        public NativeMethod(JsMethodImpl impl, JsObject prototype) :
            this(impl,null,prototype)
        {

        }

        public NativeMethod(MethodInfo info, JsObject prototype, IGlobal global) :
            base(prototype)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            if (global == null)
                throw new ArgumentNullException("global");

            m_nativeMethod = info;
            m_impl = global.Marshaller.WrapMethod(info, true);
            Name = info.Name;
        }

        public MethodInfo GetWrappedMethod()
        {
            return m_nativeMethod;
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            visitor.Return( m_impl(visitor.Global, that, parameters) );
            return that;
        }

        public override JsObject Construct(JsInstance[] parameters, Type[] genericArgs, ExecutionVisitor visitor)
        {
            throw new JintException("This method can't be used as a constructor");
        }
    }
    
}
