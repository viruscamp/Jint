using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    public enum DescriptorType {
        Value, // a descriptor references a value, 'that' parameter is ignored
        Accessor, // will use 'that' parameter in Get/Set methods
        Generic, // a descriptor isn't able to store a value
        None // a descriptor for absent property
    }

    [Serializable]
    public abstract class Descriptor {
        public Descriptor(JsObjectBase owner, string name) {
            this.Owner = owner;
            Name = name;
        }

        public string Name { get; set; }

        public virtual bool Enumerable { get; set; }
        
        public virtual bool Configurable { get; set; }
        
        /// <summary>
        /// If true current descriptor is writable or it has Set method
        /// </summary>
        public abstract bool Writable { get; set; }
        
        public IJsObject Owner { get; set; }

        public virtual bool isDeleted { get; protected set; }

        public abstract bool isReference { get; }

        /// <summary>
        /// Marks a descriptor as a deleted.
        /// </summary>
        /// <remarks>
        /// A descriptor may be deleted to force a refresh of cached references.
        /// </remarks>
        public virtual void Delete() {
            isDeleted = true;
        }

        public bool IsClr {
            get { return false; }
        }

        public abstract Descriptor Clone();

        /// <summary>
        /// Gets a value stored in the descriptor.
        /// </summary>
        /// <param name="that">A target object. This has a meaning in case of descriptors which helds an accessors,
        /// in value descriptors this parameter is ignored.</param>
        /// <returns>A value stored in the descriptor</returns>
        public abstract IJsObject Get(IJsObject that);

        /// <summary>
        /// Sets a value.
        /// </summary>
        /// <param name="that">A target object. This has a meaning in case of descriptors which helds an accessors,
        /// in value descriptors this parameter is ignored.</param>
        /// <param name="value">A new value which should be stored in the descriptor.</param>
        public abstract void Set(IJsObject that, IJsObject value);

        public abstract DescriptorType DescriptorType { get; }

        /// <summary>
        /// 8.10.5
        /// </summary>
        /// <param name="global"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static Descriptor ToPropertyDesciptor(IGlobal global, JsObjectBase owner, string name, IJsInstance jsInstance) {
            if (jsInstance.Class != IJsInstance.CLASS_OBJECT) {
                throw new JsException(global.TypeErrorClass.New("The target object has to be an instance of an object"));
            }

            IJsObject obj = jsInstance.GetObject();
            if ((obj.HasProperty("value") || obj.HasProperty("writable")) && (obj.HasProperty("set") || obj.HasProperty("get"))) {
                throw new JsException(global.TypeErrorClass.New("The property cannot be both writable and have get/set accessors or cannot have both a value and an accessor defined"));
            }

            Descriptor desc;
            IJsInstance result = null;

            if (obj.HasProperty("value")) {
                desc = new ValueDescriptor(owner, name, obj["value"]);
            }
            else {
                desc = new PropertyDescriptor(global, owner, name);
            }

            if (obj.TryGetProperty("enumerable", out result)) {
                desc.Enumerable = result.ToBoolean();
            }

            if (obj.TryGetProperty("configurable", out result)) {
                desc.Configurable = result.ToBoolean();
            }

            if (obj.TryGetProperty("writable", out result)) {
                desc.Writable = result.ToBoolean();
            }

            if (obj.TryGetProperty("get", out result)) {
                if (!(result is JsFunction))
                    throw new JsException(global.TypeErrorClass.New("The getter has to be a function"));

                ((PropertyDescriptor)desc).GetFunction = (JsFunction)result;
            }

            if (obj.TryGetProperty("set", out result)) {
                if (!(result is JsFunction))
                    throw new JsException(global.TypeErrorClass.New("The setter has to be a function"));

                ((PropertyDescriptor)desc).SetFunction = (JsFunction)result;
            }

            return desc;
        }

        /// <summary>
        /// Updates current descriptor using properties from supplied descriptor.
        /// </summary>
        /// <param name="desc">A descriptor from which to get properties.</param>
        /// <remarks>
        /// Current implementation expects to get a <c>GenericDescriptor</c> and will
        /// update <c>Enumerable</c> and <c>Configurable</c> properties.
        /// </remarks>
        /// <returns>True if update successful, false in case of incompatible
        /// source descriptor <paramref name="desc"/>.</returns>
        public virtual bool Merge(Descriptor desc) {
            if (desc == null)
                throw new ArgumentNullException("desc");

            GenericDescriptor genDescriptor = desc as GenericDescriptor;
            if (genDescriptor == null)
                return false;

            if (!Configurable && genDescriptor.HasAnyAttribute(DescriptorAttributes.Configurable | DescriptorAttributes.Enumerable))
                return false;

            if (genDescriptor.HasAttribute(DescriptorAttributes.Enumerable))
                Enumerable = genDescriptor.Enumerable;

            if (genDescriptor.HasAttribute(DescriptorAttributes.Configurable))
                Configurable = genDescriptor.Configurable;
        }
    }
}
