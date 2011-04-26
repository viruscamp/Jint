using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Interface for functions
    /// </summary>
    public interface IFunction: IJsObject {

        /// <summary>
        /// Returns a name for a named functions or null for an unnamed
        /// </summary>
        string Name {
            get;
        }

        /// <summary>
        /// A readonly collection of formal arguments
        /// </summary>
        IList<string> Arguments {
            get;
        }

        /// <summary>
        /// A length, usually a number of formal parameters.
        /// </summary>
        int Length {
            get;
        }

        /// <summary>
        /// Invokes the function.
        /// </summary>
        /// <param name="that">An object which will be passed as 'this'. Can be null (treated as <c>JsNull.Instance</c>).</param>
        /// <param name="parameters">A list of parameters, parameters may be passed by reference. Can be null if no parameters.</param>
        /// <param name="callingContext">A current lexical environment in which function is invoked. Can be null.</param>
        /// <returns>A return value of the function.</returns>
        /// <remarks>
        /// Most of functions are ignoring <paramref name="callingContext"/> parameter, but in some cases,
        /// see ecma 262.5 15.3,13.2,10.4.2, this parameter is used. User's implementation of a js
        /// function may also use this parameter. Note, that <paramref name="callingContext"/> can be null
        /// and this case should be treated as calling from a global context.
        /// </remarks>
        IJsObject Invoke(IJsObject that, IJsInstance[] parameters, JsScope callingContext);
    
        /// <summary>
        /// Constructs a new object using this function as a constructor.
        /// </summary>
        /// <param name="parameters">Call parameters</param>
        /// <returns>A created object</returns>
        IJsObject Construct(IJsInstance[] parameters, JsScope callingContext);

        /// <summary>
        /// An object which will be used as prototype for newly constructed objects.
        /// </summary>
        IJsObject PrototypeProperty {
            get;
            set;
        }

        /// <summary>
        /// Tests wheather a specified object is an instance of the current class.
        /// </summary>
        /// <param name="instance">An object to test.</param>
        /// <returns>Returns true if the object is the instance of this class.</returns>
        bool HasInstance(IJsObject instance);
    }

    /// <summary>
    /// Interface for function generics
    /// </summary>
    /// <remarks>
    /// Using three argument form of <c>Invoke</c> or two argument form of <c>Construct</c> methods
    /// may or may not to suggest type parameters.
    /// </remarks>
    public interface IFunctionGeneric : IFunction {

        IJsObject Invoke(IJsObject that, IJsInstance[] parameters, Type[] typeParemeters, JsScope callingContext);
        IJsObject Construct(IJsInstance[] parameters, Type[] typeParameters, JsScope callingContext);
    }
}
