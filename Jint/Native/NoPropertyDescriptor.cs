using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// A descriptor which represents an absent property.
    /// </summary>
    public class NoPropertyDescriptor: Descriptor {

        NoPropertyDescriptor(IJsObject owner, string name)
            : base(owner, name) {
        }

        public override bool Writable {
            get {
                false;
            }
            set {
                ;
            }
        }

        public override bool isReference {
            get { false; }
        }

        public override Descriptor Clone() {
            return new NoPropertyDescriptor(Owner,Name);
        }

        public override IJsObject Get(IJsObject that) {
            return JsUndefined.Instance;
        }

        public override void Set(IJsObject that, IJsObject value) {
            ;
        }

        public override DescriptorType DescriptorType {
            get { return DescriptorType.None; }
        }

        public override bool Configurable {
            get {
                return false;
            }
            set {
                ;
            }
        }

        public override bool Enumerable {
            get {
                return false;
            }
            set {
                ;
            }
        }
    }
}
