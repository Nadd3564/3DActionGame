using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class GameRuleSettingsController
	{
		//残り時間
		public float gameSpeed = 1.0f;
		public float timeRemaining = 5.0f + 60.0f;
		public float sceneChangeTime = 10.0f;
		public bool gameOver = false;
		public bool gameClear = false;

		private IRuleController ruleController;		
		
		public GameRuleSettingsController (){
			
		}
		
		public float GetGameSpeed(){
			return this.gameSpeed;		
		}

		public float GetTimeRemaining(){
			return this.timeRemaining;	
		}

		public float GetSceneChangeTime(){
			return this.sceneChangeTime;		
		}

		public float SetCountSceneChangeTime(float f){
			return this.sceneChangeTime -= f;		
		}

		public bool IsGameOver(){
			return this.gameOver;		
		}

		public bool SetGameOver(bool flg){
			return this.gameOver = flg;		
		}

		public bool IsGameClear(){
			return this.gameClear;		
		}

		public bool SetGameClear(bool flg){
			return this.gameClear = flg;		
		}

		public virtual bool GameFlgs(){
			if (IsGameOver () || IsGameClear ())
					return true;
				return false;
		}

		public bool TimeRemaining(){
			if (GetSceneChangeTime () <= 0.0f)	
					return true;
				return false;
		}

		public void InitializeGameSpeed(){
			Time.timeScale = GetGameSpeed();
		}

		public void SwitchScene(){
			Application.LoadLevel("TitleScene");
		}

		public bool ReturnTitle(){
			if (!GameFlgs ())
				return false;

			if(GameFlgs()){
				//シーン切り替えまでのカウント開始
				SetCountSceneChangeTime(Time.deltaTime);
				if(TimeRemaining()){
					SwitchScene();
				}
			}
			return true;
		}
		
		public void SetRuleController(IRuleController ruleController) {
			this.ruleController = ruleController;
		}
		
	}
}