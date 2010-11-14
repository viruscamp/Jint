using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;
using System.Reflection;

namespace Jint.Native
{
    class ClrOverload : JsFunction
    {

        Dictionary<string, JsMethodImpl> m_cache = new Dictionary<string, JsMethodImpl>();

        LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
        LinkedList<MethodInfo> m_autoGenerics = new LinkedList<MethodInfo>();
        LinkedList<MethodInfo> m_manualGenerics = new LinkedList<MethodInfo>();
        

        public ClrOverload(ICollection<MethodInfo> methods , JsObject prototype)
            : base(prototype)
        {
        }

        string MakeKey(Type[] types)
        {
            return String.Join(",", Array.ConvertAll<Type, String>(types, delegate(Type item) { return item.FullName; }));
        }
    }
}
