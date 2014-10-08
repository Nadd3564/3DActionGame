using System;
using UnityEngine;
using Cradle.FM;

namespace Cradle.FM
{
	[Serializable]
	public class EnemyCtrlController
	{
		public float waitBaseTime = 2.0f; //待機時間
		public float waitTime; //残り待機時間
		public float walkRange = 5.0f; //移動範囲
		public float DestroyTime = 5.0f;	//死体消滅時間
	
		private IEnemyController enemyController;
		
		
		public EnemyCtrlController(){
			
		}

		public float GetWaitTime(){
			return this.waitTime;	
		}

		public float SetWaitTime(float f){
			return this.waitTime = f;	
		}

		public float SetDownWaitTime(float f){
			return this.waitTime -= f;	
		}

		public float GetWaitBaseTime(){
			return this.waitBaseTime;	
		}

		public float GetDestroyTime(){
			return this.DestroyTime;	
		}


		public bool IsEnemyHit(string s){
		if (s == "EnemyHit")
				return true;
			return false;
		}

		public bool IsTagCheck(string s, string t){
			if (s == t)
				return true;
			return false;
		}

		public bool LessThanHP(int i){
		if (i <= 0)
				return true;
			return false;
		}

		public bool ThanItemPrefab(int itemLength){
			if (itemLength == 0)
				return true;
			return false;
		}

		public bool ThanTime(){
			if (GetWaitTime () > 0.0f)
				return true;
			return false;
		}

		public bool LessThanTime(){
			if (GetWaitTime() <= 0.0f)
				return true;
			return false;
		}

		public void SetEnemyController(IEnemyController enemyController) {
			this.enemyController = enemyController;
		}
		
	}
}