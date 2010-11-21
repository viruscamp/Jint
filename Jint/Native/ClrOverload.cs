using System;
using System.Collections.Generic;
using System.Text;
using Jint.Marshal;
using System.Reflection;

namespace Jint.Native
{
    class ClrOverload : JsFunction
    {

        Dictionary<string, JsMethodImpl> m_protoCache = new Dictionary<string, JsMethodImpl>();
        Dictionary<MethodInfo, JsMethodImpl> m_reflectCache = new Dictionary<MethodInfo, JsMethodImpl>();
        Marshaller m_marshaller;

        class MethodMatch
        {
            public MethodInfo method;
            public int weight;
            public Type[] parameters;
        }

        // a list of methods
        LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
        
        // a list of generics
        LinkedList<MethodInfo> m_generics = new LinkedList<MethodInfo>();

        public ClrOverload(ICollection<MethodInfo> methods , JsObject prototype, IGlobal global)
            : base(prototype)
        {
            if (global == null)
                throw new ArgumentNullException("global");
            m_marshaller = global.Marshaller;

            foreach (var method in methods)
            {
                if (method.IsGenericMethodDefinition)
                    m_generics.AddLast(method);
                else if (! method.ContainsGenericParameters)
                    m_methods.AddLast(method);
            }
        }

        MethodInfo MatchMethod(Type[] args, Type[] genericArguments)
        {
            LinkedList<MethodMatch> matches = new LinkedList<MethodMatch>();
            if (genericArguments != null && genericArguments.Length > 0)
            {

                foreach (var item in m_generics)
                {
                    MethodMatch match = new MethodMatch() { weight = 0 };
                    // try specialize generics
                    if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == args.Length)
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

            foreach (var item in m_methods)
            {
                ParameterInfo[] parameters = item.GetParameters();
                if (parameters.Length != args.Length)
                    continue;
                matches.AddLast( new MethodMatch() {
                    weight = 0,
                    parameters = Array.ConvertAll<ParameterInfo,Type>(parameters, pi => pi.ParameterType),
                    method = item
                });

            }

            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Type t = args[i];
                    for(var node = matches.First; node != null; ) {
                        if (t != null)
                        {
                            if (t.Equals(node.Value.parameters[i]))
                            {
                                node.Value.weight += 1;
                            }
                            else if (!node.Value.parameters[i].IsAssignableFrom(t))
                            {
                                var old = node;
                                node = node.Next;
                                matches.Remove(old);
                            }
                        }
                        else
                        {
                            // we can't assign undefined or null values to a value types
                            if (node.Value.parameters[i].IsValueType)
                            {
                                var old = node;
                                node = node.Next;
                                matches.Remove(old);
                            }
                        }
                        node = node.Next;
                    }
                }
            }

            MethodMatch best = null;

            foreach (var match in matches)
                best = best == null ? match : (best.weight < match.weight ? match : best);

            return best.method;
        }

        string MakeKey(Type[] types,Type[] genericArguments )
        {
            return
                "<"
                + String.Join(
                    ",",
                    Array.ConvertAll<Type,string>(
                        genericArguments ?? new Type[0],
                        t => t == null ? "<null>" : t.FullName
                    )
                )
                + ">"
                + String.Join(
                    ",",
                    Array.ConvertAll<Type, String>(
                        types ?? new Type[0],
                        t => t.FullName
                    )
                );
        }

        JsMethodImpl ResolveOverload(JsInstance[] args, Type[] generics)
        {
            Type[] argTypes = Array.ConvertAll<JsInstance,Type>(args, x => m_marshaller.GetInstanceType(x));
            string key = MakeKey(argTypes, generics);
            JsMethodImpl method;
            if (!m_protoCache.TryGetValue(key,out method))
            {
                MethodInfo info = MatchMethod(argTypes, generics);
                
                if (info != null && !m_reflectCache.TryGetValue(info,out method))
                    m_reflectCache[info] = method = m_marshaller.WrapMethod(info, true);

                m_protoCache[key] = method;
            }

            return method;
        }

        public override JsInstance Execute(Jint.Expressions.IJintVisitor visitor, JsDictionaryObject that, JsInstance[] parameters)
        {
            JsMethodImpl impl = ResolveOverload(parameters, null);
            if (impl == null)
                throw new JintException("No matching overload found");
            visitor.Return(impl(visitor.Global,that,parameters));
            return that;
        }
    }
}
