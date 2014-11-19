using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
	public class AttackInfo : MonoBehaviour, IInfoController{
		private Transform attacker;
		public AttackInfoController aIController;
			
		public void OnEnable() {
			aIController.SetInfoController (this);
		}

		public float GetAttackPower(){
			return aIController.getAttackPower();
		}

		public float SetAttackPower(float atk){
				return aIController.setAttackPower (atk);
		}

		public float SetAttackBoostPower(float atk){
				return aIController.setAttackBoostPower (atk);
		}

		public Transform SetAttacker(Transform atk){
			return this.attacker = atk;
		}

	 }
}