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

        struct MethodMatch
        {
            public MethodInfo method;
            public int weight;
            public Type[] parameters;
        }

        // a list of methods
        LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
        
        // a list of generics which parameters could be suggested from passed arguments
        LinkedList<MethodInfo> m_autoGenerics = new LinkedList<MethodInfo>();
        
        // a list of generucs which requires explicit parameters
        LinkedList<MethodInfo> m_manualGenerics = new LinkedList<MethodInfo>();
        

        public ClrOverload(ICollection<MethodInfo> methods , JsObject prototype)
            : base(prototype)
        {
        }

        MethodInfo MatchMethod(Type[] agrs, Type[] genericArguments)
        {
            LinkedList<MethodMatch> matches = new LinkedList<MethodMatch>();
            if (genericArguments != null && genericArguments.Length > 0)
            {
                // we have an explicit generic parameters
                foreach (var list in new ICollection<MethodInfo>[] { m_autoGenerics, m_manualGenerics })
                {
                    foreach (var item in list)
                    {
                        MethodMatch match = new MethodMatch() { weight = 0 };
                        if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == agrs.Length)
                        {
                            try
                            {
                                match.method = item.MakeGenericMethod(genericArguments);
                                match.parameters = Array.ConvertAll<ParameterInfo, Type>(match.method.GetParameters(), pi => pi.ParameterType);
                                matches.AddLast(match);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            else
            {

            }
        }

        string MakeKey(Type[] types)
        {
            return String.Join(",", Array.ConvertAll<Type, String>(types, delegate(Type item) { return item.FullName; }));
        }
    }
}
