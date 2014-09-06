using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {
	CharaStatus status;

	// Use this for initialization
	void Start () {
		status = transform.root.GetComponent<CharaStatus>();
	}

	//攻撃力や攻撃者の情報を入れるクラス
	public class AttackInfo {
		public int attackPower;
		public Transform attacker;
	}

	//ダメージ値と攻撃者を設定して返す
	AttackInfo GetAttackInfo(){
		AttackInfo attackInfo = new AttackInfo ();
		attackInfo.attackPower = status.Power;
		attackInfo.attacker = transform.root;
		return attackInfo;
	}


	void OnTriggerEnter(Collider other){
		other.SendMessage ("Damage", GetAttackInfo());
		status.lastAttackTarget = other.transform.root.gameObject;
	}

	//攻撃判定の有効、無効
	void OnAttack(){
		collider.enabled = true;
	}
	void OnAttackTermination(){
				collider.enabled = false;
		}
}
