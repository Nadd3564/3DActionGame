using System;
using UnityEngine;
using Cradle;

namespace Cradle
{
	[Serializable]
	public class AttackInfoController
	{
		public float attackPower;
		
		private IInfoController iInfoController;
		
		public AttackInfoController (){
		}

		public float getAttackPower(){
			return this.attackPower;
		}
		
		public float setAttackPower(float atk){
			return this.attackPower = atk ;
		}
		
		public float setAttackBoostPower(float atk){
			return this.attackPower += atk ;
		}

		public void SetInfoController(IInfoController iInfoController) {
			this.iInfoController = iInfoController;
		}
		
	}
}
