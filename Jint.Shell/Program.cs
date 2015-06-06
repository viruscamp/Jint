﻿using System;
using System.Collections.Generic;
using Antlr.Runtime;
using System.IO;
using System.Reflection;
using Jint.Expressions;
using System.Text;
using Jint.Native;

namespace Jint.Shell {
    class Program {
        static JintEngine NewJint()
        {
            var jint = new JintEngine();

            jint.SetFunction("print", new Action<object>(s => { Console.ForegroundColor = ConsoleColor.Blue; Console.Write(s); Console.ResetColor(); }));
            jint.SetFunction("import", new Action<string>(s => { Assembly.LoadWithPartialName(s); }));
            jint.DisableSecurity();

            jint.SetParameter("i1", new CI1());

            return jint;
        }

        static void Main(string[] args) {

            string line;

            var jint = NewJint();

            while (true) {
                Console.Write("jint > ");

                StringBuilder script = new StringBuilder();

                while (String.Empty != (line = Console.ReadLine())) {
                    if (line.Trim() == "exit") {
                        return;
                    }

                    if (line.Trim() == "reset") {
                        jint = NewJint();
                        break;
                    }

                    if (line.Trim() == "help" || line.Trim() == "?") {
                        Console.WriteLine(@"Jint Shell");
                        Console.WriteLine(@"");
                        Console.WriteLine(@"exit                - Quits the application");
                        Console.WriteLine(@"import(assembly)    - assembly: String containing the partial name of a .NET assembly to load");
                        Console.WriteLine(@"reset               - Initialize the current script");
                        Console.WriteLine(@"print(output)       - Prints the specified output to the console");
                        Console.WriteLine(@"");
                        break;
                    }

                    script.AppendLine(line);
                }

                Console.SetError(new StringWriter(new StringBuilder()));

                try {
                    var ret = jint.Run(script.ToString());
                    if (ret != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(ret.ToString());
                        Console.ResetColor();
                    }
                }
                catch (Exception e) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}