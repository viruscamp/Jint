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

            JsConstructor ctor = visitor.Global.Marshaller.MarshalType(typeof(Baz));
            ((JsObject)visitor.Global)["Baz"] = ctor;

            var obj = new Baz();
            var now = DateTime.Now;
            obj.SetTimestamp(now);

            engine.Run(@"
var test = new Baz();
var val;

System.Console.WriteLine('test.CurrentValue: {0}', test.CurrentValue);
System.Console.WriteLine('Update object');
var now = DateTime.Now;
test.SetName('Bill');
test.SetTimestamp(now);
System.Console.WriteLine('test.CurrentValue: {0}', test.CurrentValue);

System.Console.WriteLine('Is instance of Baz: {0}', test instanceof Baz ? 'yes' : 'no' );
System.Console.WriteLine('Is instance of Object: {0}', test instanceof Object ? 'yes' : 'no' );
System.Console.WriteLine('Is instance of String: {0}', test instanceof String ? 'yes' : 'no' );

System.Console.WriteLine('=========TYPE INFORMATION==========');
System.Console.WriteLine('[{1}] {0}', test.GetType().FullName, test.GetType().GUID);
for(var prop in test.GetType()) {
    try {
        val = Baz[prop];
    } catch (err) {
        val = 'Exception: ' + err.toString();
    }

    System.Console.WriteLine('{0} = {1}',prop,val);
}
");

            //JsInstance inst = ctor.Construct(new JsInstance[0], null, visitor);
            
            return;
        }
    }

    public struct DummyStruct
    {
        public int x;
        public DateTime t;

        public void SetTime(DateTime time)
        {
            t = time;
        }

        public DateTime CurrentValue
        {
            get { return t; }
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
        string m_name;
        DateTime m_timestamp;
        public Baz(string name)
        {
            m_name = name;
        }
        public Baz()
        {
            m_timestamp = new DateTime(1980, 1, 1);
        }

        public void SetTimestamp(DateTime date) {
            m_timestamp = date;
        }

        public void SetName(string name)
        {
            m_name = name;
        }

        public DateTime CurrentValue
        {
            get { return m_timestamp; }
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
