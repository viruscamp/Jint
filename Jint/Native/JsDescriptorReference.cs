using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// This class is used to represent a reference, that is a base object
    /// and a property name. It also caches a descriptor to optimize the operation
    /// of the property lookup.
    /// </summary>
    /// <remarks>
    /// If the cached descriptor becomes outdated it will be resolved again.
    /// </remarks>
    public class JsDescriptorReference: JsReference {
        IJsObject m_base;
        Descriptor m_descriptor;
        string m_propertyName;

        public JsDescriptorReference(IJsObject baseObject, Descriptor d) {
            if (baseObject == null)
                throw new ArgumentNullException("baseObject");

            if (baseObject == JsNull.Instance || baseObject == JsUndefined.Instance)
                throw new ArgumentException("A valid object is required","baseObject");

            if (d== null)
                throw new ArgumentNullException("d");

            m_base = baseObject;
            m_descriptor = d;
            m_propertyName = d.Name;
        }

        public JsDescriptorReference(IJsObject baseObject, string propertyName) {
            if (baseObject == null)
                throw new ArgumentNullException("baseObject");

            if (String.IsNullOrEmpty(propertyName))
                throw new ArgumentException("A property name should be a non empty string", "propertyName");

            m_base = baseObject;
            m_propertyName = propertyName;
        }

        #region JsReference Members

        public override IJsObject BaseObject {
            get { return m_base; }
        }

        public override string ReferencedProperty {
            get { return m_propertyName; }
        }

        public override IJsObject GetObject() {
            if (m_descriptor == null || m_descriptor.isDeleted)
                m_descriptor = m_base.GetProperty(m_propertyName);

            return m_descriptor == null ? JsUndefined.Instance : m_descriptor.Get(m_base);
        }

        public override void SetObject(IJsObject value) {
            if (m_descriptor == null || m_descriptor.isDeleted)
                m_descriptor = m_base.GetProperty(m_propertyName);

            if (m_descriptor != null)
                m_descriptor.Set(m_base, value);
        }

        #endregion
    }
}
