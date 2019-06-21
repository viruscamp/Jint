using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jint.Native;

namespace Jint.Tests
{
	[TestClass]
    public class ClrWrapTest : TestsBase
    {
        protected object TestNonStrict(string script, Action<JintEngine> action)
        {
            return Test(Options.Ecmascript5, script, action);
        }

        private object UnWrap(object o)
        {
            return ((JsObject)o).Value;
        }

        private Type GetWrapType(JsObject o)
        {
            var clrtype = (ClrTypePrototype)o.Prototype;
            return clrtype.WrapType;
        }

        private T ShouldBeJsObjectOfType<T>(object o)
        {
            Assert.IsInstanceOfType(o, typeof(JsObject));
            var jo = (JsObject)o;
            Assert.IsInstanceOfType(jo.Value, typeof(T));
            Assert.AreEqual(typeof(T), GetWrapType(jo));

            return (T)jo.Value;
        }

        private Exception RunAndCatch(JintEngine jint, string script)
        {
            try
            {
                jint.Run(script);
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

        [TestMethod]
        public void WrapObjectAsSameType()
        {
            TestNonStrict("return true;", jint =>
            {
                var jo = jint.Run("o=Jint.Tests.ClrWrap.C1.Instance;return o;", false);
                var o = ShouldBeJsObjectOfType<Jint.Tests.ClrWrap.C1>(jo);

                Assert.AreEqual(jint.Run("o.ToString()"), o.ToString());
                Assert.AreEqual(jint.Run("o.MP1()"), o.MP1());
                //Assert.AreEqual(jint.Run("o.MP2()"), o.MP2());
                Assert.AreEqual(jint.Run("o.MC1()"), o.MC1());
                Assert.AreEqual(jint.Run("o.MB1()"), o.MB1());
                Assert.AreEqual(jint.Run("o.MB2()"), o.MB2());
                Assert.AreEqual(jint.Run("o.M1()"), o.M1());

                Assert.IsInstanceOfType(RunAndCatch(jint, "o.MP2()"), typeof(JintException));
            });
        }

        [TestMethod]
		public void WrapInterface()
		{
            TestNonStrict("return true;", jint =>
            {
                var jo = jint.Run("o=Jint.Tests.ClrWrap.C1.IChild1;return o;", false);
                var o = ShouldBeJsObjectOfType<Jint.Tests.ClrWrap.IChild1>(jo);

                var c1 = jint.Run("c1=Jint.Tests.ClrWrap.C1.Instance;return c1;", false);
                Assert.AreSame(UnWrap(c1), o);

                Assert.AreEqual(jint.Run("o.ToString()"), o.ToString());
                Assert.AreEqual(jint.Run("o.MP1()"), o.MP1());
                Assert.AreEqual(jint.Run("o.MP2()"), o.MP2());
                Assert.AreEqual(jint.Run("o.MC1()"), o.MC1());
                //Assert.AreEqual(jint.Run("o.MB1()"), ((Jint.Tests.ClrWrap.C1)o).MB1());
                //Assert.AreEqual(jint.Run("o.MB2()"), ((Jint.Tests.ClrWrap.C1)o).MB2());
                //Assert.AreEqual(jint.Run("o.M1()"), ((Jint.Tests.ClrWrap.C1)o).M1());
            });
		}

		[TestMethod]
		public void WrapExplicitInterface()
		{
            TestNonStrict("return true;", jint =>
            {
                var jo = jint.Run("o=Jint.Tests.ClrWrap.C1.IParent1;return o;", false);
                var o = ShouldBeJsObjectOfType<Jint.Tests.ClrWrap.IParent1>(jo);

                var c1 = jint.Run("c1=Jint.Tests.ClrWrap.C1.Instance;return c1;", false);
                Assert.AreSame(UnWrap(c1), o);

                Assert.AreEqual(jint.Run("o.ToString()"), o.ToString());
                Assert.AreEqual(jint.Run("o.MP1()"), o.MP1());
                Assert.AreEqual(jint.Run("o.MP2()"), o.MP2());
                //Assert.AreEqual(jint.Run("o.MC1()"), ((Jint.Tests.ClrWrap.C1)o).MC1());
                //Assert.AreEqual(jint.Run("o.MB1()"), ((Jint.Tests.ClrWrap.C1)o).MB1());
                //Assert.AreEqual(jint.Run("o.MB2()"), ((Jint.Tests.ClrWrap.C1)o).MB2());
                //Assert.AreEqual(jint.Run("o.M1()"), ((Jint.Tests.ClrWrap.C1)o).M1());
            });
        }

		[TestMethod]
		public void WrapBaseClass()
		{
            TestNonStrict("return true;", jint =>
            {
                var jo = jint.Run("o=Jint.Tests.ClrWrap.C1.CBase1;return o;", false);
                var o = ShouldBeJsObjectOfType<Jint.Tests.ClrWrap.CBase1>(jo);

                var c1 = jint.Run("c1=Jint.Tests.ClrWrap.C1.Instance;return c1;", false);
                Assert.AreSame(UnWrap(c1), o);

                Assert.AreEqual(jint.Run("o.ToString()"), o.ToString());
                //Assert.AreEqual(jint.Run("o.MP1()"), ((Jint.Tests.ClrWrap.C1)o).MP1());
                //Assert.AreEqual(jint.Run("o.MP2()"), o.MP2());
                //Assert.AreEqual(jint.Run("o.MC1()"), ((Jint.Tests.ClrWrap.C1)o).MC1());
                Assert.AreEqual(jint.Run("o.MB1()"), o.MB1());
                Assert.AreEqual(jint.Run("o.MB2()"), o.MB2());
                //Assert.AreEqual(jint.Run("o.M1()"), ((Jint.Tests.ClrWrap.C1)o).M1());

                Assert.IsInstanceOfType(RunAndCatch(jint, "o.MP2()"), typeof(JintException));
            });
        }

        [TestMethod]
        public void WrapObject()
        {
            TestNonStrict("return true;", jint =>
            {
                var jo = jint.Run("o=Jint.Tests.ClrWrap.C1.Object;return o;", false);
                var o = ShouldBeJsObjectOfType<object>(jo);

                var c1 = jint.Run("c1=Jint.Tests.ClrWrap.C1.Instance;return c1;", false);
                Assert.AreSame(UnWrap(c1), o);

                Assert.AreEqual(jint.Run("o.ToString()"), o.ToString());
                //Assert.AreEqual(jint.Run("o.MP1()"), ((Jint.Tests.ClrWrap.C1)o).MP1());
                //Assert.AreEqual(jint.Run("o.MP2()"), o.MP2());
                //Assert.AreEqual(jint.Run("o.MC1()"), ((Jint.Tests.ClrWrap.C1)o).MC1());
                //Assert.AreEqual(jint.Run("o.MB1()"), ((Jint.Tests.ClrWrap.C1)o).MB1());
                //Assert.AreEqual(jint.Run("o.MB2()"), ((Jint.Tests.ClrWrap.C1)o).MB2());
                //Assert.AreEqual(jint.Run("o.M1()"), ((Jint.Tests.ClrWrap.C1)o).M1());

                Assert.IsInstanceOfType(RunAndCatch(jint, "o.MP2()"), typeof(JintException));
            });
        }

        [TestMethod]
		[ExpectedException(typeof(JintException))]
		public void CastToOnNonClr_ShouldException()
		{
		}

		[TestMethod]
		public void CastToBaseClass()
		{
		}

		[TestMethod]
		public void CastToInterface()
		{
		}

		[TestMethod]
		public void CastToValueType()
		{
		}

		[TestMethod]
		public void CastToThenCastBack()
		{
		}

		[TestMethod]
		public void ComObjectCastToInterface()
		{
		}

		[TestMethod]
		public void ComObjectCastToThenCastBack()
		{
		}

		[TestMethod]
		[ExpectedException(typeof(JintException))]
		public void GetWrapTypeOnNonClr_ShouldException()
		{
		}

		[TestMethod]
		public void GetWrapTypeOnClrObject()
		{
		}

		[TestMethod]
		public void GetWrapTypeOnClrType()
		{
		}

		[TestMethod]
		public void GetWrapTypeOnClrDelegate()
		{
		}

		/// <summary>
		/// <see cref="Jint.Native.JDictionaryObject.this[string]"/>
		/// </summary>
		[TestMethod]
		public void SetClrNewProperty()
		{
			// no exception, no effect
		}

		/// <summary>
		/// <see cref="Jint.Native.JDictionaryObject.this[string]"/>
		/// </summary>
		[TestMethod]
		public void SetClrMethod()
		{
			// no exception, no effect
		}
	}
}
