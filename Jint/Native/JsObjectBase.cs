using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Jint.Expressions;
using Jint.PropertyBags;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// Base class for a JsObject class.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implements generic property storing mechanism.
    /// </para>
    /// <para>
    /// Not that this object also behaves like a dictionary collection, but this collection
    /// behaves like JS object rather than a regular dictionary. For example method <c>Clear()</c>
    /// deletes only own properties, therefore a collection will remain not empty.
    /// </para>
    /// <para>
    /// Enumeration is avalibale only through
    /// </para>
    /// </remarks>
    [Serializable]
    public abstract class JsObjectBase: IJsObject {

        bool m_extensible;
        bool m_hasChidren;
        IJsObject m_prototype;
        IPropertyBag m_properties = new MiniCachedPropertyBag();
        JsDescriptorReference m_toStringMethod;
        JsDescriptorReference m_valueOfMethod;

        /// <summary>
        /// Creates new Object without prototype
        /// </summary>
        public JsObjectBase(): this(JsNull.Instance) {
        }

        /// <summary>
        /// Creates new object with an specified prototype
        /// </summary>
        /// <param name="prototype">Prototype</param>
        public JsObjectBase(IJsObject prototype) {
            if (prototype == null)
                throw new ArgumentNullException("prototype");

            m_toStringMethod = new JsDescriptorReference(this, "toString");
            m_valueOfMethod = new JsDescriptorReference(this, "valueOf");

            m_prototype = prototype;
            m_extensible = true;
            prototype.ChildNotify();
        }

        /// <summary>
        /// Adds a specified descriptor to properties of the current object.
        /// </summary>
        /// <remarks>
        /// If there were a descriptor (own or cached) in the object it will be replaced
        /// by the new one. If this object is used as a prototype for the other object and
        /// a previous descriptor was cached from the prototype of the current object it
        /// (the previous descriptor) will be repopulated. If the previous descriptor was
        /// an own descriptor of the current obbject it will be marked as deleted.
        /// </remarks>
        /// <param name="current">A previous descriptor.</param>
        /// <param name="desc">A new descriptor.</param>
        protected void internalDefineOwnProperty(Descriptor current, Descriptor desc) {
            Debug.Assert(desc.DescriptorType != DescriptorType.Generic);

            if (current != null) {
                if (current.Owner == this) {
                    current.Delete(); // if we are redefining an own property
                }  else if (m_hasChidren)
                    current.Owner.RepopulateProperty(current.Name); // repopulate cached descriptor
            }

            if (desc.DescriptorType == DescriptorType.Generic)
                desc = ((IGenericDescriptor)desc).ToRealDescriptor();

            m_properties.Put(desc.Name, desc);
        }

        protected static bool Reject(string message, bool throwError) {
            if (throwError)
                throw new JsTypeException(message);
            else
                return false;
        }

        #region IJsObject Members

        public IJsObject Prototype {
            get { return m_prototype; }
        }

        public bool Extensible {
            get { return m_extensible; }
        }

        public abstract bool IsClr {
            get;
        }

        // 8.12.3
        public IJsObject Get(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetProperty(name);
            if (d == null)
                return JsUndefined.Instance;
            return d.Get(this);
        }

        // 8.12.5
        public void Put(string name, IJsObject value, bool throwError) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetProperty(name);

            // this is own writable property or writable accessor
            // we don't check DescriptorType here since DescriptorType.None isn't writable
            if (d != null) {
                if (d.Owner == this) {
                    
                    if (d.Writable)
                        d.Set(this, value);
                    else
                        Reject(String.Format("A property {0} isn't writable", name),throwError);

                } else if (d.DescriptorType == DescriptorType.Accessor) {
                    if (d.Writable) {
                        d.Set(this, value);
                        return;
                    }
                }
            }

            // the property is absent or inherited value property
            if (!m_extensible)
                Reject(String.Format("Can't define a new own property {0}, object isn't extensible", name),throwError);

            // optimized version of DefineOwnProperty
            internalDefineOwnProperty(d,new ValueDescriptor(this, name, value));
        }

        // 8.12.4
        public bool CanPut(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetProperty(name);

            // this is own writable property or writable accessor
            // we don't check DescriptorType since DescriptorType.None isn't writable
            if (d != null) {
                if (d.Owner == this)
                    return d.Writable;
                else if (d.DescriptorType == DescriptorType.Accessor)
                    return d.Writable || m_extensible;
            }

            // the property is absent or inherited value property
            return m_extensible;
        }

        // 8.12.2
        public Descriptor GetProperty(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d;

            if (m_properties.TryGet(name, out d)) {
                // got own or cached descriptor
                if (!d.isDeleted) // the descritor is actual
                    return d;
                else
                    m_properties.Delete(d.Name);
            }

            // a descriptor not found or absolute
            d = m_prototype.GetProperty(name);

            // cache descriptor
            if (d != null)
                m_properties.Put(d.Name, d);
            return d;
        }

        public Descriptor GetOwnProperty(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d;

            if (m_properties.TryGet(name, out d) && d.Owner == this) {
                // got own descriptor
                Debug.Assert(!d.isDeleted);
                return d;
            }
        }

        public bool HasProperty(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetProperty(name);
            if (d == null || d.DescriptorType == DescriptorType.None)
                return false;
            else
                return true;
        }

        // 8.12.7
        public bool Delete(string name, bool throwError) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetOwnProperty(name);

            if (d == null)
                return true;

            if (!d.Configurable)
                return Reject(String.Format("A property {0} isn't configurable", name),throwError);

            m_properties.Delete(d.Name); // remove from object
            d.Delete(); // mark as absolete
        }

        public void RepopulateProperty(string name) {
            Descriptor d;
            m_properties.TryGet(name, out d);
            if (d.Owner == this && !d.isDeleted) {
                m_properties.Put(name, d.Clone());
                d.Delete();
            }
        }

        // 8.12.9
        /// <summary>
        /// Implementation of ecma 262.5 8.12.9
        /// </summary>
        /// <param name="desc">A new property descriptor</param>
        /// <param name="throwError">If true, this method will throw an exception in case of error</param>
        /// <returns>True on success, false otherwise</returns>
        /// <remarks>
        /// <para>
        /// Only descriptors with <c>DescriptorType</c> <c>DescriptorType.Generic</c> can be used to update
        /// existing descriptors, all other descriptors will replace current once.
        /// </para>
        /// <para>
        /// If a descriptor can't be updated, than merge should return false and the descriptor will be
        /// replaced by the new descriptor which will be created by calling <c>IGenericDescriptor.ToRealDescritor</c>.
        /// If Configurable attribute of the original descriptor is false, then operation will be rejected.
        /// </para>
        /// <para>
        /// A <c>Merge</c> method of the descriptor should also check the own Configurable property to decide
        /// whether to apply or reject modifications. In case of when mofications are rejected the descriptor
        /// should stay in its original state.
        /// </para>
        /// </remarks>
        public bool DefineOwnProperty(Descriptor desc, bool throwError) {
            if (desc == null)
                throw new ArgumentNullException("desc");

            Debug.Assert(desc.Owner == this);

            Descriptor current = m_properties.Get(desc.Name);

            if (current == null || current.Owner != this) {
                // we haven't own property
                if (!m_extensible) {
                    // object isn't extensible
                    return Reject(String.Format("Can't define a new own property {0}, object isn't extensible", desc.Name), throwError);
                } else {
                    internalDefineOwnProperty(current,desc);
                }
            } else {
                if (desc.DescriptorType != DescriptorType.Generic) {
                    if (!current.Configurable)
                        return Reject(String.Format("Can't update a property {0}, it's not configurable", desc.Name), throwError);
                } else {
                    if (!current.Merge(desc)) {
                        if (!current.Configurable)
                            return Reject(String.Format("Can't update a property {0}, it's not configurable", desc.Name), throwError);
                        else
                            internalDefineOwnProperty(current,((IGenericDescriptor)desc).ToRealDescriptor(true,current.Enumerable));
                    }
                }
            }
            return true;
        }

        public void ChildNotify() {
            m_hasChidren = true;
        }

        public virtual IJsObject IndexerGet(IJsObject key) {
            return Get(key.ToString());
        }

        public virtual void IndexerPut(IJsObject key, IJsObject value) {
            Put(key.ToString(),value,false);
        }

        public virtual IEnumerable<IJsObject> CustomEnumerator {
            get { return null; }
        }

        public IEnumerable<Descriptor> GetProperties() {
            Dictionary<string, bool> visited = new Dictionary<string, bool>();

            foreach (var d in GetOwnProperties()) {
                visited[d.Name] = true;
                yield return d;
            }

            foreach (var d in m_prototype.GetProperties()) {
                if (!visited.ContainsKey(d.Name)) {
                    visited[d.Name] = true;
                    yield return d;
                }
            }
        }

        public IEnumerable<Descriptor> GetOwnProperties() {
            foreach (var d in m_properties.Values)
                if (d.Owner == this)
                    yield return d;
        }

        #endregion

        #region IJsInstance Members


        public abstract object Value {
            get;
            set;
        }

        public virtual IJsObject ToPrimitive(IGlobal global) {
            return ToPrimitive(global, JsObjectType.Number);
        }

        /// <summary>
        /// ecma 8.12.8
        /// </summary>
        /// <param name="global"></param>
        /// <param name="hint"></param>
        /// <returns></returns>
        public virtual IJsObject ToPrimitive(IGlobal global, JsObjectType hint) {
            IFunction fn;
            if (hint == JsObjectType.Number)
                fn = m_valueOfMethod.GetObject() as IFunction;

            IJsObject prim;
            if (fn != null)
                prim = fn.Invoke(this, null);

            // if result isn't a primitive or valueOf isn't a function
            if (prim == null || prim.Type == JsObjectType.Object)
                fn = m_toStringMethod.GetObject() as IFunction;

            if (fn == null)
                throw new JsTypeException("This object can't be converted to a primitive value");

            prim = fn.Invoke(this, null);

            // function should always return a value
            Debug.Assert(prim != null);

            if (prim.Type == JsObjectType.Object)
                throw new JsTypeException("This object can't be converted to a primitive value");

            return prim;
        }

        public abstract string Class {
            get;
        }

        public JsObjectType Type {
            get {
                return JsObjectType.Object;
            }
        }

        public bool IsReference {
            get { return false; }
        }

        public IJsObject BaseObject {
            get { return JsUndefined.Instance; }
        }

        public string ReferencedProperty {
            get { return String.Empty; }
        }

        public IJsObject GetObject() {
            return this;
        }

        public void SetObject(IJsObject value) {
            // TODO: use appropriate exception
            throw new NotImplementedException();
        }

        #endregion

        #region IDictionary<string,IJsObject> Members

        Dictionary<string, IJsObject> internalGetPairs() {
            Dictionary<string, IJsObject> pairs = new Dictionary<string, IJsObject>();

            foreach (var item in m_prototype)
                pairs[item.Key] = item.Value;

            foreach (var item in m_properties.Values)
                if (item.Enumerable)
                    pairs[item.Name] = item.Get(this);

            return pairs;
        }

        /// <summary>
        /// Adds a new item to the dectionary, synonim for <c>Put</c> method.
        /// </summary>
        /// <param name="key">A property name.</param>
        /// <param name="value">A value</param>
        public void Add(string key, IJsObject value) {
            Put(key,value,true);
        }

        /// <summary>
        /// Same as <c>HasProperty</c>.
        /// </summary>
        /// <param name="key">A property name.</param>
        /// <returns>True if object has a specified property.</returns>
        public bool ContainsKey(string key) {
            return HasProperty(key);
        }

        /// <summary>
        /// Returns a collection of keys (property names), only enumerble properties are included.
        /// </summary>
        public ICollection<string> Keys {
            get {
                var pairs = internalGetPairs();
                return pairs.Keys;
            }
        }

        /// <summary>
        /// Removes a property from the object.
        /// </summary>
        /// <remarks>
        /// Removes only own properties.
        /// </remarks>
        /// <param name="key">A property name.</param>
        /// <returns>True if property was removed.</returns>
        public bool Remove(string key) {
            if (GetOwnProperty(key) == null)
                return false;
            return Delete(key,false);
        }

        /// <summary>
        /// Gets a value of a specified property.
        /// </summary>
        /// <param name="key">A property name.</param>
        /// <param name="value">A value</param>
        /// <returns>
        /// True if property exists, false otherwise.
        /// In contrast to <c>Get</c> method, in case of fail <paramref name="value"/>
        /// parameter will be <c>null</c>, rather than <c>JsUndefined.Instance</c>
        /// </returns>
        public bool TryGetValue(string key, out IJsObject value) {
            value = null;
            Descriptor d = GetProperty(key);
            if (d == null || d.DescriptorType == DescriptorType.None)
                return false;
            else {
                value = d.Get(this);
                return true;
            }
        }

        /// <summary>
        /// Returns a collection of values of properties. Only enumerable properties are returned.
        /// </summary>
        public ICollection<IJsObject> Values {
            get {
                var pairs = internalGetPairs();
                return pairs.Values;
            }
        }

        /// <summary>
        /// Indexer, uses <c>Get</c> and <c>Put</c> methods to store and
        /// retrieve values.
        /// </summary>
        /// <param name="key">A property name</param>
        /// <returns>A property value or <c>JsUndefined.Instance</c></returns>
        public IJsObject this[string key] {
            get {
                return Get(key);
            }
            set {
                Put(key,value,true);
            }
        }

        #endregion

        #region ICollection<KeyValuePair<string,IJsObject>> Members

        /// <summary>
        /// Adds a property with name and value from a specified pair.
        /// </summary>
        /// <param name="item">A pair or key and value</param>
        public void Add(KeyValuePair<string, IJsObject> item) {
            Put(item.Key,item.Value,true);
        }

        /// <summary>
        /// This method isn't implemented since we can't delete inherited properties,
        /// and therefore can't completely clear the object.
        /// </summary>
        public void Clear() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Test wheather the object has a specified property with a specified value.
        /// </summary>
        /// <param name="item">A pair of the property name and the value.</param>
        /// <returns>True if a desired property exists and its value equals the specified value.</returns>
        public bool Contains(KeyValuePair<string, IJsObject> item) {
            if (item == null)
                throw new ArgumentNullException("item");
            return Get(item.Key).Equals(item.Value);
        }

        /// <summary>
        /// Copies a collection of pairs to the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<string, IJsObject>[] array, int arrayIndex) {
            if (array == null)
                throw new ArgumentNullException("array");

            ICollection<KeyValuePair<string, IJsObject>> pairs = internalGetPairs();
            pairs.CopyTo(array,arrayIndex);
        }

        public int Count {
            get { internalGetPairs().Count; }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, IJsObject> item) {
            if (item == null)
                throw new ArgumentNullException("item");

            if (Get(item.Key).Equals(item.Value))
                return Delete(item.Key,false);
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,IJsObject>> Members

        public IEnumerator<KeyValuePair<string, IJsObject>> GetEnumerator() {
            Dictionary<string,bool> visited = new Dictionary<string,bool>();

            foreach(var pair in m_prototype) {
                visited[pair.Key] = true;
                yield return pair;
            }

            foreach (var d in m_properties.Values)
                if (d.Owner == this && d.Enumerable && !visited.ContainsKey(d.Name))
                    yield return new KeyValuePair<string, IJsObject>(d.Name, d.Get(this));
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region conversions

        public abstract bool ToBoolean();

        public abstract double ToNumber();

        public abstract int ToInteger();

        public abstract UInt32 ToUInt32();

        public abstract UInt16 ToUInt16();

        public IJsObject ToObject(IGlobal global) {
            return this;
        }

        #endregion
    }
}
