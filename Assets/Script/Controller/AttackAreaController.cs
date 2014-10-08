using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class AttackAreaController
	{
		
		private IAttackAreaController aAttackController;
		
		public AttackAreaController (){
		}
		
		public void SetAttackAreaController(IAttackAreaController aAreaController) {
			this.aAttackController = aAreaController;
		}

	}
}
