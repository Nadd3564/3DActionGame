using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class AttackInfoController
	{
		public int attackPower;
		private float calcTime = 0.0f;
		
		private IInfoController iInfoController;
		
		public AttackInfoController (){
		}

		public int getAttackPower(){
			return this.attackPower;
		}
		
		public int setAttackPower(int atk){
			return this.attackPower = atk ;
		}
		
		public int setAttackBoostPower(int atk){
			return this.attackPower += atk ;
		}

		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void SetInfoController(IInfoController iInfoController) {
			this.iInfoController = iInfoController;
		}
		
	}
}
