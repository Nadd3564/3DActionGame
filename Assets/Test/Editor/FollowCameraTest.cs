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
			iCamera.Moved ().Returns (true);
			iCamera.NotNullLookTarget ().Returns (true);
			fCController = GetControllerMock (iCamera);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}

		//データ型テスト（オブジェクト）
		[Test]
		[Category ("offset Type Test")]
		public void offsetTypeTest() 
		{
			Assert.That (fCController.getOffSet(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("lookPosition Type Test")]
		public void lookPositionTypeTest() 
		{
			Assert.That (fCController.getLookPosition(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("relativePos Type Test")]
		public void relativePosTypeTest() 
		{
			Assert.That (fCController.getRelativePos(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("delta Type Test")]
		public void deltaTypeTest() 
		{
			Assert.That (fCController.getDelta(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("distance Type Test")]
		public void distanceTypeTest() 
		{
			Assert.That (fCController.GetDistance(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("horizontalAngle Type Test")]
		public void horizontalAngleTypeTest() 
		{
			Assert.That (fCController.GetHorizontalAngle(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("rotAngle Type Test")]
		public void drotAngleTypeTest() 
		{
			Assert.That (fCController.GetRotAngle(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("verticalAngle Type Test")]
		public void verticalAngleTypeTest() 
		{
			Assert.That (fCController.GetVerticalAngle(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("anglePerPixel Type Test")]
		public void anglePerPixelTypeTest() 
		{
			Assert.That (fCController.GetAnglePerPixel(), Is.TypeOf(typeof(float)));		
		}


		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("offset NotEmpty Test")]
		public void IsNotEmptyOffsetTest() 
		{
			Assert.IsNotEmpty (fCController.getOffSet());		
		}

		[Test]
		[Category ("lookPosition NotEmpty Test")]
		public void IsNotEmptyLookPositionTest() 
		{
			Assert.IsNotEmpty (fCController.getLookPosition());		
		}

		[Test]
		[Category ("relativePos NotEmpty Test")]
		public void IsNotEmptyrelativePosTest() 
		{
			Assert.IsNotEmpty (fCController.getRelativePos());		
		}

		[Test]
		[Category ("delta NotEmpty Test")]
		public void IsNotEmptyDeltaTest() 
		{
			Assert.IsNotEmpty (fCController.getDelta());		
		}


		//Null値テスト（オブジェクト）
		[Test]
		[Category ("offset NotNull Test")]
		public void NotNullOffsetTest() 
		{
			Assert.NotNull (fCController.getOffSet());		
		}

		[Test]
		[Category ("lookPosition NotNull Test")]
		public void NotNullLookPositionTest() 
		{
			Assert.NotNull (fCController.getLookPosition());		
		}

		[Test]
		[Category ("relativePos NotNull Test")]
		public void NotNullRelativePosTest() 
		{
			Assert.NotNull (fCController.getRelativePos());		
		}

		[Test]
		[Category ("delta NotNull Test")]
		public void NotNullDeltaTest() 
		{
			Assert.NotNull (fCController.getDelta());		
		}

		[Test]
		[Category ("distance NotNull Test")]
		public void NotNullDistanceTest() 
		{
			Assert.NotNull (fCController.GetDistance());		
		}

		[Test]
		[Category ("horizontalAngle NotNull Test")]
		public void NotNullHorizontalAngleTest() 
		{
			Assert.NotNull (fCController.GetHorizontalAngle());		
		}

		[Test]
		[Category ("rotAngle NotNull Test")]
		public void NotNullRotAngleTest() 
		{
			Assert.NotNull (fCController.GetRotAngle());		
		}

		[Test]
		[Category ("verticalAngle NotNull Test")]
		public void NotNullVerticalAngleTest() 
		{
			Assert.NotNull (fCController.GetVerticalAngle());		
		}

		[Test]
		[Category ("anglePerPixel NotNull Test")]
		public void NotNullAnglePerPixelTest() 
		{
			Assert.NotNull (fCController.GetAnglePerPixel());		
		}


		//正常値テスト（オブジェクト）
		[Test]
		[Category ("offset Test")]
		public void offsetTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (fCController.getOffSet(), Is.EqualTo(s));		
		}
		
		[Test]
		[Category ("lookPosition Test")]
		public void lookPositionTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (fCController.getLookPosition(), Is.EqualTo(s));		
		}
		
		[Test]
		[Category ("relativePos Test")]
		public void relativePosTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (fCController.getRelativePos(), Is.EqualTo(s));		
		}
		
		[Test]
		[Category ("delta Test")]
		public void deltaTest() 
		{
			string s = "(0.0, 0.0)";
			Assert.That (fCController.getDelta(), Is.EqualTo(s));	
		}
		
		[Test]
		[Category ("distance Test")]
		public void distanceTest() 
		{
			float f = 5.0f;
			Assert.That (fCController.GetDistance(), Is.EqualTo(f));		
		}
		
		[Test]
		[Category ("horizontalAngle Test")]
		public void horizontalAngleTest() 
		{
			float f = 180.0f;
			Assert.That (fCController.GetHorizontalAngle(), Is.EqualTo(f));		
		}
		
		[Test]
		[Category ("rotAngle Test")]
		public void rotAngleTest() 
		{
			float f = 180.0f;
			Assert.That (fCController.GetRotAngle(), Is.EqualTo(f));		
		}
		
		[Test]
		[Category ("verticalAngle Test")]
		public void verticalAngleTest() 
		{
			float f = 10.0f;
			Assert.That (fCController.GetVerticalAngle(), Is.EqualTo(f));	
		}
		
		[Test]
		[Category ("anglePerPixel Test")]
		public void anglePerPixelTest() 
		{
			float f = 0.0f;
			Assert.That (fCController.GetAnglePerPixel(), Is.EqualTo(f));		
		}


		//正常値テスト(メソッド)
		[Test]
		[Category ("SetAnglePerPixel Test")]
		public void SetAnglePerPixelTest() 
		{
			float f = 0.0f;
			fCController.SetAnglePerPixel ();
			Assert.That (fCController.GetAnglePerPixel(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetHorizontalAngle Test")]
		public void SetHorizontalAngleTest() 
		{
			float f = 180.0f;
			fCController.SetHorizontalAngle ();
			Assert.That (fCController.GetHorizontalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetUpHorizontalAngle Test")]
		public void SetUpHorizontalAngleTest() 
		{
			float f = 190.0f;
			fCController.SetUpHorizontalAngle (10.0f);
			Assert.That (fCController.GetHorizontalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetUpHorizontalAngle Range Test")]
		public void SetUpHorizontalAngleRangeTest([Range(-40.0f, 40.0f, 10.0f)]float l) 
		{
			float f = 180.0f;
			f += l;
			fCController.SetUpHorizontalAngle (l);
			Assert.That (fCController.GetHorizontalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetVerticalAngle Test")]
		public void SetVerticalAngleTest() 
		{
			float f = 10.0f;
			fCController.SetVerticalAngle ();
			Assert.That (fCController.GetVerticalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetDownVerticalAngle Test")]
		public void SetDownVerticalAngleTest() 
		{
			float f = 0.0f;
			fCController.SetDownVerticalAngle (10.0f);
			Assert.That (fCController.GetVerticalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetDownVerticalAngle Range Test")]
		public void SetDownVerticalAngleRangeTest([Range(-4, 4, 1)]float l) 
		{
			float f = 10.0f;
			f -= l;
			fCController.SetDownVerticalAngle (l);
			Assert.That (fCController.GetVerticalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("RelativePos Test")]
		public void ReltativePos() 
		{
			string s = "(0.0, 0.9, 4.9)";
			fCController.RelativePos ();
			Assert.That (fCController.getRelativePos(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("MoveAngle Test")]
		public void MoveAngle() 
		{
			Assert.True (fCController.MoveAngle());		
		}

		[Test]
		[Category ("MoveAngle CheckHorizontalAngle Test")]
		public void MoveAngleCheckHorizontalAngleTest() 
		{
			float f = 180.0f;
			fCController.MoveAngle ();

			Assert.That (fCController.GetHorizontalAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("CameraPosUpdate Test")]
		public void CameraPosUpdateTest() 
		{
			Assert.True (fCController.CameraPosUpdate());		
		}

		[Test]
		[Category ("CameraPosUpdate CheckRelativePos Test")]
		public void CameraPosUpdateCheckRelativePosTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			fCController.CameraPosUpdate ();
			Assert.That (fCController.getRelativePos(), Is.Not.EqualTo(s));		
		}

		//例外検出テスト
		[Test]
		[Category ("MoveAngle Exception Test")]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void MoveAngleExceptionTest() 
		{
			//Arrange
			fCController.GetAnglePerPixel ().Returns (-1.0f);

			//Assert
			fCController.MoveAngle ();
		}


		private ICameraController GetCameraMock () {
			return Substitute.For<ICameraController> ();
		}
		
		private FollowCameraController GetControllerMock(ICameraController iCamera) {
			var fCController = Substitute.For<FollowCameraController> ();
			fCController.SetCameraController (iCamera);
			return fCController;
		}
		
	}
}

