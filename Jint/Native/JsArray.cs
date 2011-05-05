using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// This class holds properties with numerical names in a separate storage
    /// to provide a more efficient access to them.
    /// </summary>
    public class JsArray : JsObjectBase {
        public const string LENGTH = "length";

        class ClrListWrapper : IList<IJsObject> {
            JsArray m_array;

            public ClrListWrapper(JsArray array) {
                Debug.Assert(array != null);
                m_array = array;
            }

            #region IList<IJsObject> Members

            public int IndexOf(IJsObject item) {
                if (indexer == null)
                    return -1;
                foreach (var pair in m_array.ArrayElements)
                    if (!pair.Value.isDeleted && pair.Value.Get(m_array) == item)
                        return pair.Key;
                return -1;
            }

            public void Insert(int index, IJsObject item) {
                if (index <0)
                    throw new ArgumentOutOfRangeException("index");
                if (item == null)
                    throw new ArgumentNullException("item");
                
                for (uint i = m_array.Length; i >= (uint)index; i--) {
                    if (m_array.HasProperty(i))
                        m_array.Put(i + 1, m_array.Get(i));
                }
            }

            public void RemoveAt(int index) {
                if (index < 0)
                    throw new ArgumentOutOfRangeException("index");
                m_array.Delete(index.ToString(), false);
            }

            public IJsObject this[int index] {
                get {
                    if (index < 0)
                        throw new ArgumentOutOfRangeException("index");

                    return m_array.Get((uint)index);
                }
                set {
                    if (index < 0)
                        throw new ArgumentOutOfRangeException("index");

                    m_array.Put((uint)index,value);
                }
            }

            #endregion

            #region ICollection<IJsObject> Members

            public void Add(IJsObject item) {
                if (item == null)
                    throw new ArgumentNullException("item");
                m_array.Add(item);
            }

            public void Clear() {
                m_array.Length = 0 ;
            }

            public bool Contains(IJsObject item) {
                return IndexOf(item) >= 0;
            }

            public void CopyTo(IJsObject[] array, int arrayIndex) {
                if (array == null)
                    throw new ArgumentNullException("array");
                if (array.Rank > 1)
                    throw new ArgumentException("The specified array must be one dimentional","array");
                if (arrayIndex < 0 || arrayIndex >= array.Length)
                    throw new ArgumentOutOfRangeException("A start position must be inside the array", "arrayIndex");
                if (arrayIndex + m_array.Length > array.Length)
                    throw new ArgumentException("The specified array doesn't have enough space to store elements", "array");

                for (uint i = 0; i < m_array.Length; i++)
                    array[arrayIndex + i] = m_array.Get(i);
            }

            public int Count {
                get { m_array.Length; }
            }

            public bool IsReadOnly {
                get { return m_array.Frozen; }
            }

            public bool Remove(IJsObject item) {
                if (item == null)
                    return false;
 
                int key = IndexOf(item);
                if (key >= 0)
                    return m_array.Delete(key.ToString(),false);
            }

            #endregion

            #region IEnumerable<IJsObject> Members

            public IEnumerator<IJsObject> GetEnumerator() {
                for(uint i = 0; i < m_array.Length; i++)
                    yield return m_array.Get(i);
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

            #endregion
        }

        private uint m_length = 0;
        IGlobal m_global;

        SortedList<uint, Descriptor> m_data = new SortedList<uint, Descriptor>();

        public JsArray(IGlobal global, JsObject prototype)
            : base(prototype) {
            if (global == null)
                throw new ArgumentNullException("global");

            DefineOwnProperty(
                new NativeValueDescriptor(
                    this,
                    LENGTH,
                    delegate(IJsObject that) {
                        return m_global.NewPrimitive(Length);
                    },
                    delegate(IJsObject that, IJsObject value) {
                        if (value.ToNumber() != value.ToUInt32())
                            throw new JsRangeException("A length value sould be an unsigned integer");
                        setLength(value.ToUInt32());
                    }
                ),
                true
            );
        }

        public override bool IsClr {
            get {
                return false;
            }
        }

        /// <summary>
        /// 15.4.2
        /// </summary>
        public override string Class {
            get {
                return JsInstance.CLASS_ARRAY;
            }
        }

        public uint Length {
            get {
                return m_length;
            }
            set {
                setLength(value);
            }
        }

        public IJsObject Get(uint i) {
            Descriptor value = GetProperty(i);
            return value != null ? value.Get(this) : JsUndefined.Instance;
        }

        public bool Put(uint i, IJsObject value,bool throwError) {
            if (value == null)
                throw new ArgumentNullException("value");

            Descriptor d = GetProperty(i);

            if (d != null) {
                if (d.Owner == this) {

                    if (d.Writable)
                        d.Set(this, value);
                    else
                        return Reject(String.Format("A property {0} isn't writable", name), throwError);

                } else if (d.DescriptorType == DescriptorType.Accessor) {
                    if (d.Writable) {
                        d.Set(this, value);
                        return true;
                    }
                }
            }

            // the property is absent or inherited value property
            if (!Extensible)
                return Reject("The object isn't extensible",throwError);

            if (d != null && m_hasChildren)
                d.Owner.RepopulateProperty(d.Name);

            d = new ValueDescriptor(this, i.ToString(), value);
            m_data[i] = d;

            if (i >= m_length)
                m_length = i + 1;

            return true;
        }

        public bool HasProperty(uint key) {
            Descriptor d = GetProperty(key);
            Debug.Assert(!d.isDeleted);

            if (d != null && d.DescriptorType != DescriptorType.None)
                return true;
            return false;
        }

        public bool HasOwnProperty(uint key) {
            Descriptor d = GetOwnProperty(key);
            Debug.Assert(!d.isDeleted);

            if (d != null && d.DescriptorType != DescriptorType.None)
                return true;
            return false;
        }

        private void setLength(uint newLength) {
            int actualLength = newLength;

            if (newLength < m_length) {
                int keyIndex = FindKeyOrNext(newLength);

                // we have elements to remove
                if (keyIndex >= 0) {
                    for (int i = m_data.Count - 1; i >= keyIndex; i--) {
                        Descriptor d = m_data.Values[i];
                        if (d.Owner != this)
                            continue;

                        if (d.Configurable) {
                            m_data.RemoveAt(i);
                            d.Delete();
                        } else {
                            // if we get first non deletable property, we will stop
                            // and set length property to the correct value
                            actualLength = m_data.Keys[i] + 1;
                            break;
                        }
                    }
                }
            }

            m_length = actualLength;
        }

        public Descriptor GetOwnProperty(uint key) {
            Descriptor d;
            if (m_data.TryGetValue(key, out d) && d.Owner == this) {
                Debug.Assert(!d.isDeleted);
                return d;
            }

            return null;
        }

        public override Descriptor GetOwnProperty(string name) {
            uint key;
            if (Int32.TryParse(name, out key) && key >= 0) {
                return GetOwnProperty(key);
            } else
                return base.GetOwnProperty(name);
        }

        public Descriptor GetProperty(uint key) {
            Descriptor d;

            if (m_data.TryGetValue(key, out d)) {
                if (!d.isDeleted)
                    return d;
                else
                    m_data.Remove(key);
            }

            d = base.GetProperty(name);

            if (d != null) {
                Debug.Assert(d.Owner != this); // own array elements should be stored in m_data
                m_data[key] = d; // cache descriptor
            }

            return d;
        }

        public override Descriptor GetProperty(string name) {
            uint key;
            if (UInt32.TryParse(name, out key)) {
                return GetProperty(key);
            } else
                return base.GetProperty(name);
        }

        public override IJsObject IndexerGet(IJsObject key) {
            uint index = key.ToUInt32();
            if (key.ToNumber() == index)
                return Get(index);
            else
                return Get(key.ToString());
        }

        public override void IndexerPut(IJsObject key, IJsObject value) {
            uint index = key.ToUInt32();
            if (key.ToNumber() == index)
                Put(index, value);
            else
                Put(key.ToString(), value, false);
        }

        public override bool DefineOwnProperty(Descriptor desc, bool throwError) {
            if (desc == null)
                throw new ArgumentNullException("desc");

            int key;

            if (Int32.TryParse(desc.Name, out key) && key >= 0) {
                Descriptor prev;
                if (m_data.TryGetValue(key, out prev) && prev.Owner == this) {
                    if (!prev.Merge(desc)) {
                        if (prev.Configurable) {
                            prev.Delete();
                            m_data[key] = desc;
                        } else {
                            return Reject(String.Format("Property {0} isn't configurable", desc.Name), throwError);
                        }
                    }
                } else {
                    if (Extensible) {
                        if (m_hasChildren)
                            prev.Owner.RepopulateProperty(prev.Name);
                        m_data[key] = desc;
                    } else
                        return Reject("The object isn't extensible", throwError);
                }

                if (key >= m_length)
                    m_length = key + 1;

                return true;
            } else {
                return base.DefineOwnProperty(desc, throwError);
            }
        }

        protected override void RemoveFromBag(Descriptor d) {
            uint key;
            if (UInt32.TryParse(d.Name, out key))
                m_data.Remove(key);
            else
                base.RemoveFromBag(d);
        }

        public override void RepopulateProperty(string name) {
            uint key;
            Descriptor d;
            if ( UInt32.TryParse(name, out key) && m_data.TryGetValue(key, out d) && d.Owner == this && !d.isDeleted ) {
                m_data[key] = d.Clone();
                d.Delete();
            } else
                base.RepopulateProperty(name);
        }

        public override IEnumerable<Descriptor> GetOwnProperties() {
            foreach (var d in m_data.Values)
                if (d.Owner == this)
                    yield return d;

            foreach (var d in base.GetOwnProperties())
                yield return d;
        }

        private int FindKeyOrNext(uint key) {
            int left = 0, right = m_data.Count - 1;
            int index = 0;
            while (left <= right) {
                int current = m_data.Keys[index];
                if (current == key)
                    return index;
                else {
                    if (current > key)
                        right = index - 1;
                    else
                        left = index + 1;
                    index = (left + right) / 2;
                }
            }

            // not found, left will contain next after index if it's in range
            return left < m_data.Count ? left : -1;

        }

        private int FindKeyOrPrev(uint key) {
            int left = 0, right = m_data.Count - 1;
            int index = 0;
            while (left <= right) {
                int current = m_data.Keys[index];
                if (current == key)
                    return index;
                else {
                    if (current > key)
                        right = index - 1;
                    else
                        left = index + 1;
                    index = (left + right) / 2;
                }
            }

            // not found, right will contain previous before index if it's in range
            return right;
        }

        /// <summary>
        /// Elements in this array EXCLUDING inherited elements.
        /// </summary>
        public IEnumerable<KeyValuePair<int, Descriptor>> ArrayElements {
            get {
                foreach(var pair in m_data)
                    if (pair.Value.Owner == this)
                        yield return m_data;
            }
        }

        /// <summary>
        /// Constructs new array from OWN elements of this array.
        /// </summary>
        /// <returns></returns>
        public virtual IJsObject[] ToArray() {
            IJsObject[] result = new IJsObject[m_length];

            uint last = 0;

            foreach (var pair in m_data) {
                if (pair.Value.Owner != this)
                    continue;

                uint i = pair.Key;

                for (uint ii = last; ii < i; ii++)
                    result[ii] = JsUndefined.Instance;
                result[i] = pair.Value.Get(this);
            }

            for (uint ii = last; ii < m_length; ii++)
                result[ii] = JsUndefined.Instance;
        }

        public IList<JsObject> GetListWrapper() {
            return new ClrListWrapper(this);
        }

        public void Add(IJsObject item) {
            Put(m_length,item);
        }

        public override object Value {
            get {
                return new ClrListWrapper(this);
            }
            set {
                ;
            }
        }
    }
}
