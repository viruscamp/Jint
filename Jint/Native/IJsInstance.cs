using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;

namespace Jint.Native {
    /// <summary>
    /// Object types
    /// </summary>
    public enum JsObjectType {
        Object,
        Boolean,
        String,
        Number,
        Undefined,
        Null
    }

    /// <summary>
    /// A base class for values in javascript.
    /// </summary>
    public interface IJsInstance {

        /// <summary>
        /// Wheather current instance holds a CLR object
        /// </summary>
        bool IsClr { get; }

        /// <summary>
        /// A CLR value which represents current object.
        /// </summary>
        /// <remarks>
        /// For a js Date object this value will be a DateTime instance, for a Number obejct
        /// it will be a Double and so on.
        /// </remarks>
        object Value { get; set; }
        
        /// <summary>
        /// Class of an object, don't confuse with type of an object.
        /// </summary>
        /// <remarks>There are only six object types in the ecma262.3: Undefined, Null, Boolean, String, Number, Object</remarks>
        string Class { get; }

        /// <summary>
        /// A type of a JsObject
        /// </summary>
        JsObjectType Type { get; }

#region reference related methods

        /// <summary>
        /// Flag wheather the specified instance is a reference
        /// </summary>
        bool IsReference {
            get;
        }

        /// <summary>
        /// returns base for this reference, or JsObject.NullInstance otherwise
        /// </summary>
        IJsObject BaseObject {
            get;
        }

        /// <summary>
        /// returns the name of a property from the base object
        /// </summary>
        string ReferencedProperty {
            get;
        }

        /// <summary>
        /// Returns an object pointed by this reference, if this instance is not a refrence
        /// this method simply does a type cast.
        /// </summary>
        /// <returns>A js object</returns>
        IJsObject GetObject();

        /// <summary>
        /// Tries to assing a new value using a reference, if current instance isn't an object
        /// this method should throw an invalid operation exception.
        /// </summary>
        /// <param name="value">A new object</param>
        void SetObject(IJsObject value);
#endregion

    }
}
