using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class AttackAreaController
	{
		private float calcTime = 0.0f;
		
		private IAttackAreaController aAttackController;
		
		public AttackAreaController (){
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
