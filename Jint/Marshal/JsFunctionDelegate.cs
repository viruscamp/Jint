using System;
using System.Collections.Generic;
using System.Text;
using Jint.Native;
using Jint.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Jint.Marshal
{
    class JsFunctionDelegate
    {
        Delegate m_impl;
        IJintVisitor m_visitor;
        JsFunction m_function;
        JsDictionaryObject m_that;
        Type m_delegateType;

        public JsFunctionDelegate(IJintVisitor visitor, JsFunction function, JsDictionaryObject that,Type delegateType)
        {
            if (visitor == null)
                throw new ArgumentNullException("visitor");
            if (function == null)
                throw new ArgumentNullException("function");
            if (delegateType == null)
                throw new ArgumentNullException("delegateType");
            if (!typeof(Delegate).IsAssignableFrom(delegateType))
                throw new ArgumentException("A delegate type is required", "delegateType");
            m_visitor = visitor;
            m_function = function;
            m_delegateType = delegateType;
            m_that = that;
        }

        JsInstance Invoke(JsInstance[] parameters)
        {
            m_visitor.ExecuteFunction(m_function, m_that, parameters);
            return m_visitor.Returned;
        }

        public Delegate GetDelegate()
        {
            if (m_impl!= null)
                return m_impl;

            MethodInfo method = m_delegateType.GetMethod("Invoke");
            DynamicMethod dm = new DynamicMethod(
                "DelegateWrapper",
                method.ReturnType,
                Array.ConvertAll<ParameterInfo, Type>(
                    method.GetParameters(),
                    pi => pi.ParameterType
                )
            );

            ILGenerator code = dm.GetILGenerator();

            return m_impl;
        }
    }
}
