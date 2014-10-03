using System;
using UnityEngine;
using Cradle;

namespace Cradle.FM
{
	[Serializable]
	public class FSMController
	{
		//攻撃の間隔
		private float attackRate;
		private float elapsedTime;
		private float calcTime = 0.0f;
		private IFSMController fsmController;
		
		
		public FSMController(){
			
		}

		public float GetAttackRate(){
			return this.attackRate;
		}

		public float SetAttackRate(float f){
			return this.attackRate = f;
		} 

		public float GetElapsedTime(){
			return this.elapsedTime;
		}

		public float SetElapsedTime(float f){
			return this.elapsedTime = f;	
		}

		public float SetUpElapsedTime(float f){
			return this.elapsedTime += f;	
		}

		public bool AttackCount(){
			if (GetElapsedTime () >= GetAttackRate ())	
				return true;
			return false;
		}

		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public void SetFSMController(IFSMController fsmController) {
			this.fsmController = fsmController;
		}
		
	}
}