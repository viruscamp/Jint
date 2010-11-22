﻿using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;
using System.Reflection;

namespace Jint.Native
{
    public class ClrOverload : JsFunction
    {

        

        class MethodMatch
        {
            public MethodInfo method;
            public int weight;
            public Type[] parameters;
        }

        Marshaller m_marshaller;
        ClrOverloadBase<MethodInfo, JsMethodImpl> m_overloads;

        // a list of methods
        LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
        
        // a list of generics
        LinkedList<MethodInfo> m_generics = new LinkedList<MethodInfo>();

        public ClrOverload(ICollection<MethodInfo> methods , JsObject prototype, IGlobal global)
            : base(prototype)
        {
            if (global == null)
                throw new ArgumentNullException("global");
            m_marshaller = global.Marshaller;

            foreach (var method in methods)
            {
                if (method.IsGenericMethodDefinition)
                    m_generics.AddLast(method);
                else if (! method.ContainsGenericParameters)
                    m_methods.AddLast(method);
            }

            m_overloads = new ClrOverloadBase<MethodInfo, JsMethodImpl>(
                m_marshaller,
                new ClrOverloadBase<MethodInfo, JsMethodImpl>.GetMembersDelegate(this.GetMembers),
                new ClrOverloadBase<MethodInfo, JsMethodImpl>.WrapMmemberDelegate(this.WrapMember)
            );
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            JsMethodImpl impl = m_overloads.ResolveOverload(parameters, null);
            if (impl == null)
                throw new JintException("No matching overload found");
            visitor.Return(impl(visitor.Global,that,parameters));
            return that;
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
    }
}
