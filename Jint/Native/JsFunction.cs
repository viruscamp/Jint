using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Represents a function which will be interpreted using an execution visitor.
    /// </summary>
    public class JsFunction : JsConstructor, IJintFunction {
        string m_name;
        List<string> m_arguments;

        
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
        /// <param name="name">A function name, can be null.</param>
        /// <param name="arguments">A list of arguments of the function, can be null.</param>
        /// <param name="prototype">A prototype for this function</param>
        /// <param name="body">A function body, can be null.</param>
        public JsFunction(IGlobal global, JsScope scope, string name,IList<string> arguments, Statement body,IJsObject prototype) : base(prototype) {
            if (global == null)
                throw new ArgumentNullException("global");
            if (scope == null)
                throw new ArgumentNullException("scope");

            m_options = scope.Options;

            m_global = global;
            m_scope = scope;
            m_body = body;

            if (arguments == null)
                m_arguments = new List<string>();
            else
                m_arguments = new List<string>(arguments);

            IJsObject proto = global.ObjectClass.New();

            proto.DefineOwnProperty(new ValueDescriptor(proto, CONSTRUCTOR, this) { Enumerable = false }, true);
            DefineOwnProperty(PROTOTYPE, proto, PropertyAttributes.DontEnum | PropertyAttributes.DontConfigure);

            if (m_options & Options.Strict) {
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
        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters,Type[] typeParameters, IJintVisitor visitor) {
            if (visitor == null)
                throw new ArgumentNullException("visitor");

            if (m_body == null)
                return JsUndefined.Instance;

            if ((m_options & Options.Ecmascript3) && ( that == null || that == JsNull.Instance || that == JsUndefined.Instance) )
                that = m_global;
            else if (that == null)
                that = JsNull.Instance;

            JsScope functionScope = new JsScope(m_scope);
            Descriptor[] links = new Descriptor[Math.Min(m_arguments.Count,parameters.Length)];

            for (int i = 0; i < function.Arguments.Count; i++)
                if (i < parameters.Length) {
                    ValueDescriptor d = new ValueDescriptor(functionScope, m_arguments[i], parameters[i].GetObject());
                    functionScope.DefineOwnProperty(d,true);
                    links[i] = d;
                } else {
                    DefineProperty(functionScope, m_arguments[i], JsUndefined.Instance, PropertyAttributes.None);
                }

            JsArguments args = new JsArguments(m_global, this,links, parameters, m_options & Options.Strict);

            // define arguments variable
            functionScope[ARGUMENTS] = args;

            // set this variable
            functionScope[THIS] = that;
            
            // enter activation object
            visitor.EnterScope(functionScope);

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
                visitor.ExitScope();
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

            return Invoke(that, parameters, null, GetVisitor());
        }

        public IJsObject Construct(IJsInstance[] parameters, JsScope callingContext) {
            IJsObject instance = m_global.ObjectClass.New(this,this.PrototypeProperty);
            IJsObject result;

            if (m_body != null)
                result = Invoke(instance, parameters, callingContext);
            else
                return instance;

            Debug.Assert(result != null);

            if (result != JsNull.Instance && result != JsUndefined.Instance)
                return result;

            return instance;
        }

        public IJsObject Construct(IJsInstance[] parameters, Type[] typeParameters, IJintVisitor visitor) {
            if (visitor == null)
                throw new ArgumentNullException("visitor");

            IJsObject instance = m_global.ObjectClass.New(this, this.PrototypeProperty);
            IJsObject result;

            if (m_body != null)
                result = Invoke(instance, parameters, typeParameters, visitor);
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
