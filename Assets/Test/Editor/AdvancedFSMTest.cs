using NUnit.Framework;
using System;
using NSubstitute;
using Cradle.FM;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("AdvancedFSM Test")]
	public class AdvancedFSMTest
	{
		public IAdvancedController iAdv;
		public AdvancedFSMController advController;
		
		[SetUp] public void Init()
		{ 
			iAdv = GetAdvancedMock ();
			advController = GetControllerMock (iAdv);
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//正常値テスト
		[Test]
		[Category ("Boolian Test")]
		public void IsFSMStateCountTest ([Values(0,null)]int i)
		{
			Assert.True(advController.FSMStateCount(i));
		}

		[Test]
		[Category ("Boolian Test")]
		public void IsNotFSMStateCountTest ([Values(-100,-1,1,100)]int i)
		{
			Assert.False(advController.FSMStateCount(i));
		}

		[Test]
		[Category ("Boolian Test")]
		public void IsAsTrans ([Values(Transition.None, null)]Transition t)
		{
			Assert.True(advController.AsTrans(t));
		}
		
		[Test]
		[Category ("Boolian Test")]
		public void IsNotAsTrans ([Values(Transition.LostPlayer,
		                                  Transition.NoHealth, Transition.ReachPlayer,
		                                  Transition.SawPlayer)]Transition t)
		{
			Assert.False(advController.AsTrans(t));
		}


		[Test]
		[Category ("Boolian Test")]
		public void AsFSMStateID ([Values(FSMStateID.None, null)]FSMStateID f, [Values(FSMStateID.None, null)]FSMStateID s)
		{
			Assert.True(advController.AsFSMStateID(f, s));
		}
		
		[Test]
		[Category ("Boolian Test")]
		public void NotAsFSMStateID ([Values(FSMStateID.Approaching, FSMStateID.Searching)]FSMStateID f, 
		                             [Values(FSMStateID.Attacking, FSMStateID.Dead,FSMStateID.None)]FSMStateID s)
		{
			Assert.False(advController.AsFSMStateID(f, s));
		}


		[Test]
		[Category ("Boolian Test")]
		public void SetCurrentStateID ([Values(FSMStateID.None, null)]FSMStateID f, [Values(FSMStateID.None, null)]FSMStateID s)
		{
			advController.SetCurrentStateID (f, s);
			Assert.That(s, Is.EqualTo(f));
		}
		
		[Test]
		[Category ("Boolian Test")]
		public void NotSetCurrentStateID([Values(FSMStateID.Approaching, FSMStateID.Searching)]FSMStateID f, 
		                             [Values(FSMStateID.Attacking, FSMStateID.Dead,FSMStateID.None)]FSMStateID s)
		{
			advController.SetCurrentStateID (f, s);
			Assert.That(s, Is.Not.EqualTo(f));
		}

		
		private IAdvancedController GetAdvancedMock () {
			return Substitute.For<IAdvancedController> ();
		}
		
		private AdvancedFSMController GetControllerMock(IAdvancedController iAdv) {
			var advController = Substitute.For<AdvancedFSMController> ();
			advController.SetAdvancedController (iAdv);
			return advController;
		}
		
	}
}

