using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    /// <summary>
    /// General javascript object, capable to store a CLR value.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When no clr value is assciated with the instance of this class it
    /// behaves like a javascript object (convertions, indexers, etc.),
    /// but when it holds a clr value it's behaviour changes.
    /// </para>
    /// <para>
    /// If a clr object have an indexers they will be accessible through
    /// square braces instead of properties. If object is enumerable it can
    /// be iterated using for-in statement. <c>ToPrimitive</c> method will use
    /// methods of the object and <c>Convert</c> class and it can't be overriden
    /// from script.
    /// </para>
    /// <code>
    /// var col = new System.Collections.Generics.Dictionary{System.String,System.String}();
    /// 
    /// // access dictionary items
    /// col["prop"] = "dictionary entry";
    /// 
    /// // setup a custom dictionary property
    /// col.prop = "object property";
    /// 
    /// // access a clr property
    /// console.print(col.Count);
    /// 
    /// // iterate over dictionary
    /// for(var item in col) {
    ///     console.print(item.Key);
    ///     console.print(item.Value);
    /// }
    /// </code>
    /// </remarks>
    public class JsObject : JsObjectBase {
        INativeIndexer m_indexer;
        object m_value;

        public JsObject(object value, IJsObject prototype)
            : base(prototype) {
            m_value = value;
        }

        public JsObject(IJsObject prototype)
            : this(null, prototype) {
        }

        public INativeIndexer NativeIndexer{
            get { return m_indexer; }
            set { m_indexer = value; }
        }

        public override bool IsClr {
            get { return m_value != null; }
        }

        public override object Value {
            get {
                return m_value;
            }
            set {
                m_value = value;
            }
        }

        public override string Class {
            get {
                return m_value == null ? JsInstance.CLASS_OBJECT : m_value.GetType().FullName;
            }
        }

        public override IJsObject IndexerGet(IJsObject key) {
            if (m_indexer == null)
                return base.IndexerGet(key);
            else
                return m_indexer.get(this, key);
        }

        public override void IndexerPut(IJsObject key, IJsObject value) {
            if (m_indexer == null)
                base.IndexerPut(key, value);
            else
                m_indexer.set(this, key, value);
        }

        /// <summary>
        /// Custom implementation of the conversion to primitive type. It behaves
        /// like described in ecma262.5 8.12.8 for pure js objects and has own meaning
        /// for a wrapped clr values.
        /// </summary>
        /// <param name="global">A global object.</param>
        /// <param name="hint">Desired type.</param>
        /// <returns>A new primitive value.</returns>
        public override IJsObject ToPrimitive(IGlobal global, JsObjectType hint) {
            if (m_value != null) {
                IConvertible v = m_value as IConvertible;
                if (hint == JsObjectType.String || v == null) {
                    // we can return only a string primitive
                    return m_value.ToString();
                } else {
                    IConvertible prim = ConversionTraits.ToPrimitive(v);

                    if (prim == null)
                        return JsNull.Instance;

                    switch (prim.GetTypeCode()) {
                        case TypeCode.Double:
                            return global.NewPrimitive((double)prim);
                        case TypeCode.Boolean:
                            return global.NewPrimitive((bool)prim);
                        case TypeCode.String:
                            return global.NewPrimitive((string)prim);
                        default:
                            Debug.Assert(false, "Got wrong primitive from ToPrimitive: " + prim.GetTypeCode().ToString());
                            return JsUndefined.Instance;
                    }
                }
            } else
                return internalToPrimitive(hint);
        }

        public override bool ToBoolean() {
            if (m_value == null)
                return true;
            else
                return ConversionTraits.ToBoolean(m_value);
        }

        public override double ToNumber() {
            if (m_value == null)
                return base.ToNumber();
            else
                return ConversionTraits.ToNumber(m_value);
        }

        public override int ToInteger() {
            if (m_value == null)
                return base.ToInteger();
            else
                return ConversionTraits.ToInteger(m_value);
        }

        public override uint ToUInt32() {
            if (m_value == null)
                return base.ToUInt32();
            else
                return ConversionTraits.ToUInt32(m_value);
        }

        public override ushort ToUInt16() {
            if (m_value == null)
                return base.ToUInt16();
            else
                return ConversionTraits.ToUInt16(m_value);
        }

        public override string ToString() {
            if (m_value == null)
                return base.ToString();
            else
                return m_value.ToString();
        }
    }
}
