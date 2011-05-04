using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public interface IPrimitiveValue<T>: IJsObject {
        T PrimitiveValue {
            get;
        }
    }

    /// <summary>
    /// A primitive value is a special wrapper around a CLR value, which
    /// inherits properties from the prototype but can't have own ones.
    /// This is a base class to represent Number, Strings, etc.
    /// </summary>
    abstract public class JsPrimitiveValue<T>: IPrimitiveValue<T> {
        IJsObject m_prototype;

        protected JsPrimitiveValue(IJsObject prototype) {
            if (prototype == null)
                throw new ArgumentNullException("prototype");
            m_prototype = prototype;
        }

        protected bool Reject(string msg,bool throwError) {
            if (throwError)
                throw new JsTypeException(msg);
            else
                return false;
        }

        #region IJsObject Members

        public IJsObject Prototype {
            get { return m_prototype; }
        }

        public bool Extensible {
            get { return false; }
        }

        public bool IsClr {
            get { return false; }
        }

        public IJsObject Get(string name) {
            return m_prototype.Get(name);
        }

        public void Put(string name, IJsObject value, bool throwError) {
            Descriptor d = GetProperty(name);

            if (d == null || d.DescriptorType != DescriptorType.Accessor)
                Reject("A primitive value can't have an own property", throwError);

            d.Set(this, value);
        }

        public bool CanPut(string name) {
            Descriptor d = GetProperty(name);

            if (d == null || d.DescriptorType != DescriptorType.Accessor)
                return false;
            return true;
        }

        public Descriptor GetProperty(string name) {
            return m_prototype.GetProperty(name);
        }

        public Descriptor GetOwnProperty(string name) {
            return null;
        }

        public bool HasProperty(string name) {
            return m_prototype.HasProperty(name);
        }

        public bool Delete(string name, bool throwError) {
            return false;
        }

        public bool DefineOwnProperty(Descriptor desc, bool throwError) {
            return Reject("A primitive value can't have an own properties", throwError);
        }

        public void ChildNotify() {
            ;
        }

        public void RepopulateProperty(string name) {
            ;
        }

        public IJsObject IndexerGet(IJsObject key) {
            return Get(key.ToString());
        }

        public void IndexerPut(IJsObject key, IJsObject value) {
            Put(key.ToString(),value,false);
        }

        public IEnumerable<IJsObject> CustomEnumerator {
            get { return m_prototype.CustomEnumerator; }
        }

        public abstract bool ToBoolean();

        public abstract double ToNumber();

        public abstract int ToInteger();

        public abstract uint ToUInt32();

        public abstract ushort ToUInt16();

        public abstract IJsObject ToObject(IGlobal global);

        #endregion

        #region IJsInstance Members


        public abstract object Value {
            get;
            set;
        }

        public IJsObject ToPrimitive(IGlobal global) {
            return this;
        }

        public IJsObject ToPrimitive(IGlobal global, JsObjectType hint) {
            return this;
        }

        public abstract string Class {
            get;
        }

        public abstract JsObjectType Type {
            get;
        }

        public bool IsReference {
            get { return false; }
        }

        public IJsObject BaseObject {
            get { return JsUndefined.Instance; }
        }

        public string ReferencedProperty {
            get { throw new NotImplementedException(); }
        }

        public IJsObject GetObject() {
            return this;
        }

        public void SetObject(IJsObject value) {
            throw new NotImplementedException();
        }

        #endregion

        #region IDictionary<string,IJsObject> Members

        public void Add(string key, IJsObject value) {
            Put(key,value,true);
        }

        public bool ContainsKey(string key) {
            return HasProperty(key);
        }

        public ICollection<string> Keys {
            get { return m_prototype.Keys; }
        }

        public bool Remove(string key) {
            return false;
        }

        public bool TryGetValue(string key, out IJsObject value) {
            value = null;
            Descriptor d = GetProperty(key);
            if (d == null || d.DescriptorType == DescriptorType.None)
                return false;

            value = d.Get(this);
            return true;
        }

        public ICollection<IJsObject> Values {
            get { return m_prototype.Values; }
        }

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

        public void Add(KeyValuePair<string, IJsObject> item) {
            Put(item.Key,item.Value,true);
        }

        public void Clear() {
            ;
        }

        public bool Contains(KeyValuePair<string, IJsObject> item) {
            return m_prototype.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, IJsObject>[] array, int arrayIndex) {
            m_prototype.CopyTo(array,arrayIndex);
        }

        public int Count {
            get { return m_prototype.Count; }
        }

        public bool IsReadOnly {
            get { return true; }
        }

        public bool Remove(KeyValuePair<string, IJsObject> item) {
            return false;
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,IJsObject>> Members

        public IEnumerator<KeyValuePair<string, IJsObject>> GetEnumerator() {
            m_prototype.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region IJsObject Members


        public bool Sealed {
            get { return true; }
        }

        public bool Frozen {
            get { return true; }
        }

        public bool HasOwnProperty(string name) {
            return false;
        }

        public bool IsPrototypeOf(IJsObject other) {
            return false;
        }

        public IEnumerable<Descriptor> GetProperties() {
            return m_prototype.GetProperties();
        }

        public IEnumerable<Descriptor> GetOwnProperties() {
            return new Descriptor[0];
        }

        public void Seal() {
        }

        public void Freeze() {
        }

        public void PreventExtensions() {
        }

        public IJsObject CallMethod(string name, IJsInstance[] parameters) {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid method name", "name");

            IFunction method = m_prototype.Get(name) as IFunction;
            if (method == null)
                throw new JsTypeException(String.Format("The object doesn't have {0} method", name));

            return method.Invoke(this, parameters, null);
        }

        #endregion

        #region IPrimitiveValue<T> Members

        public abstract T PrimitiveValue {
            get;
        }

        #endregion
    }
}
