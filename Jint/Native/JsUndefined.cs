using System;
using System.Collections.Generic;
using System.Text;
using Jint.Delegates;

namespace Jint.Native {
    [Serializable]
    public class JsUndefined : IJsObject {
        public static JsUndefined Instance = new JsUndefined();

        private JsUndefined() {
        }

        #region IJsObject Members

        public IJsObject Prototype {
            get { return JsNull.Instance; }
        }

        public bool Extensible {
            get { return false; }
        }

        public bool IsClr {
            get { return false; }
        }

        public IJsObject Get(string name) {
            return Instance;
        }

        public void Put(string name, IJsObject value, bool throwError) {
            ;
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
            return Instance;
        }

        public IJsObject DefaultValue(DefaultValueHints hint) {
            return Instance;
        }

        public bool DefineOwnProperty(Descriptor desc, bool throwError) {
            return false;
        }

        public void ChildNotify() {
        }

        public void RepopulateProperty(string name) {
        }

        public IJsObject IndexerGet(IJsObject key) {
            return Instance;
        }

        public void IndexerPut(IJsObject key, IJsObject value) {
        }

        public IEnumerable<IJsObject> CustomEnumerator {
            get { return new IJsObject[0]; }
        }

        #endregion

        #region IJsInstance Members


        public object Value {
            get { return null; }
            set { }
        }

        public IJsObject ToPrimitive(IGlobal global) {
            return Instance;
        }

        public string Class {
            get { return JsInstance.CLASS_OBJECT; }
        }

        public JsObjectType Type {
            get { return JsObjectType.Undefined; }
        }

        public bool IsReference {
            get { return false; }
        }

        public IJsObject BaseObject {
            get { return Instance; }
        }

        public string ReferencedProperty {
            get { return null; }
        }

        public IJsObject GetObject() {
            return Instance;
        }

        public void SetObject(IJsObject value) {
        }

        #endregion

        #region IDictionary<string,IJsObject> Members

        public void Add(string key, IJsObject value) {
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
            get { return Instance; }
            set { }
        }

        #endregion

        #region ICollection<KeyValuePair<string,IJsObject>> Members

        public void Add(KeyValuePair<string, IJsObject> item) {
        }

        public void Clear() {
        }

        public bool Contains(KeyValuePair<string, IJsObject> item) {
            return false;
        }

        public void CopyTo(KeyValuePair<string, IJsObject>[] array, int arrayIndex) {
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
            return ((IEnumerable<string,IJsObject>)new KeyValuePair<string,IJsObject>[0]).GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion


        #region IJsObject Members


        public IJsObject DefaultValue(IGlobal global) {
            throw new JsTypeException("Can't get a DefaultValue for undefined instance");
        }

        public IJsObject DefaultValue(IGlobal global, DefaultValueHints hint) {
            throw new JsTypeException("Can't get a DefaultValue for undefined instance");
        }

        public bool ToBoolean() {
            return false;
        }

        public double ToNumber() {
            Double.NaN;
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
            throw new JsTypeException("Can't convert the undefined instance to an object");
        }

        public override string ToString() {
            return "undefined";
        }

        #endregion
    }
}
