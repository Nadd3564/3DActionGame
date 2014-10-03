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
		private float calcTime = 0.0f;
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

		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public void SetEnemyController(IEnemyController enemyController) {
			this.enemyController = enemyController;
		}
		
	}
}