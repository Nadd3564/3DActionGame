using NUnit.Framework;
using System;
using System.Collections.Generic;
using NSubstitute;
using Cradle.FM;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("FSMState Test")]
	public class FSMStateTest
	{
		private FSMState fsmState;
		private Dictionary<Transition, FSMStateID> map;

		
		[SetUp] public void Init()
		{
			fsmState = Substitute.For<FSMState> ();
			map = new Dictionary<Transition, FSMStateID> ();
		}
		
		[TearDown] public void Cleanup()
		{

		}
		
		
		//正常値テスト（メソッド）
		[Test]
		[Category ("SetDist Test")]
		public void SetDistTest () 
		{
			float f = 10.0f;
			fsmState.SetDist (10.0f);
			Assert.That (fsmState.GetDist(), Is.EqualTo(f));		
		}


		[Test]
		[Category ("AddTransition Test")]
		public void AddTransitionTest () 
		{
			map.Add (Transition.LostPlayer, FSMStateID.Approaching);
			Assert.That (fsmState.AddTransition (Transition.LostPlayer, FSMStateID.Approaching), Is.EqualTo(map));
		}
		
	}
}

