using UnityEngine;
using System;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern
{
	[Serializable]
	public class SceneManagerController
	{
		// 現在のゲームの状態を保持
		private ISceneState activeState;

		private IManagerController manager;


		public SceneManagerController (){
			
		}

		public ISceneState GetActiveState(){
			return this.activeState;		
		}

		//状態の初期化
		public void InitState(SceneManager manager){
			this.activeState = new TitleState(manager);
		}

		public SceneManager GetInstance(){
			return SceneManager.instance;		
		}

		public void SetInstance(SceneManager manager){
			SceneManager.instance = manager;
		}

		//状態の更新
		public void ActiveState(){
			if(IsNotNullState())
				activeState.StateUpdate();
		}

		public bool IsNotNullState(){
			if(activeState != null)
				return true;
			return false;
		}

		//次の状態へ遷移
		public void SwitchState(ISceneState newState) 
		{
			this.activeState = newState;
		}

		public bool IsNullInstance(){
			if(SceneManager.instance == null)
				return true;
			return false;
		}

		public bool IsNotLogInScene(){
			if(Application.loadedLevelName != "LogInScene")		
				return true;
			return false;
		}

		public bool IsPlayScene(){
			if(Application.loadedLevelName == "PlayScene")
				return true;
			return false;
		}


		public void SetManagerController(IManagerController manager) {
			this.manager = manager;
		}
		
	}
}