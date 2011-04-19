using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;

namespace Jint.Native {
    [Serializable]
    public class JsFunction : JsObjectBase, IFunction {

        string m_name;
        List<string> m_arguments = new List<string>();

        IGlobal m_global;
        JsScope m_scope;
        Statement m_body;
        Options m_options;

        /// <summary>
        /// A special version of method <c>Invoke</c> used when an isnatnce of
        /// the interpreter is known.
        /// </summary>
        /// <param name="that">'this' parameter</param>
        /// <param name="parameters">A list of arguments passsed to the function</param>
        /// <param name="visitor">An instance of the interpreter</param>
        /// <returns>A returned value</returns>
        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters, IStatementVisitor visitor) {

        }

        IStatementVisitor GetVisitor() {
            return new ExecutionVisitor(m_options);
        }

        #region IFunction Members

        public string Name {
            get {
                return m_name;
            }
        }

        public IList<string> Arguments {
            get {
                return m_arguments.AsReadOnly();
            }
        }

        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters) {
            if ((m_options & Options.Ecmascript3) && that == null || that == JsNull.Instance || that == JsUndefined.Instance)
                that = m_global;
            else if (that == null)
                that = JsNull.Instance;

            JsArguments args = new JsArguments(m_global, this, parameters);

            JsScope functionScope = new JsScope(m_scope);

            for (int i = 0; i < function.Arguments.Count; i++)
                if (i < parameters.Length)
                    functionScope.DefineOwnProperty(
                        new LinkedDescriptor(
                            functionScope,
                            function.Arguments[i],
                            args.GetDescriptor(i.ToString()),
                            args
                        )
                    );
                else
                    functionScope.DefineOwnProperty(
                        new ValueDescriptor(
                            functionScope,
                            function.Arguments[i],
                            JsUndefined.Instance
                        )
                    );

            // define arguments variable
            if (HasOption(Options.Strict))
                functionScope.DefineOwnProperty(JsScope.ARGUMENTS, args);
            else
                args.DefineOwnProperty(JsScope.ARGUMENTS, args);

            // set this variable
            if (that != null)
                functionScope.DefineOwnProperty(JsScope.THIS, that);
            else
                functionScope.DefineOwnProperty(JsScope.THIS, that = Global as JsObject);

            // enter activation object
            EnterScope(functionScope);

            try {
                PermissionSet.PermitOnly();

                if (genericParameters != null && genericParameters.Length > 0)
                    Result = function.Execute(this, that, parameters, genericParameters);
                else
                    Result = function.Execute(this, that, parameters);

                // Resets the return flag
                if (exit) {
                    exit = false;
                }
            } finally {
                // return to previous execution state
                ExitScope();

                CodeAccessPermission.RevertPermitOnly();
                recursionLevel--;
            }
        }

        public IJsObject Construct(IJsInstance[] parameters) {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
