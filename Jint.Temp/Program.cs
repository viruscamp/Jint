using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jint;
using Jint.Native;
using System.Reflection;

namespace Jint.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            JintEngine engine = new JintEngine();
            engine.Run("1;");
            ExecutionVisitor visitor = engine.visitor;

            ClrConstructor ctor = new ClrConstructor(typeof(Baz), visitor.Global);
            ctor.InitPrototype(visitor.Global);
            ((JsObject)visitor.Global)["Baz"] = ctor;

            object result = engine.Run("new Baz('hooray!');");

            //JsInstance inst = ctor.Construct(new JsInstance[0], null, visitor);
            
            return;
        }
    }

    public struct DummyStruct
    {
        public int x;
        public DateTime t;
    }

    public class Bar<T1>
    {
        public T2 Fn<T2,T3>(T1 a1, T2 a2)
        {
            return default(T2);
        }
    }

    public class Baz
    {
        string m_name;
        public Baz(string name)
        {
            m_name = name;
        }
        public static T Arrays<T>() where T: new() {
            return new T();
        }

        public static void UpdateObject<T>(T val)
        {

        }

        public static void ByRefArg(ref DummyStruct i, ref Baz o, out int res)
        {
            res = default(int);
            i.ToString();
            o.Foo();
            o.Zoo(i);
        }

        public void Foo()
        {
        }
        public virtual void Zoo(DummyStruct z)
        {
        }
        public int Foo(int a)
        {
            return a;
        }
        public int Foo(int a, int b)
        {
            return a + b;
        }
        public T Foo<T>(T a, T b)
        {
            return b;
        }
        public T Foo<T>(T a)
        {
            return a;
        }
        public T1 Foo<T1,T2>(T1 a, T2 b)
        {
            return a;
        }
    }
}
