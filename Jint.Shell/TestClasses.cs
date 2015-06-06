using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Shell
{

    internal class A
    {
    }

    public interface I1
    {
        int Count { get; }
        I2 I2 { get; }
    }

    public class CI1 : I1
    {
        public int Count { get; set; }

        private CI2 c2 = new CI2();
        public I2 I2 { get { return c2; } }
        public CI2 CI2 { get { return c2; } }

    }

    public interface I2
    {
        int Count { get; }

        I3 I3 { get; }

        void Run();

    }

    public class CI2 : I2
    {
        public int Count { get; set; }

        private CI3 c3 = new CI3();
        public I3 I3 { get { return c3; } }

        private SI3 s3 = new SI3();
        public I3 SI3 { get { return s3; } }

        public void Run()
        {
            Console.WriteLine("CI2");
        }
    }

    public interface I3
    {
        void Run();
        int I { get; }
    }

    class CI3 : I3, I2
    {
        public int Count { get; set; }

        private int i = 3333;
        public int I
        {
            get
            {
                return i;
            }
            set
            {
                i = value;
            }
        }

        void I3.Run()
        {
            Console.WriteLine("CI3.I3.Run");
        }

        public void Run()
        {
            Console.WriteLine("CI3.Run");
        }

        public void Run2()
        {
            Console.WriteLine("CI3.Run2");
        }

        public I3 I3
        {
            get { throw new NotImplementedException(); }
        }
    }

    struct SI3 : I3
    {
        int i;

        public void Run()
        {
            Console.WriteLine("SI3 Run");
            i = 44444;
        }

        public int I
        {
            get { return i; }
        }

        public void Run2()
        {
            Console.WriteLine("SI3 Run2");
        }
    }
}
