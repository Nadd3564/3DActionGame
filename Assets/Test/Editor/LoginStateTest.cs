using NUnit.Framework;
using Cradle.DesignPattern;
using NSubstitute;


namespace Cradle.Test
{
	[TestFixture]
	[Category ("LogInState Test")]
	public class LogInStateTest
	{
		private LogInState logInState;
		private SceneManagerController manager;
		
		[SetUp] public void Init()
		{
			logInState = Substitute.For<LogInState>();
			setMock ();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}

		//データ型テスト（オブジェクト）
		[Test]
		[Category ("id Type Test")]
		public void IdTypeTest() 
		{
			Assert.That (logInState.GetID(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("passwordToEdit Type Test")]
		public void passwordToEditTypeTest() 
		{
			Assert.That (logInState.GetPass(), Is.TypeOf(typeof(string)));		
		}

		[Test]
		[Category ("success Type Test")]
		public void successTypeTest() 
		{
			Assert.That (logInState.GetSuccess(), Is.TypeOf(typeof(string)));		
		}

		//正常値テスト（オブジェクト）
		[Test]
		[Category ("id Test")]
		public void IdTest () 
		{
			Assert.IsEmpty (logInState.GetID());
		}
		
		[Test]
		[Category ("passwordToEdit Test")]
		public void PasswordToEditTest () 
		{
			Assert.IsEmpty (logInState.GetPass());
		}
		
		[Test]
		[Category ("success Test")]
		public void SuccessTest () 
		{
			string text = "AuthenticateProxy: Success Authenticated";
			StringAssert.Contains (text, logInState.GetSuccess());
		}

		[Test]
		[Category ("color Test")]
		public void ColorTest () 
		{
			string s = "GUIStyle ''";
			logInState.SetTextStyle ();
			StringAssert.Contains (s ,logInState.GetColor());
		}

		[Test]
		[Category ("buttonStyle Test")]
		public void buttonStyleTest () 
		{
			string s = "GUIStyle 'button'";
			logInState.SetButtonStyle ();
			StringAssert.Contains (s ,logInState.GetButtonStyle());
		}

		[Test]
		[Category ("aut Test")]
		public void autTest () 
		{
			logInState.AuthenticateObject ();
			Assert.IsNotNull (logInState.GetAut());
			Assert.That (logInState.GetAut(), Is.TypeOf(typeof(Authentication)));
		}


		//正常値テスト（メソッド）
		[Test]
		[Category ("StateUpdate Test")]
		public void StateUpdateTest () 
		{
			logInState.StateUpdate ();
			Assert.IsNotNull (logInState.GetAut());
		}

		[Test]
		[Category ("IsNotEmptyId Test")]
		public void IsNotEmptyIdTest () 
		{
			Assert.True (logInState.IsNotEmptyId());
		}

		[Test]
		[Category ("IsNotEmptyPass Test")]
		public void IsNotEmptyPassTest () 
		{
			Assert.True (logInState.IsNotEmptyPass());
		}

		[Test]
		[Category ("IsNotEmptyIdPass Test")]
		public void IsNotEmptyIdPassTest () 
		{
			Assert.True (logInState.IsNotEmptyIdPass());
		}

		[Test]
		[Category ("IsReturn Test")]
		public void IsReturnTest () 
		{
			Assert.True (logInState.IsReturn());
		}

		[Test]
		[Category ("IsKeyUp Test")]
		public void IsKeyUptest () 
		{
			Assert.True (logInState.IsKeyUp());
		}

		[Test]
		[Category ("IsKeyUpReturn Test")]
		public void IsKeyUpReturnTest () 
		{
			Assert.True (logInState.IsKeyUpReturn());
		}

		[Test]
		[Category ("IsCheckInput Test")]
		public void IsCheckInputTest () 
		{
			Assert.True (logInState.IsCheckInput());
		}

		[Test]
		[Category ("IsKeyUpRetWithNotEmpId Test")]
		public void IsKeyUpRetWithNotEmpIdTest () 
		{
			Assert.True (logInState.IsKeyUpRetWithNotEmpId());
		}

		[Test]
		[Category ("IsButtonOrEscape Test")]
		public void IsButtonOrEscapeTest () 
		{
			Assert.True (logInState.IsButtonOrEscape());
		}

		[Test]
		[Category ("IsKeyDown Test")]
		public void IsKeyDownTest () 
		{
			Assert.True (logInState.IsKeyDown());
		}

		[Test]
		[Category ("IsKeyDownWithReturn Test")]
		public void IsKeyDownWithReturnTest () 
		{
			Assert.True (logInState.IsKeyDownWithReturn());
		}

		[Test]
		[Category ("IsLogInButton Test")]
		public void IsLogInButtonTest () 
		{
			Assert.True (logInState.IsLogInButton());
		}

		[Test]
		[Category ("IsCheckInputId Test")]
		public void IsCheckInputIdTest () 
		{
			string s = "";
			Assert.True (logInState.IsCheckInputId(s));
		}

		private void setMock()
		{
			logInState.IsNotEmptyId ().Returns (true);
			logInState.IsNotEmptyPass ().Returns (true);
			logInState.IsKeyUp().Returns(true);
			logInState.IsReturn().Returns(true);
			logInState.IsButtonOrEscape ().Returns (true);
			logInState.IsKeyDown ().Returns (true);
			logInState.IsLogInButton ().Returns (true);
		}
	}
}

