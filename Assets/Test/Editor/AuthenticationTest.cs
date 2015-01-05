using NUnit.Framework;
using Cradle.DesignPattern;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("Authentication Test")]
	public class AuthenticationTest
	{
		private Authentication aut;
		
		[SetUp] public void Init()
		{
			aut = Substitute.For<Authentication>();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		

		//正常値テスト（オブジェクト）
		[Test]
		[Category ("id Test")]
		public void IdTest () 
		{
			Assert.Null (aut.GetId());
		}

		[Test]
		[Category ("password Test")]
		public void PasswordTest () 
		{
			Assert.Null (aut.GetPass());
		}

		[Test]
		[Category ("ProxyFlg Test")]
		public void ProxyFlgTest () 
		{
			Assert.False (aut.IsProxyFlg());
		}



		//正常値テスト（メソッド）
		[Test]
		[Category ("SetId Test")]
		public void SetIdTest () 
		{
			string s = "user";
			aut.SetId ("user");
			StringAssert.Contains (s, aut.GetId());
		}

		[Test]
		[Category ("SetPass Test")]
		public void SetPassTest () 
		{
			string s = "0123";
			aut.SetPass ("0123");
			StringAssert.Contains (s, aut.GetPass());
		}

		[Test]
		[Category ("SetProxyFlg Test")]
		public void SetProxyFlgTest () 
		{
			aut.SetProxyFlg ();
			Assert.True (aut.IsProxyFlg());
		}


	}
}