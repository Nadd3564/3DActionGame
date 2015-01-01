using NUnit.Framework;
using Cradle.DesignPattern;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("PlayState Test")]
	public class PlayStateTest
	{
		private PlayState playState;
		private SceneManagerController manager;
		
		[SetUp] public void Init()
		{
			playState = Substitute.For<PlayState>();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//NULL値テスト（オブジェクト）
		[Test]
		[Category ("manager Test")]
		public void managerTest () 
		{
			Assert.Null (playState.GetManager());
		}
		

	}
}

