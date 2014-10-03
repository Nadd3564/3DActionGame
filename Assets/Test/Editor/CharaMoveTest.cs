using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("CharaMove Test")]
	public class CharaMoveTest
	{
		public IMoveController move;
		public CharaMoveController cMove;
		
		[SetUp] public void Init()
		{ 
			move = GetMoveMock ();
			cMove = GetControllerMock (move);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcTimeTest ()
		{
			Assert.That (cMove.CalcTime(), Is.EqualTo (0.0f));
		}
		
		[Test]
		[Category ("Calc Test")]
		[TestCase(-1.0f)]
		[TestCase(null)]
		public void GetWalkSpeedTest ([Range(0.0f,10.0f,1.0f)]float x)
		{
			Assert.That (cMove.GetWalkSpeed(), Is.EqualTo (x));
		}
		
		private IMoveController GetMoveMock () {
			return Substitute.For<IMoveController> ();
		}
		
		private CharaMoveController GetControllerMock(IMoveController move) {
			var cMove = Substitute.For<CharaMoveController> ();
			cMove.SetMoveController (move);
			cMove.CalcTime ().Returns (0.0f);
			return cMove;
		}
		
	}
}

