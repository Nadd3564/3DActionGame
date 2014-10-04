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
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcTimeTest ()
		{
			Assert.That (eController.CalcTime(), Is.EqualTo (0.0f));
		}
		
		[Test]
		[Category ("Calc Test")]
		public void IsEnemyHitTest([Values("EnemyHit")]string s) 
		{
			Assert.True (eController.IsEnemyHit(s));		
		}

		[Test]
		[Category ("Calc Test")]
		public void IsNotEnemyHitTest([Values("false", "", null)]string s) 
		{
			Assert.False (eController.IsEnemyHit(s));		
		}

		[Test]
		[Category ("Calc Test")]
		public void LessThanHPTest([Values(-10, 0, null)]int i) 
		{
			Assert.True (eController.LessThanHP(i));		
		}

		[Test]
		[Category ("Calc Test")]
		public void IsNotLessThanHPTest([Values(1, 10, 100)]int i) 
		{
			Assert.False (eController.LessThanHP(i));		
		}

		
		private IEnemyController GetEnemyMock () {
			return Substitute.For<IEnemyController> ();
		}
		
		private EnemyCtrlController GetControllerMock(IEnemyController iEnemy) {
			var eController = Substitute.For<EnemyCtrlController> ();
			eController.SetEnemyController (iEnemy);
			eController.CalcTime ().Returns (0.0f);
			return eController;
		}
		
	}
}

