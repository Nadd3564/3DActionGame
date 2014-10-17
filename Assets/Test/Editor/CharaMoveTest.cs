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
		[Category ("getCharaTag Test")]
		public void getCharaTag()
		{
			string s = "(0.0)";
			Assert.That (cMove.getCharacterTargetRot(), Is.EqualTo (s));
		}

		//正常値テスト
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
			return cMove;
		}
		
	}
}

