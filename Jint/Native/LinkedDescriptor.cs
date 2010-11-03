using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native
{
    class LinkedDescriptor : Descriptor
    {
        Descriptor d;

        public LinkedDescriptor(JsDictionaryObject owner, string name, Descriptor source)
            : base(owner, name)
        {
            d = source;
            Enumerable = true;
            Writable = true;
            Configurable = true;
        }

        public override JsInstance Get(JsDictionaryObject that)
        {
            return d.Get(d.Owner);
        }

        public override void Set(JsDictionaryObject that, JsInstance value)
        {
            d.Set(d.Owner,value);
        }

        internal override DescriptorType DescriptorType
        {
            get { return DescriptorType.Value; }
        }
    }
}
