using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;
using System.Collections.ObjectModel;

namespace Jint.Native {
    /// <summary>
    /// This class holds properties with numerical names in a separate storage
    /// to provide a more efficient access to them.
    /// </summary>
    public class JsArray : JsObjectBase {
        public const string LENGTH = "length";

        private uint length = 0;
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
                return length;
            }
            set {
                setLength(value);
            }
        }

        public IJsObject Get(int i) {
            Descriptor value;
            return m_data.TryGetValue(i, out value) ? value.Get(this) : JsUndefined.Instance;
        }

        public void Put(int i, IJsObject value) {
            if (value == null)
                throw new ArgumentNullException("value");

            if (i < 0)
                throw new JsRangeException("Index cant be a negative number");

            Descriptor d;
            if (!m_data.TryGetValue(i, out d)) {

                if (!Extensible)
                    return;

                d = new ValueDescriptor(this, i.ToString());
                m_data[i] = d;

                if (i >= length)
                    length = i + 1;
            }

            d.Set(this, value);
        }

        private void setLength(int newLength) {
            if (newLength < 0)
                throw new ArgumentOutOfRangeException("New length is out of range");

            int actualLength = newLength;

            if (newLength < length) {
                int keyIndex = FindKeyOrNext(newLength);

                // we have elements to remove
                if (keyIndex >= 0) {
                    for (int i = m_data.Count - 1; i >= keyIndex; i--) {
                        Descriptor d = m_data.Values[i];

                        if (d.Configurable) {
                            m_data.RemoveAt(i);
                        } else {
                            // if we get first non deletable property, we will stop
                            // and set length property to the correct value
                            actualLength = m_data.Keys[i] + 1;
                            break;
                        }
                    }
                }
            }

            length = actualLength;
        }

        public override Descriptor GetOwnProperty(string name) {
            int key;
            if (Int32.TryParse(name, out key) && key >= 0) {
                Descriptor d;
                return m_data.TryGetValue(key, out d) ? null : d;
            } else
                return base.GetOwnProperty(name);
        }

        public override bool DefineOwnProperty(Descriptor desc, bool throwError) {
            if (desc == null)
                throw new ArgumentNullException("desc");

            int key;

            if (Int32.TryParse(desc.Name, out key) && key >= 0) {
                Descriptor prev;
                if (m_data.TryGetValue(key, out prev)) {
                    if (!prev.Merge(desc)) {
                        if (prev.Configurable) {
                            prev.Delete();
                            m_data[key] = desc;
                        } else {
                            return Reject(String.Format("Property {0} isn't configurable", desc.Name), throwError);
                        }
                    }
                } else {
                    if (Extensible)
                        m_data[key] = desc;
                    else
                        return Reject("The object isn't extensible", throwError);
                }
                if (key >= length)
                    length = key + 1;
                return true;
            } else {
                return base.DefineOwnProperty(desc, throwError);
            }
        }

        public override IEnumerable<Descriptor> GetOwnProperties() {
            foreach (var d in m_data.Values)
                yield return d;
            foreach (var d in base.GetOwnProperties())
                yield return d;
        }

        private int FindKeyOrNext(int key) {
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

        private int FindKeyOrPrev(int key) {
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

        public IEnumerable<KeyValuePair<int, Descriptor>> ArrayElements {
            get {
                return m_data;
            }
        }

        public virtual IJsObject[] ToArray() {
            IJsObject[] result = new IJsObject[length];

            int last = 0;

            foreach (var pair in m_data) {
                int i = pair.Key;

                for (int ii = last; ii < i; ii++)
                    result[ii] = JsUndefined.Instance;
                result[i] = pair.Value.Get(this);
            }

            for (int ii = last; ii < length; ii++)
                result[ii] = JsUndefined.Instance;
        }

    }
}
