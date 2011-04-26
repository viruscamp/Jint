using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Represents a function which will be interpreted using an execution visitor.
    /// </summary>
    public class JsFunction : JsFunctionBase {
        string m_name;
        List<string> m_arguments = new List<string>();

        
        IGlobal m_global;
        JsScope m_scope;
        Statement m_body;
        Options m_options;

        /// <summary>
        /// Constructs a new function.
        /// </summary>
        /// <remarks>
        /// This class assumes that global object is initialized and is able to construct a new object.
        /// </remarks>
        /// <param name="global">A global object.</param>
        /// <param name="scope">A function scope.</param>
        /// <param name="body">A function body, can be null.</param>
        /// <param name="options">An ecma script options (es3 ,es5, strict).</param>
        public JsFunction(IGlobal global, JsScope scope, Statement body,IJsObject prototype, Options options) : base(prototype) {
            if (global == null)
                throw new ArgumentNullException("global");
            if (scope == null)
                throw new ArgumentNullException("scope");

            m_global = global;
            m_scope = scope;
            m_body = body;
            m_options = options;

            IJsObject proto = global.ObjectClass.New();

            proto.DefineOwnProperty(new ValueDescriptor(proto, CONSTRUCTOR, this) { Enumerable = false }, true);
            DefineOwnProperty(PROTOTYPE, proto, PropertyAttributes.DontEnum | PropertyAttributes.DontConfigure);

            if (options & Options.Strict) {
                proto.DefineOwnProperty(
                    new NativeAccessorDescriptor(
                        this,
                        CALLER,
                        delegate(IJsObject that) { throw new JsTypeException(); },
                        delegate(IJsObject that, IJsObject v) { throw new JsTypeException(); }
                    ),
                    true
                );
                proto.DefineOwnProperty(
                    new NativeAccessorDescriptor(
                        this,
                        ARGUMENTS,
                        delegate(IJsObject that) { throw new JsTypeException(); },
                        delegate(IJsObject that, IJsObject v) { throw new JsTypeException(); }
                    ),
                    true
                );
            }
        }

        /// <summary>
        /// A special version of method <c>Invoke</c> used when an isnatnce of
        /// the interpreter is known.
        /// </summary>
        /// <param name="that">'this' parameter</param>
        /// <param name="parameters">A list of arguments passsed to the function</param>
        /// <param name="visitor">An instance of the interpreter</param>
        /// <returns>A returned value</returns>
        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters, IJintVisitor visitor) {
            if (visitor == null)
                throw new ArgumentNullException("visitor");

            if (m_body == null)
                return JsUndefined.Instance;

            if ((m_options & Options.Ecmascript3) && ( that == null || that == JsNull.Instance || that == JsUndefined.Instance) )
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
                        ),
                        true
                    );
                else
                    functionScope.DefineOwnProperty(
                        new ValueDescriptor(
                            functionScope,
                            function.Arguments[i],
                            JsUndefined.Instance
                        ),
                        true
                    );

            // define arguments variable
            functionScope[ARGUMENTS] = args;

            // set this variable
            functionScope[THIS] = that;
            
            // enter activation object
            EnterScope(functionScope);

            try {

                m_body.Accept(visitor);

                Debug.Assert(visitor.Returned != null);
                return visitor.Returned;

                // Resets the return flag
                if (exit) {
                    exit = false;
                }
            } finally {
                // return to previous execution state
                ExitScope();
            }
        }

        IJintVisitor GetVisitor() {
            return new ExecutionVisitor(m_global);
        }

        public override string Name {
            get {
                return m_name;
            }
        }

        public override IList<string> Arguments {
            get {
                return m_arguments.AsReadOnly();
            }
        }

        public override int Length {
            get {
                return m_arguments.Count;
            }
        }

        public override IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext) {
            if (m_body == null)
                return JsUndefined.Instance;

            return Invoke(that, parameters, GetVisitor());
        }

        public override IJsObject Construct(IJsInstance[] parameters) {
            IJsObject instance = m_global.ObjectClass.New(this,this.PrototypeProperty);
            IJsObject result;

            if (m_body != null)
                result = Invoke(instance, parameters);
            else
                return instance;

            Debug.Assert(result != null);

            if (result != JsNull.Instance && result != JsUndefined.Instance)
                return result;

            return instance;
        }

        public IJsObject Construct(IJsInstance[] parameters, IJintVisitor visitor) {
            if (visitor == null)
                throw new ArgumentNullException("visitor");

            IJsObject instance = m_global.ObjectClass.New(this, this.PrototypeProperty);
            IJsObject result;

            if (m_body != null)
                result = Invoke(instance, parameters,visitor);
            else
                return instance;

            Debug.Assert(result != null);

            if (result != JsNull.Instance && result != JsUndefined.Instance)
                return result;

            return instance;
        }

        public override string GetBody() {
            return m_body == null ? String.Empty : " /* js code */ " ;
        }
    }
}
