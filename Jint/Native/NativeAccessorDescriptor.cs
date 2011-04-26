using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Jint;
using Jint.Marshal;

namespace Jint.Native
{
    /// <summary>
    /// A wrapper around native property getter.
    /// </summary>
    /// <param name="that">A target object</param>
    /// <returns>A value of a property</returns>
    public delegate IJsObject JsGetter(IJsObject that);

    /// <summary>
    /// A wrapper around native property setter
    /// </summary>
    /// <param name="that">A target object</param>
    /// <param name="value">A new value for the property</param>
    public delegate void JsSetter(IJsObject that, IJsObject value);

    /// <summary>
    /// Descriptor which get and set methods are implemented through delegates
    /// </summary>
    public class NativeAccessorDescriptor : Descriptor
    {
        public NativeAccessorDescriptor(JsObjectBase owner, string name, JsGetter getter)
            : base(owner, name)
        {
            this.getter = getter;
            Writable = false;
        }

        public NativeAccessorDescriptor(IJsObject owner, string name, JsGetter getter, JsSetter setter)
            : base(owner, name)
        {
            this.getter = getter;
            this.setter = setter;
        }

        public NativeAccessorDescriptor(IJsObject owner, NativeAccessorDescriptor src)
            : base(owner, src.Name)
        {
            getter = src.getter;
            setter = src.setter;
            Writable = src.Writable;
            Configurable = src.Configurable;
            Enumerable = src.Enumerable;
        }

        JsGetter getter;
        JsSetter setter;

        public override bool isReference {
            get { return false; }
        }

        public override Descriptor Clone() {
            return new NativeAccessorDescriptor(Owner, this);
        }

        public override IJsObject Get(IJsObject that)
        {
            return getter != null ? getter(that) : JsUndefined.Instance ;
        }

        public override void Set(IJsObject that, IJsObject value)
        {
            if (setter != null)
                setter(that, value);
        }

        internal override DescriptorType DescriptorType
        {
            get { return DescriptorType.Accessor; }
        }


    }
}
