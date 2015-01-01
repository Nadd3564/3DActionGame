using UnityEngine;
using Cradle;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern {
	public class PlayState : ISceneState { 
		private SceneManager manager;


		public PlayState() {}

		public PlayState(SceneManager stateManager) { 
			//初期化
			manager = stateManager;
		}


		public void StateUpdate() {}
		
		public void Render() {}


		public SceneManager GetManager(){
			return this.manager;
		}
	}
}