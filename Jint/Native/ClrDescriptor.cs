using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Jint;

namespace Jint.Native
{
    class ClrDescriptor : Descriptor
    {
        public delegate JsInstance JsGetter(JsDictionaryObject that);
        public delegate void JsSetter(JsDictionaryObject that, JsInstance value);
        public delegate TVal NativeGetter<TTarget,TVal>(TTarget that);
        public delegate void NativeSetter<TTarget,TVal>(TTarget that,TVal value);

        ClrDescriptor(JsDictionaryObject owner, string name, JsGetter getter)
            : base(owner, name)
        {
            this.getter = getter;
            Writable = false;
        }

        ClrDescriptor(JsDictionaryObject owner, string name, JsGetter getter, JsSetter setter)
            : base(owner, name)
        {
            this.getter = getter;
            this.setter = setter;
        }

        JsGetter getter;
        JsSetter setter;

        public override JsInstance Get(JsDictionaryObject that)
        {
            return getter != null ? getter(that) : JsUndefined.Instance ;
        }

        public override void Set(JsDictionaryObject that, JsInstance value)
        {
            if (setter != null)
                setter(that, value);
        }

        internal override DescriptorType DescriptorType
        {
            get { return DescriptorType.Clr; }
        }

        JsGetter WrapPropertyGetter<TTarget,TVal>(NativeGetter<TTarget,TVal> get,Marshal marshaller)
        {
            return delegate(JsDictionaryObject target)
            {
                return marshaller.ClrToJsValue<TVal>(
                    get(
                        marshaller.JsToClrValue<TTarget>(target)
                    )
                );
            };
        }

        JsSetter WrapPropertySetter<TTarget, TVal>(NativeSetter<TTarget, TVal> set, Marshal marshaller)
        {
            return delegate(JsDictionaryObject target, JsInstance val)
            {
                set(
                    marshaller.JsToClrValue<TTarget>(target),
                    marshaller.JsToClrValue<TVal>(val)
                );
            };
        }

        public static ClrDescriptor WrapPropertyInfo(PropertyInfo prop)
        {
            if (prop.CanRead)
            {
                if (prop.CanWrite)
                {
                    prop.GetGetMethod();
                    //return 
                }
            }
        }
    }
}
