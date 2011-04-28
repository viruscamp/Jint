using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;
using System.Reflection;
using Jint.Expressions;

namespace Jint.Native
{
    public class NativeMethodOverload : JsFunctionBase, IFunctionGeneric
    {
        IGlobal m_global;
        NativeOverloadImpl<MethodInfo, JsMethodImpl> m_overloads;

        // a list of methods
        LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
        
        // a list of generics
        LinkedList<MethodInfo> m_generics = new LinkedList<MethodInfo>();

        public NativeMethodOverload(ICollection<MethodInfo> methods , JsObject prototype, IGlobal global)
            : base(prototype)
        {
            if (global == null)
                throw new ArgumentNullException("global");

            m_global = global;
            Marshaller m_marshaller = global.Marshaller;

            foreach (MethodInfo info in methods)
            {
                Name = info.Name;
                break;
            }

            foreach (var method in methods)
            {
                if (method.IsGenericMethodDefinition)
                    m_generics.AddLast(method);
                else if (! method.ContainsGenericParameters)
                    m_methods.AddLast(method);
            }

            m_overloads = new NativeOverloadImpl<MethodInfo, JsMethodImpl>(
                m_marshaller,
                new NativeOverloadImpl<MethodInfo, JsMethodImpl>.GetMembersDelegate(this.GetMembers),
                new NativeOverloadImpl<MethodInfo, JsMethodImpl>.WrapMmemberDelegate(this.WrapMember)
            );
        }

        public override bool IsClr
        {
            get
            {
                return true;
            }
        }

        public override object Value {
            get {
                return true;
            }
            set {
                ;
            }
        }

        protected JsMethodImpl WrapMember(MethodInfo info)
        {
            return m_marshaller.WrapMethod(info,true);
        }

        protected IEnumerable<MethodInfo> GetMembers(Type[] genericArguments, int argCount)
        {
            if (genericArguments != null && genericArguments.Length > 0)
            {

                foreach (var item in m_generics)
                {
                    // try specialize generics
                    if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == argCount)
                    {
                        MethodInfo m = null;
                        try
                        {
                            m = item.MakeGenericMethod(genericArguments);
                        }
                        catch
                        {
                        }
                        if (m != null)
                            yield return m;
                    }
                }
            }

            foreach (var item in m_methods)
            {
                ParameterInfo[] parameters = item.GetParameters();
                if (parameters.Length != argCount)
                    continue;
                yield return item;
            }
        }

        public override string GetBody()
        {
            return " /*native overload*/ ";
        }

        public override IList<string> Arguments {
            get { return new string[0]; }
        }

        public override int Length {
            get { return 0; }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            return Invoke(that,parameters,callingContext);
        }

        #region IFunctionGeneric Members

        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters, Type[] typeParemeters, JsScope callingContext) {
            JsMethodImpl impl;
            if (m_generics.Count == 0)
                impl = m_overloads.ResolveOverload(parameters, null);
            else 
                impl = m_overloads.ResolveOverload(parameters, genericArguments);
            if (impl == null)
                throw new JintException(String.Format("No matching overload found {0}<{1}>", Name, genericArguments));
            return impl(m_global, that, parameters);
        }

        #endregion
    }
}
