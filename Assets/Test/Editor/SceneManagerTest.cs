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
		
		
		[SetUp] public void Init()
		{
			iManager = GetManagerMock ();
			managerCtrl = GetControllerMock (iManager);
		}
		
		[TearDown] public void Cleanup()
		{
			
		}
		
		
		//データ型テスト（オブジェクト）
		[Test]
		[Category ("activeState Type Test")]
		public void activeStateTypeTest() 
		{
			//managerCtrl.InitState (SceneManager);
			Assert.That (managerCtrl.GetActiveState(), Is.TypeOf(typeof(TitleState)));		
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