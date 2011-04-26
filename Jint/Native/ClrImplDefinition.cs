using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;
using Jint.Delegates;
using System.Reflection;

namespace Jint.Native {
    /// <summary>
    /// Wraps a delegate which can be called as a method on an object, with or without parameters.
    /// </summary>
    public class ClrImplDefinition<T> : JsFunction
        where T : IJsInstance {
        Delegate impl;
        private int length;
        bool hasParameters;

        private ClrImplDefinition(bool hasParameters, JsObject prototype)
            : base(prototype) {
            this.hasParameters = hasParameters;
        }

        public ClrImplDefinition(Func<T, IJsInstance[], IJsInstance> impl, JsObject prototype)
            : this(impl, -1, prototype) {
        }

        public ClrImplDefinition(Func<T, IJsInstance[], IJsInstance> impl, int length, JsObject prototype)
            : this(true, prototype) {
            this.impl = impl;
            this.length = length;
        }

        public ClrImplDefinition(Func<T, IJsInstance> impl, JsObject prototype)
            : this(impl, -1, prototype) {
        }

        public ClrImplDefinition(Func<T, IJsInstance> impl, int length, JsObject prototype)
            : this(false, prototype) {
            this.impl = impl;
            this.length = length;
        }

        public override IJsInstance Execute(IJintVisitor visitor, JsObjectBase that, IJsInstance[] parameters) {
            try {
                IJsInstance result;
                if (hasParameters)
                    result = impl.DynamicInvoke(new object[] { that, parameters }) as IJsInstance;
                else
                    result = impl.DynamicInvoke(new object[] { that }) as IJsInstance;

                visitor.Return(result);
                return result;
            }
            catch (TargetInvocationException e) {
                throw e.InnerException;
            }
            catch (ArgumentException) {
                var constructor = that["constructor"] as JsFunction;
                throw new JsException(visitor.Global.TypeErrorClass.New("incompatible type: " + constructor == null ? "<unknown>" : constructor.Name));
            }
            catch (Exception e) {
                if (e.InnerException is JsException) {
                    throw e.InnerException;
                }

                throw;
            }
        }

        public override int Length {
            get {
                if (length == -1)
                    return base.Length;
                return length;
            }
        }

        public override string ToString() {
            return String.Format("function {0}() { [native code] }", impl.Method.Name);
        }

    }
}
