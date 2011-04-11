using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    [Serializable]
    public class ValueDescriptor : Descriptor {
        public ValueDescriptor(JsObjectBase owner, string name)
            : base(owner, name) {
            Enumerable = true;
            Writable = true;
            Configurable = true;
        }

        IJsInstance m_value;

        public ValueDescriptor(JsObjectBase owner, string name, IJsInstance value)
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

        public override IJsInstance Get(JsObjectBase that) {
            return m_value ?? JsUndefined.Instance;
        }

        public override void Set(JsObjectBase that, IJsInstance value) {
            if (!Writable)
                throw new JintException("This property is not writable");
            this.m_value = value;
        }

        public IJsInstance Value {
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

            bool canConfigure = Configurable;
            bool canWrite = Writable;

            if (!base.Merge(desc))
                return false;

            canWrite = canWtite || Writable;

            GenericDescriptor gen = desc as GenericDescriptor;
            
            if (gen == null)
                return false;

            if (gen.HasAttribute(DescriptorAttributes.Writable)) {
                if (canConfigure)
                    Writable = gen.Writable;
                else
                    return false;
            }

            if (gen.HasAttribute(DescriptorAttributes.Value) && gen.Value != Value) {
                if (canConfigure || Writable)
                    Value = gen.Value;
                else
                    return false;
            }
        }
    }
}
