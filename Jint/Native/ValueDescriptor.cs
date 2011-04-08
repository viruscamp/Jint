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

        IJsInstance value;

        public ValueDescriptor(JsObjectBase owner, string name, IJsInstance value)
            : this(owner, name) {
            Set(null, value);
        }

        public override bool isReference {
            get { return false; }
        }

        public override Descriptor Clone() {
            return new ValueDescriptor(Owner, Name, value) {
                Enumerable = this.Enumerable,
                Configurable = this.Configurable,
                Writable = this.Writable
            };
        }

        public override IJsInstance Get(JsObjectBase that) {
            return value ?? JsUndefined.Instance;
        }

        public override void Set(JsObjectBase that, IJsInstance value) {
            if (!Writable)
                throw new JintException("This property is not writable");
            this.value = value;
        }

        internal override DescriptorType DescriptorType {
            get { return DescriptorType.Value; }
        }
    }
}
