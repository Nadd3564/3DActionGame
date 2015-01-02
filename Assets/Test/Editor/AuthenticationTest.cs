using NUnit.Framework;
using Cradle.DesignPattern;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("AuthenticationTest Test")]
	public class AuthenticationTest
	{
		private Authentication aut;
		private SceneManagerController manager;
		
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
		public void idTest () 
		{
			Assert.Null (aut.GetId());
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

	}
}