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

	public int GetAttackPower(){
		return aIController.getAttackPower();
	}

	public int SetAttackPower(int atk){
			return aIController.setAttackPower (atk);
	}

	public int SetAttackBoostPower(int atk){
			return aIController.setAttackBoostPower (atk);
	}

	public Transform SetAttacker(Transform atk){
		return this.attacker = atk;
	}

 }
}