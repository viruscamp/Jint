using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Jint.Native;
using Jint.Debugger;

namespace Jint.Play
{
    class Program
    {
        static void Main(string[] args)
        {

            var assembly = Assembly.Load("Jint.Tests");
            Stopwatch sw = new Stopwatch();

            string script = new StreamReader(assembly.GetManifestResourceStream("Jint.Tests.Parse.coffeescript-debug.js")).ReadToEnd();
            JintEngine jint = new JintEngine()
                // .SetDebugMode(true)
                .DisableSecurity()
                .SetFunction("print", new Action<string>(Console.WriteLine))
                .SetFunction("write", new Action<string>(Console.WriteLine))
                .SetFunction("stop", new Action(delegate() { Console.WriteLine(); }));
            sw.Reset();
            sw.Start();

            jint.Run(script);
            try
            {
                var result = jint.Run("CoffeeScript.compile('number = 42', {bare: true})");
            }
            catch (JintException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
        }
    }
}

