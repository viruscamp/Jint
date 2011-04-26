using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    
    public class ValueDescriptor : Descriptor {
        IJsObject m_value;
        bool m_writable;

        /// <summary>
        /// Creates a new data descriptor. Writable, Enumerable, Configurable by default.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        public ValueDescriptor(IJsObject owner, string name)
            : base(owner, name) {
            Enumerable = true;
            Writable = true;
            Configurable = true;
        }

        /// <summary>
        /// Creates a new data descriptor. Writable, Enumerable, Configurable by default.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ValueDescriptor(IJsObject owner, string name, IJsObject value)
            : this(owner, name) {
            Set(null, value);
        }

        public override bool isReference {
            get { return false; }
        }

        public override Descriptor Clone() {
            return new ValueDescriptor(Owner, Name, m_value) {
                Enumerable = this.Enumerable,
                Configurable = this.Configurable,
                Writable = this.Writable
            };
        }

        public override IJsObject Get(IJsObject that) {
            return m_value ?? JsUndefined.Instance;
        }

        public override void Set(IJsObject that, IJsObject value) {
            if (!Writable)
                throw new JintException("This property is not writable");
            this.m_value = value;
        }

        public IJsObject Value {
            get { return m_value; }
            set {
                m_value = value;
            }
        }

        internal override DescriptorType DescriptorType {
            get { return DescriptorType.Value; }
        }

        public override bool Merge(Descriptor desc) {
            if (desc == null)
                throw new ArgumentNullException("desc");

            GenericDescriptor gen = desc as GenericDescriptor;

            if (gen == null)
                return false;

            if (gen.IsAccessorDescriptor())
                return false;

            if (
                !Configurable &&
                gen.HasAnyAttribute(
                    DescriptorAttributes.Configurable |
                    DescriptorAttributes.Enumerable |
                    DescriptorAttributes.Writable
                )
            )
                return false;

            if (! (Writable || Configurable) && gen.HasAttribute(Value))
                return false;

            if (!base.Merge(desc))
                return false;

            if (gen.HasAttribute(DescriptorAttributes.Writable))
                Writable = gen.Writable;

            if (gen.HasAttribute(DescriptorAttributes.Value))
                Value = gen.Value;

            return true;
        }

        public override bool Writable {
            get {
                return m_writable;
            }
            set {
                m_writable = value;
            }
        }
    }
}
