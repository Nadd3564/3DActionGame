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

		//正常値テスト
		[Test]
		[Category ("Input Test")]
		[TestCase(true)]
		[TestCase(false)]
		public void IsClickedTest (bool flg)
		{
			Assert.That (inputManager.IsClicked (), Is.EqualTo (flg));
		}

		[Test]
		[Category ("Input Test")]
		[TestCase(true)]
		[TestCase(false)]
		public void InputTestGetButtonDownTest (bool flg)
		{
			Assert.That (inputManager.InputTestGetButton(), Is.EqualTo (flg));
		}


		[Test]
		[Category ("Input Test")]
		[TestCase(true)]
		[TestCase(false)]
		public void IsClickingTest1 (bool flg)
		{
			inputManager.InputTestGetButtonFire1();
			inputManager.InputTestGetButtonUpFire1();
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
			bool xLess = x < inputManager.IsGetDeltaPosition().x;
			bool yLess = y < inputManager.IsGetDeltaPosition().y;
			inputManager.GetDeltaDistance ();
			Assert.AreEqual (inputManager.IsGetDeltaPosition(), Is.EqualTo(xLess));
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
