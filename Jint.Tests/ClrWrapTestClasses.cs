using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Tests.ClrWrap
{
    public interface IParent1
    {
        string MP1();
        string MP2();
    }

    public interface IChild1 : IParent1
    {
        string MC1();
    }

    public class CBase1
    {
        public string MB1()
        {
            return "CBase1.MB1";
        }

        public virtual string MB2()
        {
            return "CBase1.MB2";
        }

        public override string ToString()
        {
            return "CBase1.ToString";
        }
    }

    public class C1 : CBase1, IChild1
    {
        private static readonly C1 instance = new C1();
        public static C1 Instance { get { return instance; } }
        public static CBase1 CBase1 { get { return instance; } }
        public static IChild1 IChild1 { get { return instance; } }
        public static IParent1 IParent1 { get { return instance; } }
        public static object Object { get { return instance; } }

        public string MC1()
        {
            return "C1.MC1";
        }

        public string MP1()
        {
            return "C1.MP1";
        }

        string IParent1.MP1()
        {
            return "C1.IParent1.MP1";
        }

        string IParent1.MP2()
        {
            return "C1.IParent1.MP2";
        }

        public new string MB1()
        {
            return "C1.MB1";
        }

        public string M1()
        {
            return "C1.M1";
        }

        public new string ToString()
        {
            return "C1.ToString";
        }
    }
}
