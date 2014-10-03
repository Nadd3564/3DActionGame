using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("TargetCursor Test")]
	public class TargetCursorTest
	{
		public ICursorController iCursor;
		public TargetCursorController tCController;
		
		[SetUp] public void Init()
		{ 
			iCursor = GetCursorMock ();
			tCController = GetControllerMock (iCursor);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcTimeTest ()
		{
			Assert.That (tCController.CalcTime(), Is.EqualTo (0.0f));
		}
		
		[Test]
		[Category ("Calc Test")]
		[TestCase(1000)]
		[TestCase(null)]
		[TestCase("string")]
		public void SetUpAngleTest([Range(-1.0f,10.0f,1.0f)]float f) 
		{
			tCController.SetUpAngle(f);
			Assert.That (tCController.angle, Is.EqualTo(f));		
		}

		[Test]
		[Category ("Calc Test")]
		[TestCase(1)]
		[TestCase(1000)]
		[TestCase(null)]
		[TestCase("string")]
		public void SetAngularVelocityTest([Range(-120.0f,600.0f,120.0f)]float f) 
		{
			tCController.SetAngularVelocity(f);
			Assert.That (tCController.angularVelocity, Is.EqualTo(f));		
		}

		private ICursorController GetCursorMock () {
			return Substitute.For<ICursorController> ();
		}
		
		private TargetCursorController GetControllerMock(ICursorController iCursor) {
			var tCController = Substitute.For<TargetCursorController> ();
			tCController.SetCursorController (iCursor);
			tCController.CalcTime ().Returns (0.0f);
			return tCController;
		}
		
	}
}

