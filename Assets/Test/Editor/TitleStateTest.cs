using NUnit.Framework;
using Cradle.DesignPattern;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("TitleState Test")]
	public class TitleStateTest
	{
		private TitleState titleState;

		[SetUp] public void Init()
		{
			titleState = Substitute.For<TitleState>();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//正常値テスト（メソッド）
		[Test]
		[Category ("GetKeyUpRet Test")]
		public void GetKeyUpRetTest () 
		{
			titleState.GetKeyUpRet ().Returns (true);
			Assert.True (titleState.GetKeyUpRet ());
		}

		[Test]
		[Category ("StartButton Test")]
		public void StartButtonTest () 
		{
			titleState.StartButton ().Returns (true);
			Assert.True (titleState.StartButton ());
		}
		
	}
}

