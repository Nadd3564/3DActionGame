using NUnit.Framework;
using System;
using NSubstitute;
using Cradle.FM;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("FSM Test")]
	public class FSMTest
	{
		public IFSMController iFsm;
		public FSMController fController;
		
		[SetUp] public void Init()
		{ 
			iFsm = GetFsmMock ();
			fController = GetControllerMock (iFsm);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//データ型テスト（オブジェクト）
		[Test]
		[Category ("AttackRate Type Test")]
		public void AttackRateTest() 
		{
			Assert.That (fController.GetAttackRate(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("ElapsedTime Type Test")]
		public void ElapsedTimeTest() 
		{
			Assert.That (fController.GetElapsedTime(), Is.TypeOf(typeof(float)));		
		}

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("AttackRate NotNull Test")]
		public void NotNullAttackRateTest() 
		{
			Assert.NotNull (fController.GetAttackRate());		
		}
		
		[Test]
		[Category ("ElapsedTime NotNull Test")]
		public void NotNullElapsedTimeTest() 
		{
			Assert.NotNull (fController.GetElapsedTime());		
		}

		//正常値テスト（オブジェクト）
		[Test]
		[Category ("AttackRate Test")]
		public void GetAttackRateTest() 
		{
			Assert.That (fController.GetAttackRate(), Is.EqualTo(0.0f));		
		}

		[Test]
		[Category ("ElapsedTime Test")]
		public void GetElapsedTimeTest() 
		{
			Assert.That (fController.GetElapsedTime(), Is.EqualTo(0.0f));		
		}

		//異常値テスト（オブジェクト）
		[Test]
		[Category ("AttackRate Test")]
		public void GetAttackRateOutlinerTest([Values(-1.0f, 1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (fController.GetAttackRate(), Is.Not.EqualTo(f));		
		}

		[Test]
		[Category ("ElapsedTime Test")]
		public void GetElapsedTimeOutlinerTest([Values(-1.0f, 1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (fController.GetElapsedTime(), Is.Not.EqualTo(f));		
		}

		//正常値テスト（メソッド）
		[Test]
		[Category ("SetAttackRate Test")]
		public void SetAttackRateTest() 
		{
			float l = fController.SetAttackRate (10.0f);
			Assert.That (fController.GetAttackRate(), Is.EqualTo(l));		
		}

		[Test]
		[Category ("SetAttackRate Range Test")]
		public void SetAttackRateRangeTest([Range(-4.0f,4.0f,1.0f)]float f) 
		{
			float l = fController.SetAttackRate (f);
			Assert.That (fController.GetAttackRate(), Is.EqualTo(l));		
		}

		[Test]
		[Category ("SetElapsedTime Test")]
		public void SetElapsedTimeTest() 
		{
			float l = fController.SetElapsedTime (10.0f);
			Assert.That (fController.GetElapsedTime(), Is.EqualTo(l));		
		}
		
		[Test]
		[Category ("SetElapsedTime Range Test")]
		public void SetElapsedTimeRangeTest([Range(-4.0f,4.0f,1.0f)]float f) 
		{
			float l = fController.SetElapsedTime (f);
			Assert.That (fController.GetElapsedTime(), Is.EqualTo(l));		
		}

		[Test]
		[Category ("SetUpElapsedTime Test")]
		public void SetUpElapsedTimeTest() 
		{
			float l = fController.SetElapsedTime (10.0f);
			l = fController.SetUpElapsedTime (10.0f);
			Assert.That (fController.GetElapsedTime(), Is.EqualTo(20.0f));		
		}
		
		[Test]
		[Category ("SetUpElapsedTime Range Test")]
		public void SetUpElapsedTimeRangeTest([Range(-4.0f,4.0f,1.0f)]float f) 
		{
			float l = fController.SetElapsedTime (f);
			l = fController.SetElapsedTime (10.0f);
			Assert.That (fController.GetElapsedTime(), Is.EqualTo(l));		
		}

		[Test]
		[Category ("AttackCount Test")]
		public void AttackCountTest() 
		{
			fController.SetElapsedTime (4.0f);
			fController.SetAttackRate (4.0f);
			Assert.True(fController.AttackCount());		
		}

		[Test]
		[Category ("AttackCount false Test")]
		public void AttackCountFalseTest() 
		{
			fController.SetElapsedTime (3.0f);
			fController.SetAttackRate (4.0f);
			Assert.False(fController.AttackCount());		
		}

		//例外処理テスト
		[Test]
		[Category ("AttackCount Exception Test")]
		[ExpectedException(typeof(TimeoutException))]
		public void AttackCountExceptionTest() 
		{
			fController.SetElapsedTime (30.0f);
			fController.AttackCount ();
		}


		private IFSMController GetFsmMock () {
			return Substitute.For<IFSMController> ();
		}
		
		private FSMController GetControllerMock(IFSMController iFsm) {
			var fController = Substitute.For<FSMController> ();
			fController.SetFSMController (iFsm);
			return fController;
		}
		
	}
}

