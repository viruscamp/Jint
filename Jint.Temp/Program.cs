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
            //ExecutionVisitor visitor = new ExecutionVisitor(Options.Strict | Options.Ecmascript3);

            //ClrConstructor ctor = new ClrConstructor(typeof(Baz), visitor.Global);
            //ctor.InitPrototype(visitor.Global);

            
            return;
        }
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
        public static T Arrays<T>() where T: new() {
            return new T();
        }
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
