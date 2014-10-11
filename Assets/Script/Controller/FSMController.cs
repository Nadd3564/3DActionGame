using System;
using UnityEngine;
using Cradle;

namespace Cradle.FM
{
	[Serializable]
	public class FSMController
	{

		private Transform playerTransform;

		//攻撃の間隔
		private float attackRate;
		private float elapsedTime;
		private IFSMController fsmController;

		public FSMController(){

		}

		public Transform GetPlayerTrans(){
			return this.playerTransform;	
		}

		public void SetPlayerTransform(Transform trans){
			this.playerTransform = trans;	
		}

		/*public virtual Vector3 GetDestPos(){
			return this.destPos;	
		}

		public virtual String GetDest(){
			string des = this.destPos.ToString ();
			Debug.Log ("GetDest : " + des);
			return des;
		}*/

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

		public void SetFSMController(IFSMController fsmController) {
			this.fsmController = fsmController;
		}
		
	}
}