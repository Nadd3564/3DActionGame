using NUnit.Framework;
using System;
using NSubstitute;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("InputManager Test")]
	public class InputManagerTest
	{
		public IInputController input;
		public InputManagerController inputManager;
		
		[SetUp] public void Init()
		{ 
			input = GetInputMock ();
			inputManager = GetControllerMock (input);	
		}
		
		[TearDown] public void Cleanup()
		{
			
		}

		//データ型テスト（オブジェクト）
		[Test]
		[Category ("moved Type Test")]
		public void movedType() 
		{
			Assert.That (inputManager.IsMoved(), Is.TypeOf(typeof(bool)));		
		}

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("moved NotNull Test")]
		public void NotNullMovedTest() 
		{
			Assert.NotNull (inputManager.IsMoved());		
		}

		//データ存在テスト(オブジェクト)
		[Test]
		[Category ("SlideStartPosition NotEmpty Test")]
		public void IsNotEmptySlideStartPositionTest() 
		{
			Assert.IsNotEmpty (inputManager.getSlideStartPosition());		
		}


		[Test]
		[Category ("PrevPosition NotEmpty Test")]
		public void IsNotEmptyPrevPositionTest() 
		{
			Assert.IsNotEmpty (inputManager.getPrevPosition());		
		}

		[Test]
		[Category ("Delta NotEmpty Test")]
		public void IsNotEmptyDeltaPositionTest() 
		{
			Assert.IsNotEmpty (inputManager.getDeltaPosition());		
		}

		//正常値テスト(オブジェクト)
		[Test]
		[Category ("SlideStartPosition Test")]
		public void SlideStartPosition ()
		{
			string s = "(0.0, 0.0)";
			Assert.That (inputManager.getSlideStartPosition(), Is.EqualTo(s));
		}

		[Test]
		[Category ("prevPosition Test")]
		public void prevPosition ()
		{
			string s = "(0.0, 0.0)";
			Assert.That (inputManager.getPrevPosition(), Is.EqualTo(s));
		}

		[Test]
		[Category ("delta Test")]
		public void delta ()
		{
			string s = "(0.0, 0.0)";
			Assert.That (inputManager.getDeltaPosition(), Is.EqualTo(s));
		}

		[Test]
		[Category ("moved Test")]
		public void moved ()
		{
			Assert.False (inputManager.IsMoved());
		}


		//正常値テスト(メソッド)
		[Test]
		[Category ("SetSlideStartPosition Test")]
		public void SetSlideStartPositionTest ()
		{
			string s = "(0.0, 0.0)";
			inputManager.SetSlideStartPosition ();
			Assert.That (inputManager.getPrevPosition(), Is.EqualTo (s));
		}

		[Test]
		[Category ("SetMoved Test")]
		public void SetMovedTest ()
		{
			bool flg = inputManager.SetMoved (true);
			Assert.That (inputManager.IsMoved(), Is.EqualTo (flg));
		}

		[Test]
		[Category ("GetDeltaDistance Test")]
		public void GetDeltaDistanceTest ()
		{
			string s = "(0.0f, 0.0f)";
			inputManager.GetDeltaDistance ();
			Assert.That (inputManager.getDeltaPosition(), Is.Not.EqualTo (s));
		}

		[Test]
		[Category ("StayDelta Test")]
		public void StayDeltaTest ()
		{
			string s = "(0.0, 0.0)";
			inputManager.StayDelta ();
			Assert.That (inputManager.getDeltaPosition(), Is.EqualTo (s));
		}

		[Test]
		[Category ("PrevPosition Test")]
		public void PrevPositonTest ()
		{
			string s = "(0.0, 0.0)";
			inputManager.PrevPosition ();
			Assert.That (inputManager.getPrevPosition(), Is.Not.EqualTo (s));
		}

		[Test]
		[Category ("GetCursorPosition Test")]
		public void GetCursorPositionTest ()
		{
			string s = "(0.0, 0.0)";
			inputManager.GetCursorPosition ();
			Assert.That (inputManager.getCursorPosition(), Is.Not.EqualTo (s));
		}

		[Test]
		[Category ("IsClicking Test")]
		public void IsClickingTest ()
		{
			//Arrange
			input.InputGetButtonUpFire1 ().Returns(true);
			input.InputGetButtonFire1 ().Returns (true);

			Assert.True(inputManager.IsClicking());
		}

		[Test]
		[Category ("SlideStart Test")]
		public void SlideStartTest ()
		{
			//Arrange
			input.InputGetButtonDown ().Returns (true);

			//Act
			inputManager.SlideStart ();
			string s = "(0.0, 0.0)";

			Assert.That(inputManager.getSlideStartPosition(), Is.Not.EqualTo(s));
		}

		[Test]
		[Category ("Sliding Test")]
		public void SlidingTest ()
		{
			//Arrange
			input.InputGetButtonDown ().Returns (true);
			
			//Act
			inputManager.Sliding();
			
			Assert.True(inputManager.SlidingCursor());
		}

		[Test]
		[Category ("Moved Test")]
		public void MovedTest ()
		{
			string s = "(0.0, 0.0)" ;

			//Act
			inputManager.SetMoved (true);
			inputManager.Moved ();
			
			Assert.That(inputManager.getDeltaPosition(), Is.Not.EqualTo("s"));
		}

		[Test]
		[Category ("Moved else Test")]
		public void MovedElseTest ()
		{
			string s = "(0.0, 0.0)" ;
			
			//Act
			inputManager.Moved ();
			
			Assert.That(inputManager.getDeltaPosition(), Is.EqualTo(s));
		}

		[Test]
		[Category ("StopSlide Test")]
		public void StopSlideTest ()
		{
			//Arrange
			input.InputGetButtonUp ().Returns (true);

			//Act
			inputManager.SetMoved (true);
			inputManager.StopSlide ();
			
			Assert.False(inputManager.IsMoved());
		}


		private IInputController GetInputMock () {
			return Substitute.For<IInputController> ();
		}
		
		private InputManagerController GetControllerMock(IInputController input) {
			var inputManager = Substitute.For<InputManagerController> ();
			inputManager.SetInputController (input);
			return inputManager;
		}
		
	}
}
