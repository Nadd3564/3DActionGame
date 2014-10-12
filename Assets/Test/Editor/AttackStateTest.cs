using NUnit.Framework;
using System;
using NSubstitute;
using Cradle.FM;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("AttackState Test")]
	public class AttackStateTest
	{

		public AttackState aState;
		
		[SetUp] public void Init()
		{ 
			aState = Substitute.For<AttackState>();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//データ型テスト（オブジェクト）
		[Test]
		[Category ("AttackRate Type Test")]
		public void AttackRateTest() 
		{
			Assert.False (aState.EmptyTrans (Transition.LostPlayer));
		}

		
		private FSMController GetControllerMock(IFSMController iFsm) {
			var fController = Substitute.For<FSMController> ();
			fController.SetFSMController (iFsm);
			return fController;
		}
		
	}
}

