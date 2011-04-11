using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Represents a generic descriptor, used only to store attributes and should not appear in objects
    /// </summary>
    public class GenericDescriptor: Descriptor {
        public override bool isReference {
            get { false; }
        }

        public override Descriptor Clone() {
            throw new NotImplementedException();
        }

        public override IJsObject Get(IJsObject that) {
            throw new NotImplementedException();
        }

        public override void Set(IJsObject that, IJsObject value) {
            throw new NotImplementedException();
        }

        public override DescriptorType DescriptorType {
            get { return DescriptorType.Generic; }
        }

        public Descriptor ToValueDescriptor() {
            return new ValueDescriptor(Owner, Name) {
                Enumerable = this.Enumerable,
                Configurable = this.Configurable,
                Writable = this.Writable
            };
        }
    }
}
