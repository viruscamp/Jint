using System;
namespace Jint.Native
{
    public interface INativeIndexer
    {
        IJsInstance get(IJsInstance that, IJsInstance index);
        void set(IJsInstance that, IJsInstance index, IJsInstance value);
    }
}
