using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public enum DefaultValueHints{
        String,
        Number
    }

    /// <summary>
    /// Describes js object specific methods and properties.
    /// </summary>
    /// <remarks>
    /// <para>
    /// ecma 262 8.1-5 defines primitive types, which are not objects (ie they doesn't have any properties),
    /// but in paragraph 8.7 references has some special case for primitive values which turns them to
    /// equivalent objects to resolve properties, therefore we will consider primitive objects as a special
    /// case of usual objects which are not able to store own properties and have a corresponding type
    /// (number, string, etc).
    /// </para>
    /// </remarks>
    public interface IJsObject : IJsInstance, IDictionary<string, IJsObject> {
        /// <summary>
        /// [[Prototype]] property, should be either a valid object or <c>JsNull.Instance</c>.
        /// </summary>
        IJsObject Prototype {
            get;
        }
        
        /// <summary>
        /// [[Extensible]] If true, own properties may be added to the object.
        /// </summary>
        bool Extensible {
            get;
        }

        /// <summary>
        /// If true this instance is a wrapper around a CLR object.
        /// </summary>
        bool IsClr {
            get;
        }

        /// <summary>
        /// Gets a property value.
        /// </summary>
        /// <param name="name">property name.</param>
        /// <returns>property value.</returns>
        IJsObject Get(string name);

        /// <summary>
        /// Stores a property value
        /// </summary>
        /// <param name="name">a property name.</param>
        /// <param name="value">a new value.</param>
        void Put(string name, IJsObject value, bool throwError);

        /// <summary>
        /// Checks whether Put method can be called for a specified property.
        /// </summary>
        /// <param name="name">a property name.</param>
        /// <returns>true if Put operation can be performed for a specified property.</returns>
        bool CanPut(string name);

        /// <summary>
        /// Gets a descriptor for a specified property.
        /// </summary>
        /// <param name="name">a property name.</param>
        /// <returns>a property descriptor</returns>
        Descriptor GetProperty(string name);

        /// <summary>
        /// Gets a descriptor for a specified own property.
        /// </summary>
        /// <param name="name">a property name.</param>
        /// <returns>a property descriptor.</returns>
        Descriptor GetOwnProperty(string name);

        /// <summary>
        /// Checks whether the object has a specified property.
        /// </summary>
        /// <param name="name">a property name.</param>
        /// <returns>true if the object has a property</returns>
        bool HasProperty(string name);

        /// <summary>
        /// Deletes a specfied property .
        /// </summary>
        /// <param name="name">a property name.</param>
        bool Delete(string name, bool throwError);

        /// <summary>
        /// Gets a default value for the object.
        /// </summary>
        /// <returns>a primitive default value</returns>
        IJsObject DefaultValue(IGlobal global);

        /// <summary>
        /// Gets a default value for the object with a hint.
        /// </summary>
        /// <param name="hint">A hint.</param>
        /// <returns>a primitive default value.</returns>
        IJsObject DefaultValue(IGlobal global,DefaultValueHints hint);

        /// <summary>
        /// Defines a new own property using supplied descriptor.
        /// </summary>
        /// <param name="desc">a new property descriptor.</param>
        bool DefineOwnProperty(Descriptor desc, bool throwError);

        /// <summary>
        /// This method called by an objects which derived from this object.
        /// </summary>
        void ChildNotify();

        /// <summary>
        /// Deletes own property and creates its again. Old descriptor will be
        /// marked as abolete and child objects will refresh theirs cache.
        /// </summary>
        /// <param name="name">A property name</param>
        void RepopulateProperty(string name);

        #region custom binders

        /// <summary>
        /// Used to access properties using indexers syntax.
        /// </summary>
        /// <param name="key">an indexer key.</param>
        /// <returns>A value for a specified key</returns>
        IJsObject IndexerGet(IJsObject key);
        
        /// <summary>
        /// Used to put a property using indexers syntax. 
        /// </summary>
        /// <param name="key">an indexer key.</param>
        /// <param name="value">A new value for a specified key.</param>
        void IndexerPut(IJsObject key, IJsObject value);
        
        /// <summary>
        /// Defines a custom enumerator
        /// </summary>
        IEnumerable<IJsObject> CustomEnumerator {
            get;
        }

        /// <summary>
        /// Returns all properties of the object.
        /// </summary>
        /// <returns>Property enumerator</returns>
        IEnumerable<Descriptor> GetProperties();

        /// <summary>
        /// Return only own properties of the obejct.
        /// </summary>
        /// <returns>Property enumerator</returns>
        IEnumerable<Descriptor> GetOwnProperties();
        
        #endregion

        #region conversion routines ecma 262.5 9

        bool ToBoolean();

        double ToNumber();

        int ToInteger();

        UInt32 ToUInt32();

        UInt16 ToUInt16();

        IJsObject ToObject(IGlobal global);

        #endregion
    }
}
