using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("FollowCamera Test")]
	public class FollowCameraTest
	{
		public ICameraController iCamera;
		public FollowCameraController fCController;
		
		[SetUp] public void Init()
		{ 
			iCamera = GetCameraMock ();
			fCController = GetControllerMock (iCamera);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		//正常値テスト
		[Test]
		[Category ("Calc Test")]
		public void CalcTimeTest ()
		{
			Assert.That (fCController.CalcTime(), Is.EqualTo (0.0f));
		}
		
		[Test]
		[Category ("Calc Test")]
		[TestCase(null)]
		[TestCase("string")]
		public void SetAnglePerPixelTest([Values(-1.0f,0.0f,1.0f,2.0f)]float x) 
		{
			fCController.SetAnglePerPixel ();
			Assert.That (fCController.anglePerPixel, Is.EqualTo(x));		
		}

		[Test]
		[Category ("Calc Test")]
		[TestCase(null)]
		[TestCase("string")]
		public void SetHorizontalAngleTest([Values(-1.0f,0.0f,1.0f,2.0f)]float x) 
		{
			fCController.SetHorizontalAngle();
			Assert.That (fCController.horizontalAngle, Is.EqualTo(x));		
		}

		private ICameraController GetCameraMock () {
			return Substitute.For<ICameraController> ();
		}
		
		private FollowCameraController GetControllerMock(ICameraController iCamera) {
			var fCController = Substitute.For<FollowCameraController> ();
			fCController.SetCameraController (iCamera);
			fCController.CalcTime ().Returns (0.0f);
			return fCController;
		}
		
	}
}

