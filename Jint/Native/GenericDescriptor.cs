using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Jint.Native {
    
    /// <summary>
    /// Used to mark explicitly set attributes of a descriptor
    /// </summary>
    [Flags]
    public enum DescriptorAttributes: int {
        Enumerable = 1,
        Configurable = 2,
        Writable = 4,
        Setter = 8,
        Getter = 16,
        Value
    }

    public interface IGenericDescriptor {
        Descriptor ToRealDescriptor(bool defaultConfigurable, bool defaultEnumerable);
        Descriptor ToRealDescriptor();
    }

    /// <summary>
    /// Represents a generic descriptor, used only to store attributes and should not appear in objects.
    /// </summary>
    /// <remarks>
    /// This attribute also used to update an existing attributes of a descriptor using <c>Merge</c> method.
    /// </remarks>
    public class GenericDescriptor: Descriptor, IGenericDescriptor {
        DescriptorAttributes m_explicitAttributes;
        JsFunction m_getter;
        JsFunction m_setter;
        IJsObject m_value = JsUndefined.Instance;

        bool m_writable;

        public virtual JsFunction Getter {
            get { return m_getter; }
            set {
                m_getter = value;
                m_explicitAttributes |= DescriptorAttributes.Getter;
            }
        }

        public virtual JsFunction Setter {
            get { return m_setter; }
            set {
                m_setter = value;
                m_explicitAttributes |= DescriptorAttributes.Setter;
            }
        }

        public override bool Writable {
            get {
                return m_writable;
            }
            set {
                Debug.Assert(!IsAccessorDescriptor());
                m_writable = value;
                m_explicitAttributes |= DescriptorAttributes.Writable;
            }
        }

        public IJsObject Value {
            get { return m_value; }
            set {
                Debug.Assert(!IsAccessorDescriptor());
                if (value == null)
                    m_value = JsNull.Instance;
                else
                    m_value = value;

                m_explicitAttributes |= DescriptorAttributes.Value;
            }
        }

        public override bool Configurable {
            get {
                return base.Configurable;
            }
            set {
                base.Configurable = value;
                m_explicitAttributes |= DescriptorAttributes.Configurable;
            }
        }

        public override bool Enumerable {
            get {
                return base.Enumerable;
            }
            set {
                base.Enumerable = value;
                m_explicitAttributes |= DescriptorAttributes.Enumerable;
            }
        }

        public bool HasAttribute(DescriptorAttributes attribute) {
            return (m_explicitAttributes & attribute) == attribute;
        }

        public bool HasAnyAttribute(DescriptorAttributes attribute) {
            return (m_explicitAttributes & attribute) != attribute;
        }

        public bool IsDataDescriptor() {
            return m_explicitAttributes & (DescriptorAttributes.Writable | DescriptorAttributes.Value) != 0;
        }

        public bool IsAccessorDescriptor() {
            return m_explicitAttributes & (DescriptorAttributes.Getter | DescriptorAttributes.Setter) != 0;
        }

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

        /// <summary>
        /// Creates an appropriate real descriptor from the current generic descriptor.
        /// </summary>
        /// <returns>A new real descriptor</returns>
        public Descriptor ToRealDescriptor() {
            ToRealDescriptor(false, false);
        }

        /// <summary>
        /// Merges all existing proeprties from a specfied descriptor.
        /// </summary>
        /// <param name="desc">A source <c>GenericDescriptor</c>.</param>
        /// <returns>False if a source descriptor isn't a GenericDescritor</returns>
        public override bool Merge(Descriptor desc) {
            if (desc == null)
                throw new ArgumentNullException("desc");
            
            GenericDescriptor gd = desc as GenericDescriptor;
            if (gd == null)
                return false;

            if ( !base.Merge(desc))
                return false;

            if (gd.HasAttribute(DescriptorAttributes.Getter))
                Getter = gd.Getter;

            if (gd.HasAttribute(DescriptorAttributes.Setter))
                Setter = gd.Setter;

            if (gd.HasAttribute(DescriptorAttributes.Value))
                Value = gd.Value;

            if (gd.HasAttribute(DescriptorAttributes.Writable))
                Writable = gd.Writable;

        }

        /// <summary>
        /// Creates an appropriate real descriptor from the current generic descriptor.
        /// </summary>
        /// <param name="defaultConfigurable">A Configurable attribute value if the current object doesn't have it</param>
        /// <param name="defaultEnumerable">An Enumerable attribute value if the current object doesn't have it</param>
        /// <returns>A new real descriptor</returns>
        public Descriptor ToRealDescriptor(bool defaultConfigurable, bool defaultEnumerable) {
            bool conf = m_explicitAttributes & DescriptorAttributes.Configurable ? Configurable : defaultConfigurable;
            bool enm = m_explicitAttributes & DescriptorAttributes.Enumerable ? Enumerable : defaultEnumerable;
            if (IsAccessorDescriptor())
                return new PropertyDescriptor(null, Owner, Name) {
                    Enumerable = enm,
                    Configurable = conf,
                    SetFunction = Setter,
                    GetFunction = Getter
                };
            else
                return new ValueDescriptor(Owner, Name) {
                    Enumerable = enm,
                    Configurable = conf,
                    Writable = this.Writable,
                    Value = this.Value
                };
        }
    }
}
