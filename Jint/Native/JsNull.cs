using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;

namespace Jint.Native {
    /// <summary>
    /// Null type, has only one instance <c>null</c>. The null object can't be extended and has no properties,
    /// it can be casted to boolean value as <c>false</c>, other type convertions rise an <c>InvalidCastException</c>.
    /// </summary>
    [Serializable]
    public class JsNull : IJsObject {
        public static JsNull Instance = new JsNull();

        #region IJsObject Members

        public IJsObject Prototype {
            get { return Instance; }
        }

        public bool Extensible {
            get { return false; }
        }

        public bool IsClr {
            get { return false; }
        }

        public IJsObject Get(string name) {
            return JsUndefined.Instance;
        }

        public void Put(string name, IJsObject value, bool throwError) {
        }

        public bool CanPut(string name) {
            return false;
        }

        public Descriptor GetProperty(string name) {
            return null;
        }

        public Descriptor GetOwnProperty(string name) {
            return null;
        }

        public bool HasProperty(string name) {
            return false;
        }

        public bool Delete(string name, bool throwError) {
            return false;
        }

        public IJsObject DefaultValue() {
            return JsUndefined.Instance;
        }

        public IJsObject DefaultValue(DefaultValueHints hint) {
            return JsUndefined.Instance;
        }

        public bool DefineOwnProperty(Descriptor desc, bool throwError) {
            return false;
        }

        public void ChildNotify() {
            ;
        }

        public void RepopulateProperty(string name) {
            ;
        }

        public IJsObject IndexerGet(IJsObject key) {
            JsUndefined.Instance;
        }

        public void IndexerPut(IJsObject key, IJsObject value) {
        }

        public IEnumerable<IJsObject> CustomEnumerator {
            get { return new IJsObject[0]; }
        }

        #endregion

        #region IJsInstance Members


        public object Value {
            get { null; }
            set { }
        }

        public IJsObject ToPrimitive(IGlobal global) {
            return Instance;
        }

        public string Class {
            get { return JsInstance.CLASS_OBJECT; }
        }

        public JsObjectType Type {
            get { return JsObjectType.Null; }
        }

        public bool IsReference {
            get { return false; }
        }

        public IJsObject BaseObject {
            get { JsUndefined.Instance; }
        }

        public string ReferencedProperty {
            get { return null; }
        }

        public IJsObject GetObject() {
            return Instance;
        }

        public void SetObject(IJsObject value) {
            throw new InvalidOperationException();
        }

        #endregion

        #region IDictionary<string,IJsObject> Members

        public void Add(string key, IJsObject value) {
            ;
        }

        public bool ContainsKey(string key) {
            return false;
        }

        public ICollection<string> Keys {
            get { return new string[0]; }
        }

        public bool Remove(string key) {
            return false;
        }

        public bool TryGetValue(string key, out IJsObject value) {
            value = null;
            return false;
        }

        public ICollection<IJsObject> Values {
            get { return new IJsObject[0]; }
        }

        public IJsObject this[string key] {
            get { return JsUndefined.Instance; }
            set { }
        }

        #endregion

        #region ICollection<KeyValuePair<string,IJsObject>> Members

        public void Add(KeyValuePair<string, IJsObject> item) {
            ;
        }

        public void Clear() {
            ;
        }

        public bool Contains(KeyValuePair<string, IJsObject> item) {
            return false;
        }

        public void CopyTo(KeyValuePair<string, IJsObject>[] array, int arrayIndex) {
            ;
        }

        public int Count {
            get { return 0; }
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
            return new KeyValuePair<string, IJsObject>[0];
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion


        #region IJsObject Members


        public IJsObject DefaultValue(IGlobal global) {
            throw new JsTypeException("Can't get default value for null instance");
        }

        public IJsObject DefaultValue(IGlobal global, DefaultValueHints hint) {
            throw new JsTypeException("Can't get default value for null instance");
        }

        public bool ToBoolean() {
            return false;
        }

        public double ToNumber() {
            return 0;
        }

        public int ToInteger() {
            return 0;
        }

        public uint ToUInt32() {
            return 0;
        }

        public ushort ToUInt16() {
            return 0;
        }

        public IJsObject ToObject(IGlobal global) {
            throw new JsTypeException("A null can't be converted to object");
        }

        public override string ToString() {
            return "null";
        }

        #endregion
    }
}
