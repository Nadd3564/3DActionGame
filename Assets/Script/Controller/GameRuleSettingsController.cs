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
		public bool gameOver = false;
		public bool gameClear = false;
		public float sceneChangeTime = 10.0f;
		private float calcTime = 0.0f;
		private IRuleController ruleController;
		
		
		public GameRuleSettingsController (){
			
		}
		
		public float GetGameSpeed(){
			return this.gameSpeed;		
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

		public bool GameFlgs(){
			if (IsGameOver () || IsGameClear ())
					return true;
				return false;
		}

		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}

		public bool TimeRemaining(){
			if (GetSceneChangeTime () <= 0.0f)	
					return true;
				return false;
		}

		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void SetRuleController(IRuleController ruleController) {
			this.ruleController = ruleController;
		}
		
	}
}