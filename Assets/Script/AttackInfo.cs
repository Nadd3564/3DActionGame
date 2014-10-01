using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class AttackInfo : MonoBehaviour{
	
	private int attackPower;
	private Transform attacker;

	public int GetAttackPower(){
		return this.attackPower;
	}

	public int SetAttackPower(int atk){
		return this.attackPower = atk ;
	}

	public int SetAttackBoostPower(int atk){
		return this.attackPower += atk ;
	}

	public Transform SetAttacker(Transform atc){
		return this.attacker = atc;
	}

 }
}