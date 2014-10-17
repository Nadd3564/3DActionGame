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


		//データ型テスト（オブジェクト）
		[Test]
		[Category ("destination Type Test")]
		public void destinationTypeTest() 
		{
			Assert.That (tCController.getDestination(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("position Type Test")]
		public void positionTypeTest() 
		{
			Assert.That (tCController.getPosition(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("offset Type Test")]
		public void offsetTypeTest() 
		{
			Assert.That (tCController.getOffSet(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("radius Type Test")]
		public void radiusTypeTest() 
		{
			Assert.That (tCController.GetRadius(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("angularVelocity Type Test")]
		public void angularVelocityTypeTest() 
		{
			Assert.That (tCController.GetAngularVelocity(), Is.TypeOf(typeof(float)));		
		}

		[Test]
		[Category ("angle Type Test")]
		public void angleTypeTest() 
		{
			Assert.That (tCController.GetAngle(), Is.TypeOf(typeof(float)));		
		}


		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("destination NotEmpty Test")]
		public void IsNotEmptyDestinationTest() 
		{
			Assert.IsNotEmpty (tCController.getDestination());		
		}

		[Test]
		[Category ("position NotEmpty Test")]
		public void IsNotEmptyPositionTest() 
		{
			Assert.IsNotEmpty (tCController.getPosition());		
		}

		[Test]
		[Category ("offset NotEmpty Test")]
		public void IsNotEmptyoffsetTest() 
		{
			Assert.IsNotEmpty (tCController.getOffSet());		
		}


		//Null値テスト（オブジェクト）
		[Test]
		[Category ("destination NotNull Test")]
		public void NotNullDestinationTest() 
		{
			Assert.NotNull (tCController.getDestination());		
		}

		[Test]
		[Category ("position NotNull Test")]
		public void NotNullPositionTest() 
		{
			Assert.NotNull (tCController.getPosition());		
		}

		[Test]
		[Category ("offset NotNull Test")]
		public void NotNullOffsetTest() 
		{
			Assert.NotNull (tCController.getOffSet());		
		}

		[Test]
		[Category ("radius NotNull Test")]
		public void NotNullRadiusTest() 
		{
			Assert.NotNull (tCController.GetRadius());		
		}

		[Test]
		[Category ("angularVelocity NotNull Test")]
		public void NotNullAngularVelocityTest() 
		{
			Assert.NotNull (tCController.GetAngularVelocity());		
		}

		[Test]
		[Category ("angle NotNull Test")]
		public void NotNullAngleTest() 
		{
			Assert.NotNull (tCController.GetAngle());		
		}

		//正常値テスト（オブジェクト）
		[Test]
		[Category ("destination Test")]
		public void destinationTest() 
		{
			string s = "(0.0, 0.5, 0.0)";
			Assert.That (tCController.getDestination(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("position Test")]
		public void positionTest() 
		{
			string s = "(0.0, 0.5, 0.0)";
			Assert.That (tCController.getPosition(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("offset Test")]
		public void offsetTest() 
		{
			string s = "(0.0, 0.0, 0.0)";
			Assert.That (tCController.getOffSet(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("radius Test")]
		public void radiusTest() 
		{
			float f = 1.0f;
			Assert.That (tCController.GetRadius(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("angularVelocity Test")]
		public void angularVelocityTest() 
		{
			float f = 480.0f;
			Assert.That (tCController.GetAngularVelocity(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("angle Test")]
		public void angleTest() 
		{
			float f = 0.0f;
			Assert.That (tCController.GetAngle(), Is.EqualTo(f));		
		}


		//正常値テスト(メソッド)
		[Test]
		[Category ("SetUpPosition Test")]
		public void SetUpPositionTest() 
		{
			string s = "(0.0, 0.5, 0.0)";
			tCController.SetUpPosition ();
			Assert.That (tCController.getPosition(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetDest Test")]
		public void SetDestTest() 
		{
			string s = "(0.0, 0.5, 0.0)";
			tCController.SetDest ();
			Assert.That (tCController.getPosition(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("OffSet Test")]
		public void OffSetTest() 
		{
			string s = "(0.0, 0.0, 1.0)";
			tCController.OffSet();
			Assert.That (tCController.getOffSet(), Is.EqualTo(s));		
		}

		[Test]
		[Category ("SetUpAngle Test")]
		public void SetUpAngleTest() 
		{
			float f = 5.0f;
			tCController.SetUpAngle(5.0f);
			Assert.That (tCController.GetAngle(), Is.EqualTo(f));		
		}

		[Test]
		[Category ("SetAngularVelocity Test")]
		public void SetAngularVelocityTest() 
		{
			float f = 480.0f;
			tCController.SetAngularVelocity(1.0f);
			Assert.That (tCController.GetAngularVelocity() * 1.0f, Is.EqualTo(f));		
		}


		private ICursorController GetCursorMock () {
			return Substitute.For<ICursorController> ();
		}
		
		private TargetCursorController GetControllerMock(ICursorController iCursor) {
			var tCController = Substitute.For<TargetCursorController> ();
			tCController.SetCursorController (iCursor);
			return tCController;
		}
		
	}
}

