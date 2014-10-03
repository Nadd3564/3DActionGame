using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("DropItem Test")]
	public class DropItemTest
	{
		public IDropItemController iDrop;
		public DropItemController dIController;
		
		[SetUp] public void Init()
		{ 
			iDrop = GetItemMock ();
			dIController = GetControllerMock (iDrop);
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcTimeTest ()
		{
			Assert.That (dIController.CalcTime(), Is.EqualTo (0.0f));
		}
		
		[Test]
		[Category ("Calc Test")]
		[TestCase(true)]
		public void IsPlayerTest (bool flg)
		{
			string s = "Player";
			Assert.That (dIController.IsPlayer(s), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Calc Test")]
		[ExpectedException(typeof(DifferentStringException))]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void IsPlayerWithDifferntStringTest (bool flg)
		{
			string s = "Player";
			Assert.That (dIController.IsPlayer(s), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Calc Test")]
		[ExpectedException(typeof(DifferentStringException))]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void IsPlayerWithDifferntStringTest1 (bool flg)
		{
			string s = "Player";
			try{
				s = "NPC";
			}
			catch(DifferentStringException e)
			{
			}

			Assert.That (dIController.IsPlayer(s), Is.EqualTo(flg));
		}


		[Test]
		[Category ("Calc Test")]
		[TestCase(true)]
		[TestCase(false)]
		[TestCase(null)]
		public void IsTerrainTest (bool flg) 
		{
			string s = "Player";
			string t = "Terrain";
			Assert.That (dIController.IsTerrain(t), Is.EqualTo(flg));
		}
		
		private IDropItemController GetItemMock () {
			return Substitute.For<IDropItemController> ();
		}
		
		private DropItemController GetControllerMock(IDropItemController iDrop) {
			var dIController = Substitute.For<DropItemController> ();
			dIController.SetDropItemController (iDrop);
			dIController.CalcTime ().Returns (0.0f);
			return dIController;
		}
		
	}
}

