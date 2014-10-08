using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class AttackInfoController
	{
		public int attackPower;
		
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

		public void SetInfoController(IInfoController iInfoController) {
			this.iInfoController = iInfoController;
		}
		
	}
}
