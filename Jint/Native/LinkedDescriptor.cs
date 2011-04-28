using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    /// <summary>
    /// Linked descriptor - a link to the particular property (represented by a descriptor) of the particular object.
    /// </summary>
    /// <remarks>
    /// This descriptors are used in scopes
    /// </remarks>
    class LinkedDescriptor : Descriptor {
        Descriptor d;
        JsObjectBase m_that;

        /// <summary>
        /// Constructs new descriptor
        /// </summary>
        /// <param name="owner">An owner of the new descriptor</param>
        /// <param name="name">A name of the new descriptor</param>
        /// <param name="source">A property descriptor of the target object to which we should link to</param>
        /// <param name="that">A target object to whose property we are linking. This parameter will be
        /// used in the calls to a 'Get' and 'Set' properties of the source descriptor.</param>
        public LinkedDescriptor(JsObjectBase owner, string name, Descriptor source, JsObjectBase that)
            : base(owner, name) {
            if (source.isReference) {
                LinkedDescriptor sourceLink = source as LinkedDescriptor;
                d = sourceLink.d;
                m_that = sourceLink.m_that;
            } else
                d = source;
            Enumerable = true;
            Writable = true;
            Configurable = true;
            m_that = that;
        }

        public JsObjectBase targetObject {
            get { return m_that; }
        }

        public Descriptor targetDescriptor {
            get { return d; }
        }

        public override bool isReference {
            get { return true ; }
        }

        public override bool isDeleted {
            get {
                return d.isDeleted;
            }
            protected set {
                /* do nothing */;
            }
        }

        public override Descriptor Clone() {
            return new LinkedDescriptor(Owner, Name, this, targetObject) {
                Writable = this.Writable,
                Configurable = this.Configurable,
                Enumerable = this.Enumerable
            };
        }

        public override IJsObject Get(IJsObject that) {
            return d.Get(m_that);
        }

        public override void Set(IJsObject that, IJsObject value) {
            d.Set(m_that, value);
        }

        public override DescriptorType DescriptorType {
            get { return d.DescriptorType; }
        }

        public override bool Writable {
            get {
                return d.Writable ;
            }
            set {
                ;
            }
        }
    }
}
