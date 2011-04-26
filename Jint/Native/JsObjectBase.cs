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
        public virtual IJsObject Get(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetProperty(name);
            if (d == null)
                return JsUndefined.Instance;
            return d.Get(this);
        }

        // 8.12.5
        public virtual void Put(string name, IJsObject value, bool throwError) {
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
            internalDefineOwnProperty(d, new ValueDescriptor(this, name, value));
        }

        // 8.12.4
        public virtual bool CanPut(string name) {
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
        public virtual Descriptor GetProperty(string name) {
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

        public virtual Descriptor GetOwnProperty(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d;

            if (m_properties.TryGet(name, out d) && d.Owner == this) {
                // got own descriptor
                Debug.Assert(!d.isDeleted); // own descriptor can't be marked as deleted since on deletion it will be removed from the object
                return d;
            }
        }

        public virtual bool HasProperty(string name) {
            if (name == null)
                throw new ArgumentNullException("name");

            Descriptor d = GetProperty(name);
            if (d == null || d.DescriptorType == DescriptorType.None)
                return false;
            else
                return true;
        }

        // 8.12.7
        public virtual bool Delete(string name, bool throwError) {
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

        public virtual void RepopulateProperty(string name) {
            Descriptor d;
            m_properties.TryGet(name, out d);
            if (d.Owner == this && !d.isDeleted) {
                m_properties.Put(name, d.Clone());
                d.Delete();
            }
        }

        // 8.12.9
        /// <summary>
        /// Defines own property, see ecma 262.5 8.12.9
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
        public virtual bool DefineOwnProperty(Descriptor desc, bool throwError) {
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

        /// <summary>
        /// Creates a data descriptor and defines own property with it. By default a created property is
        /// configurable, enumerable and writable unless it explicitly specified in <paramref name="attrs"/>.
        /// </summary>
        /// <param name="name">A property name.</param>
        /// <param name="value">A value of a property.</param>
        /// <param name="attrs">A property attributes.</param>
        /// <exception cref="JsTypeException">An operation isn't permited.</exception>
        public void DefineOwnProperty(string name, IJsObject value, PropertyAttributes attrs) {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("A property name should be a not empty string", "name");
            if (value == null)
                throw new ArgumentNullException("value");

            ValueDescriptor d = new ValueDescriptor(this, name, value);
            d.Configurable = !(attrs & PropertyAttributes.DontConfigure);
            d.Writable = !(attrs & PropertyAttributes.ReadOnly);
            d.Enumerable = !(attrs & PropertyAttributes.DontEnum);

            DefineOwnProperty(d, true);
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

        public virtual IEnumerable<Descriptor> GetProperties() {
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

        public virtual IEnumerable<Descriptor> GetOwnProperties() {
            foreach (var d in m_properties.Values)
                if (d.Owner == this && !d.isDeleted && d.DescriptorType != DescriptorType.None)
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
        /// To Primitive conversions, see ecma262.5 9.1, 8.12.8 .
        /// </summary>
        /// <remarks>
        /// Since ecma specification uses <c>valueOf</c> and <c>toString</c> methods
        /// we don't need a 'global' object it's implicitly bound to these functions.
        /// </remarks>
        /// <param name="hint">A desired type</param>
        /// <returns>A corresponding primitive value</returns>
        protected IJsObject internalToPrimitive(JsObjectType hint) {
            IFunction fn1, fn2;
            if (hint == JsObjectType.Number) {
                fn1 = m_valueOfMethod.GetObject() as IFunction;
                fn2 = m_toStringMethod.GetObject() as IFunction;
            } else {
                fn2 = m_valueOfMethod.GetObject() as IFunction;
                fn1 = m_toStringMethod.GetObject() as IFunction;
            }

            IJsObject prim;

            if (fn1 != null) {
                prim = fn1.Invoke(this, null);

                // function should always return a value (at least undefined)
                Debug.Assert(prim != null);
            }

            if ((prim == null || prim.Type == JsObjectType.Object) && fn2 != null) {
                prim = fn2.Invoke(this, null);

                // function should always return a value (at least undefined)
                Debug.Assert(prim != null);
            }

            if (prim == null || prim.Type == JsObjectType.Object)
                throw new JsTypeException("This object can't be converted to a primitive value");

            return prim;
        }

        /// <summary>
        /// To Primitive conversions, see ecma262.5 9.1.
        /// </summary>
        /// <seealso cref="internalToPrimitive"/>
        /// <param name="global">A global object. Not used.</param>
        /// <param name="hint">A desired type</param>
        /// <returns>A new primitive value</returns>
        public virtual IJsObject ToPrimitive(IGlobal global, JsObjectType hint) {
            return internalToPrimitive(hint);
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
            throw new InvalidOperationException();
        }

        #endregion

        #region IDictionary<string,IJsObject> Members

        Dictionary<string, IJsObject> internalGetPairs() {
            Dictionary<string, IJsObject> pairs = new Dictionary<string, IJsObject>();

            foreach (var item in m_prototype)
                pairs[item.Key] = item.Value;

            foreach (var item in GetOwnProperties())
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
            Descriptor d = GetProperty(key);
            if (d == null || d.DescriptorType == DescriptorType.None)
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

            foreach (var d in GetOwnProperties()) {
                visited[d.Name] = true;
                yield return new KeyValuePair<string, IJsObject>(d.Name, d.Get(this));
            }

            foreach(var pair in m_prototype) {
                if (!visited.ContainsKey(pair.Key))
                    yield return pair;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region conversions

        /// <summary>
        /// Convertion to boolean, see ecma 262.5 9.2.
        /// </summary>
        /// <remarks>
        /// Even <c>new Boolean(false)</c> is <c>true</c>.
        /// <code>
        /// var o = new Boolean(false);
        /// var a = Boolean(o); // 'a' will be 'true', this is a feature
        /// var b = Boolean(false); // 'b' will be 'false'
        /// a == true;
        /// o == false;
        /// </code>
        /// </remarks>
        /// <returns></returns>
        public virtual bool ToBoolean() {
            return true;
        }

        public virtual double ToNumber() {
            return internalToPrimitive(JsObjectType.Number).ToNumber();
        }

        public virtual int ToInteger() {
            return internalToPrimitive(JsObjectType.Number).ToInteger();
        }

        public virtual UInt32 ToUInt32() {
            return internalToPrimitive(JsObjectType.Number).ToUInt32();
        }

        public virtual UInt16 ToUInt16() {
            return internalToPrimitive(JsObjectType.Number).ToUInt16();
        }

        public virtual IJsObject ToObject(IGlobal global) {
            return this;
        }

        public override string ToString() {
            return internalToPrimitive(JsObjectType.String).ToString();
        }

        #endregion
    }
}
