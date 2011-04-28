using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using Jint.Marshal;
using Jint.Expressions;

namespace Jint.Native
{
    /// <summary>
    /// Wraps a single method which is implemented by the delegate.
    /// </summary>
    /// <remarks>This class is obsolete. Consider migrating to <c>JsMethodWrapper</c></remarks>
    public class NativeMethod: JsFunctionBase {
        IGlobal m_global;
        MethodInfo m_nativeMethod;
        JsMethodImpl m_impl;

        public NativeMethod(IGlobal global, JsMethodImpl impl, MethodInfo nativeMethod , JsObject prototype) :
            base(prototype)
        {
            if (impl == null)
                throw new ArgumentNullException("impl");
            if (global == null)
                throw new ArgumentException("global");

            m_global = global;
            m_nativeMethod = nativeMethod;
            m_impl = impl;
            if (nativeMethod != null)
            {
                Name = nativeMethod.Name;
                foreach (var item in nativeMethod.GetParameters())
                    Arguments.Add(item.Name);
            }
        }

        public NativeMethod(IGlobal global, JsMethodImpl impl, JsObject prototype) :
            this(global,impl,null,prototype)
        {
            foreach (var item in impl.Method.GetParameters())
                Arguments.Add(item.Name);
        }

        public NativeMethod(IGlobal global, MethodInfo info, JsObject prototype) :
            base(prototype)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            if (global == null)
                throw new ArgumentNullException("global");

            m_global = global;
            m_nativeMethod = info;
            m_impl = global.Marshaller.WrapMethod(info, true);
            Name = info.Name;

            foreach (var item in info.GetParameters())
                Arguments.Add(item.Name);
        }

        public override bool IsClr
        {
            get
            {
                return true;
            }
        }

        public MethodInfo GetWrappedMethod()
        {
            return m_nativeMethod;
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            return m_impl(m_global, that, parameters);
        }

        public override string GetBody()
        {
            return "[native code]";
        }

        public override IList<string> Arguments {
            get { throw new NotImplementedException(); }
        }

        public override int Length {
            get { throw new NotImplementedException(); }
        }

        
    }
    
}
