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
		private SceneManagerController manager;

		[SetUp] public void Init()
		{
			titleState = Substitute.For<TitleState>();
			titleState.StartButton ().Returns (true);
		}
		
		[TearDown] public void Cleanup()
		{
			
		}


		//NULL値テスト（オブジェクト）
		[Test]
		[Category ("manager Test")]
		public void managerTest () 
		{
			Assert.Null (titleState.GetManager());
		}
		
		//正常値テスト（メソッド）
		[Test]
		[Category ("GetKeyUpRet Test")]
		public void GetKeyUpRetTest () 
		{
			//Arrange
			titleState.GetKeyUpRet ().Returns (true);

			//Assert
			Assert.True (titleState.GetKeyUpRet ());
		}

		[Test]
		[Category ("StartButton Test")]
		public void StartButtonTest () 
		{
			Assert.True (titleState.StartButton ());
		}
		
	}
}

