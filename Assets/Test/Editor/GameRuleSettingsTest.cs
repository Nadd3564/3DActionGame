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


		//データ型テスト（オブジェクト）
		[Test]
		[Category ("gameSpeed Type Test")]
		public void gameSpeedTypeTest() 
		{
			Assert.That (gRSController.GetGameSpeed(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("timeRemaining Type Test")]
		public void timeRemainingTypeTest() 
		{
			Assert.That (gRSController.GetTimeRemaining(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("sceneChangeTime Type Test")]
		public void sceneChangeTimeTypeTest() 
		{
			Assert.That (gRSController.GetSceneChangeTime(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("gameOver Type Test")]
		public void gameOverTypeTest() 
		{
			Assert.That (gRSController.IsGameOver(), Is.TypeOf(typeof(bool)));		
		}

		[Test]
		[Category ("gameClear Type Test")]
		public void gameClearTypeTest() 
		{
			Assert.That (gRSController.IsGameClear(), Is.TypeOf(typeof(bool)));		
		}


		//Null値テスト（オブジェクト）
		[Test]
		[Category ("gameSpeed NotNull Test")]
		public void NotNullGameSpeedTest() 
		{
			Assert.NotNull (gRSController.GetGameSpeed());		
		}

		[Test]
		[Category ("timeRemaining NotNull Test")]
		public void NotNulltimeRemainingTest() 
		{
			Assert.NotNull (gRSController.GetTimeRemaining());		
		}

		[Test]
		[Category ("sceneChangeTime NotNull Test")]
		public void NotNullsceneChangeTimeTest() 
		{
			Assert.NotNull (gRSController.GetSceneChangeTime());		
		}

		[Test]
		[Category ("gameOver NotNull Test")]
		public void NotNullgameOverTest() 
		{
			Assert.NotNull (gRSController.IsGameClear());		
		}

		[Test]
		[Category ("gameClear NotNull Test")]
		public void NotNullgameClearTest() 
		{
			Assert.NotNull (gRSController.GetGameSpeed());		
		}


		//正常値テスト（オブジェクト）
		[Test]
		[Category ("gameSpeed Test")]
		public void gameSpeedTest() 
		{
			float f = 1.0f;
			Assert.That (gRSController.GetGameSpeed(), Is.EqualTo(f));		
		}


		[Test]
		[Category ("timeRemaining Test")]
		public void timeRemainingTest() 
		{
			float f = 65.0f;
			Assert.That (gRSController.GetTimeRemaining(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("sceneChangeTime Test")]
		public void sceneChangeTimeTest() 
		{
			float f = 10.0f;
			Assert.That (gRSController.GetSceneChangeTime(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("gameOver Test")]
		public void gameOverTest() 
		{
			Assert.False (gRSController.IsGameOver());		
		}

		[Test]
		[Category ("gameClear Test")]
		public void gameClearTest() 
		{
			Assert.False (gRSController.IsGameClear());		
		}

		//正常値テスト(メソッド)
		[Test]
		[Category ("SetCountSceneChangeTime Test")]
		public void SetCountSceneChangeTimeTest() 
		{
			float f = 0.0f;
			gRSController.SetCountSceneChangeTime (10.0f);
			Assert.That (gRSController.GetSceneChangeTime(), Is.EqualTo(f));		
		}
		
		[Test]
		[Category ("SetGameOver Test")]
		public void SetGameOverTest() 
		{
			gRSController.SetGameOver (false);
			Assert.False (gRSController.IsGameOver ());	
		}

		[Test]
		[Category ("SetGameClear Test")]
		public void SetGameClearTest() 
		{
			gRSController.SetGameClear (false);
			Assert.False (gRSController.IsGameClear());		
		}

		[Test]
		[Category ("GameFlgs Test")]
		public void GameFlgsTest() 
		{
			//Arrange
			gRSController.IsGameClear ().Returns (true);

			//Assert
			Assert.True (gRSController.GameFlgs());		
		}

		[Test]
		[Category ("TimeRemaining Test")]
		public void TimeRemainingTest() 
		{
			gRSController.SetCountSceneChangeTime (10.0f);
			Assert.True (gRSController.TimeRemaining());		
		}

		[Test]
		[Category ("ReturnTitle Test")]
		public void ReturnTitleTest() 
		{
			//Arrange
			gRSController.IsGameOver ().Returns (true);

			//Act
			gRSController.GameFlgs ();

			//Assert
			Assert.True (gRSController.ReturnTitle());		
		}


		private IRuleController GetRuleMock () {
			return Substitute.For<IRuleController> ();
		}
		
		private GameRuleSettingsController GetControllerMock(IRuleController iRule) {
			var gRSController = Substitute.For<GameRuleSettingsController> ();
			gRSController.SetRuleController (iRule);
			gRSController.IsGameOver ().Returns (false);
			gRSController.IsGameClear ().Returns (false);
			return gRSController;
		}
		
	}
}

