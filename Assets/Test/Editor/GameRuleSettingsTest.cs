using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("GameRuleSettings Test")]
	public class GameRuleSettingsTest
	{
		public IRuleController iRule;
		public GameRuleSettingsController gRSController;
		
		[SetUp] public void Init()
		{ 
			iRule = GetRuleMock ();
			gRSController = GetControllerMock (iRule);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//正常値テスト	
		[Test]
		[Category ("Calc Test")]
		[TestCase(1)]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		[TestCase("string")]
		public void GameFlgsTest(bool flg) 
		{
			gRSController.SetGameClear (true);
			gRSController.SetGameOver (false);
			Assert.That (gRSController.GameFlgs(), Is.EqualTo(flg));		
		}

		[Test]
		[Category ("Calc Test")]
		[TestCase(1)]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		[TestCase("string")]
		public void TimeRemainingTest(bool flg) 
		{
			gRSController.SetCountSceneChangeTime (10.0f);
			Assert.That (gRSController.TimeRemaining(), Is.EqualTo(flg));		
		}
		

		private IRuleController GetRuleMock () {
			return Substitute.For<IRuleController> ();
		}
		
		private GameRuleSettingsController GetControllerMock(IRuleController iRule) {
			var gRSController = Substitute.For<GameRuleSettingsController> ();
			gRSController.SetRuleController (iRule);
			return gRSController;
		}
		
	}
}

