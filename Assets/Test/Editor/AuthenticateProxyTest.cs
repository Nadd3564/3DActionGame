using NUnit.Framework;
using System;
using System.Collections.Generic;
using NSubstitute;
using Cradle.DesignPattern;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("AuthenticateProxy Test")]
	public class AuthenticateProxyTest
	{
		private MatterAccessor.AuthenticateProxy matter;

		
		[SetUp] public void Init()
		{
			matter = Substitute.For<MatterAccessor.AuthenticateProxy> ();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//データ型テスト（オブジェクト）
		[Test]
		[Category ("id Type Test")]
		public void idTypeTest() 
		{
			matter.Authenticate ("a", "b");
			Assert.That (matter.GetId(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("password Type Test")]
		public void passwordTypeTest() 
		{
			matter.Authenticate ("b", "a");
			Assert.That (matter.GetPass(), Is.TypeOf(typeof(string)));		
		}


		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("id IsEmpty Test")]
		public void IsEmptyidTest() 
		{
			matter.Authenticate ("", "");
			Assert.IsEmpty (matter.GetId());		
		}

		[Test]
		[Category ("password IsEmpty Test")]
		public void IsEmptyPasswordTest() 
		{
			matter.Authenticate ("", "");
			Assert.IsEmpty (matter.GetPass());		
		}


		//正常値テスト（オブジェクト）
		[Test]
		[Category ("id Test")]
		public void IdTest() 
		{
			Assert.Null (matter.GetId());
		}

		[Test]
		[Category ("password Test")]
		public void PasswordTest() 
		{
			Assert.Null (matter.GetPass());
		}

	
		//正常値テスト（メソッド）
		[Test]
		[Category ("AuthenticateWithId Test")]
		public void AuthenticateWithIdTest () 
		{
			string s = "id";
			matter.Authenticate ("id", "pass");

			StringAssert.Contains (s, matter.GetId());		
		}

		[Test]
		[Category ("AuthenticateWithPass Test")]
		public void AuthenticateWithPassTest () 
		{
			string s = "pass";
			matter.Authenticate ("id", "pass");

			StringAssert.Contains (s, matter.GetPass());		
		}

		[Test]
		[Category ("RequestPassing Test")]
		public void RequestPassingTest () 
		{
			string s = "AuthenticateProxy: matter Request Application start";
			matter.Authenticate ("id", "pass");

			StringAssert.Contains (s, matter.Request());		
		}

		[Test]
		[Category ("RequestFailing Test")]
		public void RequestFailingTest () 
		{
			string s = "AuthenticateProxy: The Method Must Authentication";
			StringAssert.Contains (s, matter.Request());		
		}

		//例外検出テスト
		[Test]
		[Category ("AddTransition Exception Test")]
		[ExpectedException(typeof(ConditionException))]
		public void AddTransitionExceptionTest() 
		{
			//fsmState.AddTransition(Transition.None, FSMStateID.None);
		}
	}
}