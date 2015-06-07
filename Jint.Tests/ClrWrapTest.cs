using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jint.Tests
{
	[TestClass]
	public class ClrWrapTest
	{
		[TestMethod]
		public void WrapInterface()
		{
		}

		[TestMethod]
		public void WrapExplicitInterface()
		{
		}

		[TestMethod]
		public void WrapAbstractClass()
		{
		}

		[TestMethod]
		public void WrapBaseClassWithNewMethod()
		{
		}

		[TestMethod]
		public void WrapAsT_ShouldUseT()
		{
			// T is not object, use T to wrap
		}

		[TestMethod]
		public void WrapVisibleAsObject_ShouldUseValueType()
		{
			// use value.GetType() wrap
		}

		[TestMethod]
		public void WrapInvisibleAsObject_ShouldUseObject()
		{
			// use object wrap
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
