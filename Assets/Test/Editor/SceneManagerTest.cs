using NUnit.Framework;
using System;
using System.Collections.Generic;
using NSubstitute;
using Cradle.DesignPattern;

namespace Cradle.Test
{
	[TestFixture]
	[Category ("SceneManager Test")]
	public class SceneManagerTest
	{
		private IManagerController iManager;
		private SceneManagerController managerCtrl;
		private SceneManager manager;
		
		
		[SetUp] public void Init()
		{
			iManager = GetManagerMock ();
			managerCtrl = GetControllerMock (iManager);
			manager = Substitute.For<SceneManager>();
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		

		//Null値テスト（オブジェクト）
		[Test]
		[Category ("activeState Null Test")]
		public void ActiveStateNullTest() 
		{
			Assert.Null (managerCtrl.GetActiveState());		
		}


		//正常値テスト(オブジェクト)
		[Test]
		[Category ("activeState Test")]
		public void activeState ()
		{
			managerCtrl.InitState (manager);
			Assert.That (managerCtrl.GetActiveState(), Is.EqualTo(manager));
		}


		//正常値テスト(メソッド)
		[Test]
		[Category ("InitState Test")]
		public void InitStateTest ()
		{
			managerCtrl.InitState (manager);
			Assert.That (managerCtrl.GetActiveState(), Is.TypeOf(typeof(TitleState)));
		}

		[Test]
		[Category ("GetInstance Test")]
		public void GetInstanceTest ()
		{
			Assert.Null (managerCtrl.GetInstance());
		}

		[Test]
		[Category ("SetInstance Test")]
		public void SetInstanceTest ()
		{
			managerCtrl.SetInstance (manager);
			Assert.That (managerCtrl.GetInstance(), Is.EqualTo(manager));
		}

		[Test]
		[Category ("IsNotNullState Test")]
		public void IsNotNullStateTest ()
		{
			managerCtrl.InitState (manager);
			Assert.True (managerCtrl.IsNotNullState());
		}

		[Test]
		[Category ("SwitchState Test")]
		public void SwitchStateTest ()
		{
			managerCtrl.SwitchState (new LogInState(manager));
			Assert.That (managerCtrl.GetActiveState(), Is.TypeOf(typeof(LogInState)));
		}

		[Test]
		[Category ("IsNullInstance Test")]
		public void IsNullInstanceTest ()
		{
			Assert.True (managerCtrl.IsNullInstance());
		}

		[Test]
		[Category ("IsNotLogInScene Test")]
		public void IsNotLogInSceneTest ()
		{
			Assert.True (managerCtrl.IsNotLogInScene());
		}

		[Test]
		[Category ("IsPlayScene Test")]
		public void IsPlaySceneTest ()
		{
			Assert.False (managerCtrl.IsPlayScene());
		}



		private IManagerController GetManagerMock () {
			return Substitute.For<IManagerController> ();
		}
		
		private SceneManagerController GetControllerMock(IManagerController iManager) {
			var managerCtrl = Substitute.For<SceneManagerController> ();
			managerCtrl.SetManagerController (iManager);
			return managerCtrl;
		}

	}
}