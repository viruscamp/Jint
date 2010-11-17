using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Jint.Native
{
    /// <summary>
    /// A constructor function that reflects a native clr type to the js runtime.
    /// </summary>
    /// <remarks>
    /// <pre>
    /// When applied to the object, it fills a special slot with new clr object and defines
    /// new properties according to the netive fields and properties.
    /// </pre>
    /// <pre>
    /// Instance methods are derived through prototype.
    /// </pre>
    /// <pre>
    /// Static methods, properties and fields are defined as properties of the constructor.
    /// </pre>
    /// <pre>Generics? hm...</pre>
    /// </remarks>
    class ClrConstructor: JsConstructor
    {
        Type reflectedType;

        LinkedList<Descriptor> properties = new LinkedList<Descriptor>();

        public ClrConstructor(Type type, IGlobal global) :
            base(global)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            reflectedType = type;

            // now we should find all static members and add them as a properties

            Dictionary< string, LinkedList<MethodInfo> > members = new Dictionary<string,LinkedList<MethodInfo>>();

            foreach (var info in type.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (members[info.Name] == null)
                    members[info.Name] = new LinkedList<MethodInfo>();
                members[info.Name].AddLast(info);
            }

            foreach (var pair in members)
            {
                this[pair.Key] = pair.Value.Count > 1 ?
                    (JsFunction)new ClrOverload(pair.Value, Global.FunctionClass.PrototypeProperty, Global) :
                    (JsFunction)new ClrMethodWrapper(pair.Value.First.Value, Global.FunctionClass.PrototypeProperty);
            }

            foreach (var info in type.GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
                ;

            foreach (var info in type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                properties.AddLast(global.Marshaller.MarshalPropertyInfo(info,this) );

            foreach (var info in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public) )
                properties.AddLast(global.Marshaller.MarshalFieldInfo(info,this));

        }

        private IEnumerable<JsFunction> MapMethodInfo(IEnumerable<MethodInfo> list)
        {
            foreach (var item in list)
                yield return new ClrMethodWrapper(item, Global.FunctionClass.PrototypeProperty, true);
        }


        public override void InitPrototype(IGlobal global)
        {
            throw new NotImplementedException();
        }
    }
}
