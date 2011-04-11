﻿using System;
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
    /// Implements generic property storing mechanism
    /// </remarks>
    [Serializable]
    public abstract class JsObjectBase: IDictionary<string,JsObjectBase>, IJsObject {

        bool m_extensible;
        bool m_hasChidren;
        IJsObject m_prototype;
        IPropertyBag m_properties = new MiniCachedPropertyBag();

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

            m_prototype = prototype;
            m_extensible = true;
            prototype.ChildNotify();
        }

        void internalDefineOwnProperty(Descriptor current, Descriptor desc) {
            Debug.Assert(desc.DescriptorType != DescriptorType.Generic);

            if (current != null && m_hasChidren)
                current.Owner.RepopulateProperty(current.Name);

            if (desc.DescriptorType == DescriptorType.Generic)
                desc = ((GenericDescriptor)desc).ToValueDescriptor();

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

            return GetProperty(name) != null;
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

        public abstract IJsObject DefaultValue();

        public abstract IJsObject DefaultValue(DefaultValueHints hint);

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
                    internalDefineOwnProperty(
                        current,
                        desc.DescriptorType == DescriptorType.Generic ?
                            ((IGenericDescriptor)desc).ToRealDescriptor() :
                            desc
                    );
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
            throw new NotImplementedException();
        }

        public IJsObject IndexerGet(IJsObject key) {
            throw new NotImplementedException();
        }

        public void IndexerPut(IJsObject key, IJsObject value) {
            throw new NotImplementedException();
        }

        public IEnumerable<IJsObject> CustomEnumerator {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #region IJsInstance Members


        public object Value {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public IJsObject ToPrimitive(IGlobal global) {
            throw new NotImplementedException();
        }

        public string Class {
            get { throw new NotImplementedException(); }
        }

        public JsObjectType Type {
            get { throw new NotImplementedException(); }
        }

        public bool IsReference {
            get { throw new NotImplementedException(); }
        }

        public IJsObject BaseObject {
            get { throw new NotImplementedException(); }
        }

        public string ReferencedProperty {
            get { throw new NotImplementedException(); }
        }

        public IJsObject GetObject() {
            throw new NotImplementedException();
        }

        public void SetObject(IJsObject value) {
            throw new NotImplementedException();
        }

        #endregion

        #region IDictionary<string,IJsObject> Members

        public void Add(string key, IJsObject value) {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key) {
            throw new NotImplementedException();
        }

        public ICollection<string> Keys {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(string key) {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out IJsObject value) {
            throw new NotImplementedException();
        }

        public ICollection<IJsObject> Values {
            get { throw new NotImplementedException(); }
        }

        public IJsObject this[string key] {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<KeyValuePair<string,IJsObject>> Members

        public void Add(KeyValuePair<string, IJsObject> item) {
            throw new NotImplementedException();
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, IJsObject> item) {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, IJsObject>[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public int Count {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<string, IJsObject> item) {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,IJsObject>> Members

        public IEnumerator<KeyValuePair<string, IJsObject>> GetEnumerator() {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        #endregion

        #region IConvertible Members

        public TypeCode GetTypeCode() {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        #endregion
    }
}