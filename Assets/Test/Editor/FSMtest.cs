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
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void GetAttackRateTest() 
		{
			Assert.That (fController.GetAttackRate(), Is.EqualTo(0.0f));		
		}

		[Test]
		[Category ("Calc Test")]
		public void GetAttackRateIsNotTest([Values(1.0f, 10.0f, 100.0f, 1000.0f)]float f) 
		{
			Assert.That (fController.GetAttackRate(), Is.Not.EqualTo(f));		
		}

		[Test]
		[Category ("Calc Test")]
		public void GetAttackRateNullTest() 
		{
			Assert.IsNotNull (fController.GetAttackRate());		
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

