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
		private IFSMStateController iFsm;
		private Dictionary<Transition, FSMStateID> map;

		
		[SetUp] public void Init()
		{
			fsmState = Substitute.For<FSMState> ();
			map = new Dictionary<Transition, FSMStateID> ();
		}
		
		[TearDown] public void Cleanup()
		{

		}
		

		//データ型テスト（オブジェクト）
		[Test]
		[Category ("map Type Test")]
		public void mapTypeTest() 
		{
			Assert.That (fsmState.GetTFDictionary(), Is.TypeOf(typeof(Dictionary<Transition, FSMStateID>)));		
		}

		[Test]
		[Category ("ID Type Test")]
		public void IDTypeTest() 
		{
			Assert.That (fsmState.GetStateID(), Is.TypeOf(typeof(FSMStateID)));		
		}


		[Test]
		[Category ("RotSpeed Type Test")]
		public void RotSpeedTypeTest() 
		{
			Assert.That (fsmState.GetRotSpeed(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("dist Type Test")]
		public void distTypeTest() 
		{
			Assert.That (fsmState.GetDist(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("destPos Type Test")]
		public void destPosTypeTest() 
		{
			Assert.That (fsmState.getDestPos(), Is.TypeOf(typeof(string)));		
		}


		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("map IsEmpty Test")]
		public void IsEmptyMapTest() 
		{
			Assert.IsEmpty (fsmState.GetTFDictionary());		
		}

		[Test]
		[Category ("destPos NotEmpty Test")]
		public void IsNotEmptyDestPosTest() 
		{
			Assert.IsNotEmpty (fsmState.getDestPos());		
		}

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("map NotNull Test")]
		public void NotNullmapTest() 
		{
			Assert.NotNull (fsmState.GetTFDictionary());		
		}

		[Test]
		[Category ("ID NotNull Test")]
		public void NotNullIDTest() 
		{
			Assert.NotNull (fsmState.GetStateID());		
		}

		[Test]
		[Category ("RotSpeed NotNull Test")]
		public void NotNullRotSpeedTest() 
		{
			Assert.NotNull (fsmState.GetRotSpeed());		
		}

		[Test]
		[Category ("dist NotNull Test")]
		public void NotNulldistTest() 
		{
			Assert.NotNull (fsmState.GetDist());		
		}

		[Test]
		[Category ("destPos NotNull Test")]
		public void NotNulldestPosTest() 
		{
			Assert.NotNull (fsmState.getDestPos());		
		}

		//正常値テスト（オブジェクト）
		[Test]
		[Category ("map Test")]
		public void mapTest () 
		{
			Assert.IsEmpty (fsmState.GetTFDictionary());		
		}

		[Test]
		[Category ("ID Test")]
		public void IDTest () 
		{
			Assert.That (fsmState.GetStateID(), Is.EqualTo(FSMStateID.None));		
		}

		[Test]
		[Category ("RotSpeed Test")]
		public void RotSpeedTest () 
		{
			float f = 0.0f;
			Assert.That (fsmState.GetRotSpeed(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("dist Test")]
		public void distTest () 
		{
			float f = 0.0f;
			Assert.That (fsmState.GetDist(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("destPos Test")]
		public void destPosTest () 
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (fsmState.getDestPos(), Is.EqualTo(s));		
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
		[Category ("SetStateID Test")]
		public void SetStateIDTest () 
		{
			fsmState.SetStateID (FSMStateID.Attacking);
			Assert.That (fsmState.GetStateID(), Is.EqualTo(FSMStateID.Attacking));		
		}

		[Test]
		[Category ("SetRotSpeed Test")]
		public void SetRotSpeedTest () 
		{
			float f = 0.0f;
			fsmState.SetRotSpeed (360.0f);
			Assert.That (fsmState.GetRotSpeed(), Is.GreaterThan(f));		
		}

		[Test]
		[Category ("AddTransition Test")]
		public void AddTransitionTest () 
		{
			map.Add (Transition.LostPlayer, FSMStateID.Approaching);
			Assert.That (fsmState.AddTransition (Transition.LostPlayer, FSMStateID.Approaching), Is.EqualTo(map));
		}

		[Test]
		[Category ("DeleteTransition Test")]
		public void DeleteTransitionTest () 
		{
			Assert.That (fsmState.DeleteTransition (Transition.LostPlayer), Is.EqualTo(map));
		}

		[Test]
		[Category ("GetOutputState Test")]
		public void GetOutputStateTest () 
		{
			Assert.That (fsmState.GetOutputState (Transition.None), Is.EqualTo(FSMStateID.None));
		}

		[Test]
		[Category ("CheckTransOrID Test")]
		public void CheckTransOrIDTest () 
		{
			Assert.True (fsmState.CheckTransOrID (Transition.None, FSMStateID.Attacking));
		}

		[Test]
		[Category ("EmptyTrans Test")]
		public void EmptyTransTest () 
		{
			Assert.True (fsmState.EmptyTrans (Transition.None));
		}


		[Test]
		[Category ("EmptyID Test")]
		public void EmptyIDTest () 
		{
			Assert.True (fsmState.EmptyID (FSMStateID.None));
		}

		[Test]
		[Category ("CheckDist Test")]
		public void CheckDistTest () 
		{
			Assert.True (fsmState.CheckDist (7.0f, 5.0f, 10.0f));
		}

		[Test]
		[Category ("GreaterThanCheckReach Test")]
		public void GreaterThanCheckReachTest () 
		{
			Assert.True (fsmState.GreaterThanCheckReach (7.0f, 5.0f));
		}

		[Test]
		[Category ("LessCheckReach Test")]
		public void LessCheckReachTest () 
		{
			Assert.True (fsmState.LessCheckReach (5.0f, 7.0f));
		}

		[Test]
		[Category ("LessThanCheckReach Test")]
		public void LessThanCheckReachTest () 
		{
			Assert.True (fsmState.LessThanCheckReach (7.0f, 7.0f));
		}

		[Test]
		[Category ("RndPosition Test")]
		public void RndPositionTest () 
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (fsmState.rndPosition (), Is.EqualTo (s));
		}

		[Test]
		[Category ("CheckXRange Test")]
		public void CheckXRangeTest () 
		{
			float f = 0.0f;
			Assert.That (fsmState.CheckXRange (5.0f, 5.0f), Is.EqualTo (f));
		}

		[Test]
		[Category ("CheckXRange Range Test")]
		public void CheckXRangeRangeTest ([Range(-4.0f, 4.0f, 1.0f)]float l, [Range(-4.0f, 4.0f, 1.0f)]float o) 
		{
			float f = -8.0f;
			Assert.That (fsmState.CheckXRange (l, o), Is.GreaterThan (f));
		}

		[Test]
		[Category ("CheckZRange Test")]
		public void CheckZRangeTest () 
		{
			float f = 0.0f;
			Assert.That (fsmState.CheckZRange (5.0f, 5.0f), Is.EqualTo (f));
		}

		[Test]
		[Category ("CheckZRange Range Test")]
		public void CheckZRangeRangeTest ([Range(-4.0f, 4.0f, 1.0f)]float l, [Range(-4.0f, 4.0f, 1.0f)]float o) 
		{
			float f = -8.0f;
			Assert.That (fsmState.CheckZRange (l, o), Is.GreaterThan (f));
		}

		[Test]
		[Category ("LessThanXPos Test")]
		public void LessThanXPosTest () 
		{
			Assert.True (fsmState.LessThanXPos (8.0f));
		}

		[Test]
		[Category ("LessThanZPos Test")]
		public void LessThanZPosTest () 
		{
			Assert.True (fsmState.LessThanZPos (9.0f));
		}

		[Test]
		[Category ("CheckRange Test")]
		public void CheckRangeTest () 
		{
			Assert.True (fsmState.CheckRange (9.0f, 8.0f));
		}


	}
}

