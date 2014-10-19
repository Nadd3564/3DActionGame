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


		//データ型テスト（オブジェクト）
		[Test]
		[Category ("attackPower Type Test")]
		public void attackPowerTypeTest() 
		{
			Assert.That (aIController.getAttackPower(), Is.TypeOf(typeof(int)));		
		}

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("attackPower NotNull Test")]
		public void NotNullattackPowerTest() 
		{
			Assert.NotNull (aIController.getAttackPower());		
		}

		//正常値テスト(オブジェクト)
		[Test]
		[Category ("getAttackPower Test")]
		public void GetAttackPowerTest () 
		{
			int i = 0;
			Assert.That (aIController.getAttackPower (), Is.EqualTo(i));		
		}

		//異常値テスト(オブジェクト)
		[Test]
		[Category ("NotGetAttackPower Test")]
		public void NotGetAttackPowerTest ([Range(-10, -1, 1)]int i) 
		{
			Assert.That (aIController.getAttackPower (), Is.Not.EqualTo(i));		
		}


		//正常値テスト（メソッド）
		[Test]
		[Category ("SetAttackPower Test")]
		public void SetAttackPowerTest () 
		{
			int x = aIController.setAttackPower(10);
			Assert.That (aIController.getAttackPower(), Is.EqualTo(x));		
		}

		[Test]
		[Category ("SetAttackPower Range Test")]
		public void SetAttackPowerRangeTest ([Range(-4, 4, 1)]int x) 
		{
			aIController.setAttackPower(x);
			Assert.That (aIController.getAttackPower(), Is.EqualTo(x));		
		}


		[Test]
		[Category ("SetAttackBoostPower Test")]
		public void SetAttackBoostPowerTest () 
		{
			int x = aIController.setAttackPower (10);
			aIController.setAttackBoostPower(10);
			Assert.That (aIController.getAttackPower(), Is.EqualTo(20));		
		}

		[Test]
		[Category ("SetAttackBoostPower Range Test")]
		public void SetAttackBoostPowerRangeTest ([Range(-4, 4, 1)]int x) 
		{
			int i = aIController.setAttackPower (10);
			i += aIController.setAttackBoostPower(x);
			Assert.That (aIController.getAttackPower(), Is.EqualTo(10 + x));		
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

