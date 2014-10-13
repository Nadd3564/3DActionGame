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

		//データ存在テスト
		[Test]
		[Category ("SlideStartPosition NotEmpty Test")]
		public void IsNotEmptySlideStartPositionTest() 
		{
			Assert.IsNotEmpty (inputManager.getSlideStartPosition());		
		}


		[Test]
		[Category ("SlideStartPosition NotEmpty Test")]
		public void IsNotEmptySlideStartPositionTest() 
		{
			Assert.IsNotEmpty (inputManager.getSlideStartPosition());		
		}

		[Test]
		[Category ("SlideStartPosition NotEmpty Test")]
		public void IsNotEmptySlideStartPositionTest() 
		{
			Assert.IsNotEmpty (inputManager.getSlideStartPosition());		
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


		//正常値テスト
		[Test]
		[Category ("Input Test")]
		[TestCase(true)]
		[TestCase(false)]
		public void IsClickedTest (bool flg)
		{
			Assert.That (inputManager.IsClicking(), Is.EqualTo (flg));
		}

		[Test]
		[Category ("Input Test")]
		[TestCase(true)]
		[TestCase(false)]
		public void InputTestGetButtonDownTest (bool flg)
		{
			Assert.That (input.InputGetButtonDown(), Is.EqualTo (flg));
		}


		[Test]
		[Category ("Input Test")]
		[TestCase(true)]
		[TestCase(false)]
		public void IsClickingTest1 (bool flg)
		{
			input.InputGetButtonFire1();
			input.InputGetButtonUpFire1 ();
			Assert.That (inputManager.IsClicking(), Is.EqualTo(flg));
		}

		[Test]
		[Category ("Input Test")]
		public void SetSlideStartPositionTest ()
		{
			inputManager.SetSlideStartPosition ();
			Assert.That (inputManager.GetSlideStartPosition(), Is.EqualTo (inputManager.IsGetCursorPosition()));
		}

		[Test]
		[Category ("Input Test")]
		public void GetDeltaDistanceTest (float x, float y)
		{
			//bool xLess = x < inputManager.IsGetDeltaPosition ().x.ToString ();
			//bool yLess = y < inputManager.IsGetDeltaPosition().y.ToString();
			string xLess = inputManager.GetSlideStartPosition().ToString ();
			//inputManager.GetDeltaDistance ();
			Assert.IsEmpty(xLess);
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
