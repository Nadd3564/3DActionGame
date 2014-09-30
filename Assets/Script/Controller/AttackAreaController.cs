using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class AttackAreaController
	{
		private int attackPower;
		private float calcTime = 0.0f;
		
		private IAttackAreaController aAttackController;
		
		public AttackAreaController (){
		}

		public int GetAttackPower(){
			return this.attackPower;		
		}

		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void SetAttackAreaController(IAttackAreaController aAreaController) {
			this.aAttackController = aAreaController;
		}

	}
}
