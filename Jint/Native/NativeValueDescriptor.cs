using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// A value descriptor which is implemented by delegates. This descriptor will be bound to the owner.
    /// </summary>
    public class NativeValueDescriptor: Descriptor {
        
        JsGetter m_getter;
        JsSetter m_setter;
        IJsObject m_target;

        /// <summary>
        /// Creates new data descriptor. Writable = true, Enumerable = false, Configurable = false.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="getter"></param>
        public NativeValueDescriptor(IJsObject owner, string name, JsSetter setter, JsGetter getter)
            : base(owner, name) {
            m_getter = getter;
            m_setter = setter;
            m_target = owner;
        }

        /// <summary>
        /// Creates new data descriptor. Writable = false, Enumerable = false, Configurable = false.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="getter"></param>
        public NativeValueDescriptor(IJsObject owner, string name, JsGetter getter)
            : base(owner, name) {
            m_getter = getter;
            m_target = owner;
        }

        public override bool Writable {
            get {
                return m_setter != null;
            }
            set {
                throw new InvalidOperationException();
            }
        }

        public override bool isReference {
            get { return false; }
        }

        public override Descriptor Clone() {
            NativeValueDescriptor d = new NativeValueDescriptor(m_target, Name, m_setter, m_getter);
            d.Enumerable = Enumerable;
            d.Configurable = Configurable;
            return d;
        }

        public override IJsObject Get(IJsObject that) {
            if (m_getter != null)
                return m_getter(m_target);
            else
                return JsUndefined.Instance;
        }

        public override void Set(IJsObject that, IJsObject value) {
            if (m_setter != null)
                m_setter(m_target, value);
        }

        public override DescriptorType DescriptorType {
            get { return DescriptorType.Value; }
        }
    }
}
