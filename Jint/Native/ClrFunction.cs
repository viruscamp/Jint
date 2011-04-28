using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.ObjectModel;

namespace Jint.Native {
    /// <summary>
    /// Wraps native function, i.e. 'this' parameter from the js calling context will be ommited
    /// </summary>
    [Serializable]
    public class ClrFunction : JsFunctionBase {
        Delegate m_delegate;
        ParameterInfo[] m_parametersInfo;
        string[] m_parameterNames;
        IGlobal Global;

        public ClrFunction(IGlobal global, Delegate d, JsObject prototype)
            : base(prototype) {

            if (global == null)
                throw new ArgumentNullException("global");

            m_delegate = d;
            m_parametersInfo = d.Method.GetParameters();
            m_parameterNames = new string[m_parametersInfo.Length];
            Global = global;
            
            for (int i = 0; i < m_parametersInfo.Length; i++)
                m_parameterNames[i] = m_parametersInfo[i].Name;
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            if (m_delegate == null)
                return JsUndefined.Instance;

            int clrParameterCount = m_parametersInfo.Length;
            object[] clrParameters = new object[clrParameterCount];

            // TODO: optimize
            for (int i = 0; i < parameters.Length; i++) {
                // First see if either the JsInstance or it's value can be directly accepted without converstion
                if (m_parametersInfo[i].ParameterType.Equals(typeof(IJsInstance))) {
                    clrParameters[i] = parameters[i];
                } else if(m_parametersInfo[i].ParameterType.Equals(typeof(IJsObject))) {
                    clrParameters[i] = parameters[i].GetObject();
                } else if (m_parametersInfo[i].ParameterType.IsInstanceOfType(parameters[i].Value)) {
                    clrParameters[i] = parameters[i].Value;
                } else {
                    clrParameters[i] = Global.Marshaller.MarshalJsValue<object>(parameters[i]);
                }
            }

            object result;

            try {
                result = m_delegate.DynamicInvoke(clrParameters);
            }
            catch (TargetInvocationException e) {
                throw e.InnerException;
            }
            catch (Exception e) {
                if (e.InnerException is JsException) {
                    throw e.InnerException;
                }
                throw;
            }

            if (result != null) {
                // Don't wrap if the result should be a JsInstance
                if (result is IJsObject) {
                    return (IJsObject)result;
                }
                else {
                    return Global.Marshaller.MarshalClrValue(result);
                }
            }
            else {
                return JsNull.Instance;
            }
        }

        public override string Name {
            get {
                return m_delegate.Method.Name;
            }
        }

        public override IList<string> Arguments {
            get { return new ReadOnlyCollection<string>(m_parameterNames) ; }
        }

        public override int Length {
            get { m_parameterNames.Length; }
        }

        public override string GetBody() {
            return " /* native code */ ";
        }
    }
}
