using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;

namespace Jint.Native {
    /// <summary>
    /// This class holds properties with numerical names in a separate storage
    /// to provide a more efficient access to them.
    /// </summary>
    public sealed class JsArray : JsObjectBase {
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

        public override bool IsClr
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 15.4.2
        /// </summary>
        public override string Class
        {
            get
            {
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

        public IJsObject Put(int i, IJsObject value) {
            if (i < 0)
                throw new JsRangeException("Index cant be a negative number");

            Descriptor d;
            if (!m_data.TryGetValue(i, out d)) {

                if (!Extensible)
                    return JsUndefined.Instance;

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
                            actualLength = m_data.Keys[i]+1;
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
                return m_data.TryGetValue(key,out d) ? null : d;
            } else
                return base.GetOwnProperty(name);
        }

        public override bool DefineOwnProperty(Descriptor desc, bool throwError) {
            int key;

            return base.DefineOwnProperty(desc, throwError);
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

        
        #region array specific methods

        [RawJsMethod]
        public JsArray concat(IGlobal global, IJsInstance[] args) {
            var newData = new SortedList<int, IJsInstance>(m_data);
            int offset = length;
            foreach (var item in args) {
                if (item is JsArray) {
                    foreach (var pair in ((JsArray)item).m_data)
                        newData.Add(pair.Key + offset, pair.Value);
                    offset += ((JsArray)item).Length;
                }
                else if (global.ArrayClass.HasInstance(item as JsObject)) {
                    // Array subclass
                    JsObject obj = (JsObject)item;

                    for (int i = 0; i < obj.Length; i++) {
                        IJsInstance value;
                        if (obj.TryGetProperty(i.ToString(), out value))
                            newData.Add(offset + i, value);
                    }
                }
                else {
                    newData.Add(offset, item);
                    offset++;
                }
            }

            return new JsArray(newData, offset, global.ArrayClass.PrototypeProperty);
        }

        [RawJsMethod]
        public JsString join(IGlobal global, IJsInstance separator) {
            if (length == 0)
                return global.StringClass.New();

            string sep = separator == JsUndefined.Instance ? "," : separator.ToString();
            string[] map = new string[length];

            IJsInstance item;
            for (int i = 0; i < length; i++)
                map[i] = m_data.TryGetValue(i, out item) && item != JsNull.Instance && item != JsUndefined.Instance ? item.ToString() : "";

            return global.StringClass.New(String.Join(sep, map));
        }

        #endregion
    }
}
