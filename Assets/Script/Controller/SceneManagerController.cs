using UnityEngine;
using System;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern
{
	[Serializable]
	public class SceneManagerController
	{
		private ISceneState activeState;

		
		private IManagerController manager;
		
		public SceneManagerController (){
			
		}

		public ISceneState GetActiveState(){
			return this.activeState;		
		}

		public void InitState(SceneManager manager){
			this.activeState = new TitleState(manager);
		}

		public void SwitchState(ISceneState newState) 
		{
			this.activeState = newState;
		}

		
		public void SetManagerController(IManagerController manager) {
			this.manager = manager;
		}
		
	}
}