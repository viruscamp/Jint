using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jint;
using Jint.Native;

namespace Jint.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Jint.JintEngine();
            engine.SetDebugMode(true);
            engine.Run("1;");
            var method = new ClrConstructorWrapper(typeof(TestObject).GetConstructor(Type.EmptyTypes), engine.visitor.Global.FunctionClass.PrototypeProperty, true );
            method.Construct(new JsInstance[0],null,engine.visitor);

        }
    }

    public class TestObject
    {
        public void Foo()
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
