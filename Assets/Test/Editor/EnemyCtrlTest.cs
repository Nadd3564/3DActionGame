using NUnit.Framework;
using System;
using NSubstitute;
using Cradle.FM;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("EnemyCtrl Test")]
	public class EnemyCtrlTest
	{
		public IEnemyController iEnemy;
		public EnemyCtrlController eController;
		
		[SetUp] public void Init()
		{ 
			iEnemy = GetEnemyMock ();
			eController = GetControllerMock (iEnemy);
		}
		
		[TearDown] public void Cleanup()
		{
			
		}


		//データ型テスト(オブジェクト)
		[Test]
		[Category ("WaitTime Test")]
		public void WaitTimeTest() 
		{
			Assert.That (eController.GetWaitTime(), Is.TypeOf(typeof(float)));
		}

		[Test]
		[Category ("WaitBaseTime Test")]
		public void WaitBaseTimeTest() 
		{
			Assert.That (eController.GetWaitBaseTime(), Is.TypeOf(typeof(float)));
		}

		[Test]
		[Category ("WalkRange Test")]
		public void WalkRangeTest() 
		{
			Assert.That (eController.GetWalkRange(), Is.TypeOf(typeof(float)));
		}

		[Test]
		[Category ("DestroyTime Test")]
		public void DestroyTimeTest() 
		{
			Assert.That (eController.GetDestroyTime(), Is.TypeOf(typeof(float)));
		}

		[Test]
		[Category ("DestinationPosition Test")]
		public void DestinationPositionTest() 
		{

			Assert.That (eController.getDestination(), Is.TypeOf(typeof(string)));	
		}

		//Null値テスト(オブジェクト)
		[Test]
		[Category ("WaitTime NotNull Test")]
		public void NotNullWaitTimeTest() 
		{
			Assert.NotNull (eController.GetWaitTime());		
		}

		[Test]
		[Category ("WaitBaseTime NotNull Test")]
		public void NotNullWaitBaseTimeTest() 
		{
			Assert.NotNull (eController.GetWaitBaseTime());		
		}

		[Test]
		[Category ("WaitRange NotNull Test")]
		public void NotNullWalkRangeTest() 
		{
			Assert.NotNull (eController.GetWalkRange());		
		}

		[Test]
		[Category ("DestroyTime NotNull Test")]
		public void NotNullDestroyTimeTest() 
		{
			Assert.NotNull (eController.GetDestroyTime());		
		}

		[Test]
		[Category ("DestinationPosition NotNull Test")]
		public void NotNullDestinationPositionTest() 
		{
			Assert.NotNull (eController.getDestination());		
		}

		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("DestinationPosition NotEmpty Test")]
		public void IsNotEmptyDestinationPositionTest() 
		{
			Assert.IsNotEmpty (eController.getDestination());		
		}

		//正常値テスト(オブジェクト)
		[Test]
		[Category ("GetWaitTime Test")]
		public void GetWaitTimeTest() 
		{
			Assert.That (eController.GetWaitTime(), Is.EqualTo(0.0f));		
		}

		[Test]
		[Category ("GetWaitBaseTime Test")]
		public void GetWaitBaseTimeTest() 
		{
			Assert.That (eController.GetWaitBaseTime(), Is.EqualTo(2.0f));		
		}

		[Test]
		[Category ("GetWalkRange Test")]
		public void GetWalkRangeTest() 
		{
			Assert.That (eController.GetWalkRange(), Is.EqualTo(5.0f));		
		}

		[Test]
		[Category ("GetDestroyTime Test")]
		public void GetDestroyTimeTest() 
		{
			Assert.That (eController.GetDestroyTime(), Is.EqualTo(5.0f));		
		}

		[Test]
		[Category ("GetDestination Test")]
		public void GetDestinationTest() 
		{
			Assert.That (eController.getDestination(), Is.EqualTo("(0.0, 0.0, 0.0)"));		
		}


		//異常値テスト（オブジェクト）
		[Test]
		[Category ("GetWaitTimeOutLiner Test")]
		public void GetWaitTimeOutLinerTest([Values(-1.0f, 1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (eController.GetWaitTime(), Is.Not.EqualTo(f));		
		}

		[Test]
		[Category ("GetWaitBaseTimeOutLiner Test")]
		public void GetWaitBaseTimeOutLinerTest([Values(-1.0f, 1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (eController.GetWaitBaseTime(), Is.Not.EqualTo(f));		
		}

		[Test]
		[Category ("GetWalkRangeOutLiner Test")]
		public void GetWalkRangeOutLinerTest([Values(-1.0f, 1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (eController.GetWalkRange(), Is.Not.EqualTo(f));		
		}

		[Test]
		[Category ("GetDestroyTimeOutLiner Test")]
		public void GetDestroyTimeOutLinerTest([Values(-1.0f, 1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (eController.GetDestroyTime(), Is.Not.EqualTo(f));		
		}

		[Test]
		[Category ("GetDestinationOutLiner Test")]
		public void GetDestinationOutLinerTest(
			[Values("(-1.0f, -1.0f, -1.0f)", "(1.0f, 1.0f, 1.0f)", "(100.0f, 100.0f, 100.0f)")]string s) 
		{
			Assert.That (eController.getDestination(), Is.Not.EqualTo(s));		
		}

		//正常値テスト(メソッド)
		[Test]
		[Category ("SetWaitTime Test")]
		public void SetWaitTimeTest() 
		{
			float f = eController.SetWaitTime (2.0f);
			Assert.That (eController.GetWaitTime(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetDownWaitTime Test")]
		public void SetDownWaitTimeTest() 
		{
			float f = eController.SetDownWaitTime (2.0f);
			Assert.That (eController.GetWaitTime(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("IsEnemyHit Test")]
		public void IsEnemyHitTest([Values("EnemyHit")]string s) 
		{
			Assert.True (eController.IsEnemyHit(s));		
		}

		[Test]
		[Category ("IsTagCheck Test")]
		public void IsTagCheckTest([Values("EnemyHit")]string s, [Values("EnemyHit")]string t) 
		{
			Assert.True (eController.IsTagCheck(s, t));		
		}

		[Test]
		[Category ("LessThanHP Test")]
		public void LessThanHPTest([Values(0)]int i) 
		{
			Assert.True (eController.LessThanHP(0));		
		}

		[Test]
		[Category ("ThanItemPrefab Test")]
		public void ThanItemPrefabTest([Values(0, null)]int i) 
		{
			Assert.True (eController.ThanItemPrefab(i));		
		}

		[Test]
		[Category ("ThanTime Test")]
		public void ThanTimeTest([Values(1.0f)]float f) 
		{
			eController.SetWaitTime (f);
			Assert.True (eController.ThanTime());		
		}

		[Test]
		[Category ("LessThanTime Test")]
		public void LessThanTimeTest([Values(0.0f)]float f) 
		{
			eController.SetWaitTime (f);
			Assert.True (eController.LessThanTime());		
		}

		[Test]
		[Category ("attackStart Test")]
		public void attackStartTest() 
		{
			//Arrange
			iEnemy.attackCount ().Returns (true);
			iEnemy.setAttacking ().Returns (true);

			//Assert
			Assert.True (eController.attackStart());
		}

		//異常値テスト(メソッド)
		[Test]
		[Category ("NotSetWaitTime Test")]
		public void NotSetWaitTimeTest() 
		{
			float f = eController.SetWaitTime (2.0f);
			float l = 3.0f;
			Assert.That (eController.GetWaitTime(), Is.Not.EqualTo(l));		
		}
		
		[Test]
		[Category ("NorSetDownWaitTime Test")]
		public void NotSetDownWaitTimeTest() 
		{
			float f = eController.SetDownWaitTime (2.0f);
			float l = 3.0f;
			Assert.That (eController.GetWaitTime(), Is.Not.EqualTo(l));		
		}

		[Test]
		[Category ("IsNotEnemyHit Test")]
		public void IsNotEnemyHitTest([Values("false", "", null)]string s) 
		{
			Assert.False (eController.IsEnemyHit(s));		
		}

		[Test]
		[Category ("IsNotTagCheck Test")]
		public void IsNotTagCheckTest([Values("")]string s, [Values("EnemyHit")]string t) 
		{
			Assert.False (eController.IsTagCheck(s, t));		
		}

		[Test]
		[Category ("IsNotLessThanHP Test")]
		public void IsNotLessThanHPTest([Values(1, 10, 100)]int i) 
		{
			Assert.False (eController.LessThanHP(i));		
		}

		[Test]
		[Category ("IsNotThanItemPrefab Test")]
		public void IsNotThanItemPrefabTest([Values(-1, 1, 10)]int i) 
		{
			Assert.False (eController.ThanItemPrefab(i));		
		}
		
		[Test]
		[Category ("IsNotThanTime Test")]
		public void IsNotThanTimeTest([Values(0.0f, -1.0f, -10.0f)]float f) 
		{
			eController.SetWaitTime (f);
			Assert.False (eController.ThanTime());		
		}

		[Test]
		[Category ("IsNotLessThanTime Test")]
		public void IsNotLessThanTimeTest([Values(0.1f, 1.0f, 10.0f)]float f) 
		{
			eController.SetWaitTime (f);
			Assert.False (eController.LessThanTime());		
		}

		[Test]
		[Category ("Died Test")]
		public void DiedTest() 
		{
			string s = "Dead";
			eController.Died ();
			
			Assert.That (iEnemy.SetTag(), Is.EqualTo(s));		
		}

		//例外処理テスト
		[Test]
		[Category ("attackStart Exception Test")]
		[ExpectedException(typeof(ArgumentException))]
		public void attackStartExceptionTest() 
		{
			//Arrange
			iEnemy.attackCount ().Returns (true);
			iEnemy.setAttacking ().Returns (false);
		
			eController.attackStart ();
		}

		private IEnemyController GetEnemyMock () {
			return Substitute.For<IEnemyController> ();
		}
		
		private EnemyCtrlController GetControllerMock(IEnemyController iEnemy) {
			var eController = Substitute.For<EnemyCtrlController> ();
			eController.SetEnemyController (iEnemy);
			iEnemy.SetTag ().Returns ("Dead");
			return eController;
		}
		
	}
}

