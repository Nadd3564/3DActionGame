using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("AttackInfo Test")]
	public class AttackInfoTest
	{
		public IInfoController iInfo;
		public AttackInfoController aIController;
		
		[SetUp] public void Init()
		{ 
			iInfo = GetInfoMock ();
			aIController = GetControllerMock (iInfo);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcGetAttackPowerTest ([Values(-1,0,1,null)]int x) 
		{
			aIController.getAttackPower ();
			Assert.That (aIController.attackPower, Is.EqualTo(x));		
		}

		[Test]
		[Category ("Calc Test")]
		[TestCase(-1)]
		[TestCase(1)]
		[TestCase(3)]
		[TestCase(null)]
		public void CalcSetAttackPowerTest ([Range(0,50,10)]int x) 
		{
			aIController.setAttackPower(1);
			Assert.That (aIController.attackPower, Is.EqualTo(x));		
		}

		[Test]
		[Category ("Calc Test")]
		[TestCase(-1)]
		[TestCase(null)]
		public void CalcSetAttackBoostPowerTest ([Range(0,10,1)]int x) 
		{
			aIController.setAttackPower (1);
			aIController.setAttackBoostPower(1);
			Assert.That (aIController.attackPower, Is.EqualTo(x));		
		}

		private IInfoController GetInfoMock () {
			return Substitute.For<IInfoController> ();
		}
		
		private AttackInfoController GetControllerMock(IInfoController iInfo) {
			var aIController = Substitute.For<AttackInfoController> ();
			aIController.SetInfoController (iInfo);
			return aIController;
		}
		
	}
}

