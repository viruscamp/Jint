using System;
namespace Jint.Native
{
    public interface INativeIndexer
    {
        IJsObject get(IJsObject that, IJsObject index);
        void set(IJsObject that, IJsObject index, IJsObject value);
    }
}
