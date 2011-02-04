using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jint;
using Jint.Native;
using System.Reflection;

namespace Jint.Temp {
    class Program {
        static void Main(string[] args) {

            JintEngine eng = new JintEngine();
            JsObject j2 = new JsObject();
            j2["ala"] = new JsString("ma kota", eng.visitor.Global.StringClass);
            eng.SetParameter("j2", j2);
            eng.Run("System.Console.WriteLine('j2 is {0}', j2.ala);");

            return;

            JintEngine engine = new JintEngine();
            engine.DisableSecurity();
            engine.Run("1;");
            ExecutionVisitor visitor = engine.visitor;
            Marshaller marshal = visitor.Global.Marshaller;

            JsConstructor ctor = visitor.Global.Marshaller.MarshalType(typeof(Baz));
            ((JsObject)visitor.Global)["Baz"] = ctor;
            ((JsObject)visitor.Global)["Int32"] = visitor.Global.Marshaller.MarshalType(typeof(Int32));

            JsObject t = new JsObject();
            t["abc"] = new JsString("sure",engine.visitor.Global.StringClass); 
            engine.SetParameter("t", t );

            engine.Run(@"
System.Console.WriteLine('{0}',t.abc);
System.Console.WriteLine('{0}',Jint.Temp.InfoType.Name);
");

            

            engine.Run(@"
System.Console.WriteLine('=========FEATURES==========');
var test = new Baz();
var val;
System.Console.WriteLine('test.Name: {0}', test.Name);
System.Console.WriteLine('test.CurrentValue: {0}', test.CurrentValue);

System.Console.WriteLine('Update object using method');
test.SetTimestamp(System.DateTime.Now);
System.Console.WriteLine('test.CurrentValue: {0}', test.CurrentValue);

System.Console.WriteLine('Update object using property');
test.CurrentValue = new System.DateTime(1980,1,1);
System.Console.WriteLine('test.CurrentValue: {0}', test.CurrentValue);

System.Console.WriteLine('Update object using field');
test.t = new System.DateTime(1980,1,2);
System.Console.WriteLine('test.CurrentValue: {0}', test.CurrentValue);


System.Console.WriteLine('Is instance of Baz: {0}', test instanceof Baz ? 'yes' : 'no' );
System.Console.WriteLine('Is instance of Object: {0}', test instanceof Object ? 'yes' : 'no' );
System.Console.WriteLine('Is instance of String: {0}', test instanceof String ? 'yes' : 'no' );

System.Console.WriteLine('Constant field Int32.MaxValue: {0}', Int32.MaxValue);

System.Console.WriteLine('========= INHERITANCE FROM A CLR TYPE ==========');
function Foo(name,desc) {
    Baz.call(this,name);

    this.Description = desc;
    this.SetTimestamp(System.DateTime.Now);
}

(function(){
    var func = new Function();
    func.prototype = Baz.prototype;
    Foo.prototype = new func();
    Foo.prototype.constructor = Foo;
})();

Foo.prototype.PrintInfo = function() {
    System.Console.WriteLine('{0}: {1} ({2})', this.Name,this.Description,this.t);
}

var foo = new Foo('Gib','Mega mann');
foo.PrintInfo();

System.Console.WriteLine('========= DUMP OBJECT ==========');

function ___StandAlone() {}

for (var prop in foo){
    try {
        val = foo[prop];
    } catch(err) {
        val = 'Exception: ' + err.toString();
    }
    System.Console.WriteLine('{0} = {1}',prop,val.toString());
}

System.Console.WriteLine('========= DUMP PROTOTYPE ==========');

foo = Foo.prototype;

for (var prop in foo){
    try {
        val = foo[prop];
    } catch(err) {
        val = 'Exception: ' + err.toString();
    }
    System.Console.WriteLine('{0} = {1}',prop,val.toString());
}

System.Console.WriteLine('========= DUMP OBJECT PROTOTYPE ==========');

foo = Object.prototype;

for (var prop in foo){
    try {
        val = foo[prop];
    } catch(err) {
        val = 'Exception: ' + err.toString();
    }
    System.Console.WriteLine('{0} = {1}',prop,val.toString());
}

System.Console.WriteLine('========= TYPE INFORMATION ==========');
//System.Console.WriteLine('[{1}] {0}', test.GetType().FullName, test.GetType().GUID);
for(var prop in Baz) {
    try {
        val = Baz[prop];
    } catch (err) {
        val = 'Exception: ' + err.toString();
    }

    System.Console.WriteLine('{0} = {1}',prop,val);
}

System.Console.WriteLine('========= PERFORMANCE ==========');
");
            int ticks = Environment.TickCount;
            engine.Run(@"
            var temp;
            for (var i = 0; i < 100000; i++)
                temp = new Baz('hi');
            ");

            Console.WriteLine("new objects: {0} ms", Environment.TickCount - ticks);
            
            ticks = Environment.TickCount;
            engine.Run(@"
            var temp = new Baz();
            var val = ToInt32(20);
            System.Console.WriteLine('Debug: {0} + {1} = {2}', '10', val, temp.Foo('10',val));
            for (var i = 0; i < 100000; i++)
                temp.Foo('10',val);
            ");

            Console.WriteLine("method call in {0} ms", Environment.TickCount - ticks);

            ticks = Environment.TickCount;
            engine.Run(@"
            var temp = new Baz();
            for (var i = 0; i < 100000; i++)
                temp.Foo();
            ");

            Console.WriteLine("method call without args {0} ms", Environment.TickCount - ticks);

            ticks = Environment.TickCount;
            engine.Run(@"
            var temp = new Baz();
            for (var i = 0; i < 100000; i++)
                temp.CurrentValue;
            ");

            Console.WriteLine("get property {0} ms", Environment.TickCount - ticks);

            ticks = Environment.TickCount;
            engine.Run(@"
            var temp = new Baz();
            for (var i = 0; i < 100000; i++)
                temp.t;
            ");

            Console.WriteLine("get field {0} ms", Environment.TickCount - ticks);

            ticks = Environment.TickCount;
            engine.Run(@"
            for (var i = 0; i < 100000; i++)
                /**/1;
            ");

            Console.WriteLine("empty loop {0} ms", Environment.TickCount - ticks);

            //JsInstance inst = ctor.Construct(new JsInstance[0], null, visitor);

            Console.ReadKey();
            
            return;
        }
    }

    public enum InfoType
    {
        Type = 1,
        Name = 2,
        Description = 3
    }

    public struct DummyStruct
    {
        public int x;
        public DateTime t;

        public string Name
        {
            get { return "Bill"; }
        }

        public void SetTimestamp(DateTime time)
        {
            t = time;
        }

        public DateTime CurrentValue
        {
            get { return t; }
            set { t = value; }
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
        public DateTime t;
        public Baz(string name)
        {
            m_name = name;
        }
        public Baz()
        {
            m_name = "Bazz";
            t = new DateTime(1980, 1, 1);
        }

        public void SetTimestamp(DateTime date) {
            t = date;
        }

        public void SetName(string name)
        {
            m_name = name;
        }

        public DateTime CurrentValue
        {
            get { return t; }
            set { t = value; }
        }

        public string Name
        {
            get { return m_name; }
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
