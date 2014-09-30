using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class AttackArea : MonoBehaviour {
	CharaStatus status;
	
	public AudioClip hitSeClip;
	AudioSource hitSeAudio;

	void Start () {
		status = transform.root.GetComponent<CharaStatus>();

		//オーディオの初期化
		hitSeAudio = gameObject.AddComponent<AudioSource>();
		hitSeAudio.clip = hitSeClip;
		hitSeAudio.loop = false;
	}
	
	//攻撃力や攻撃者の情報を入れるクラス
	public class AttackInfo {
		public int attackPower;
		public Transform attacker;
	}
	
	//ダメージ値と攻撃者を設定して返す
	AttackInfo GetAttackInfo(){
		AttackInfo attackInfo = new AttackInfo ();
		attackInfo.attackPower = status.GetPower();
		//攻撃強化中
		if (status.GetPowerBoost())
						attackInfo.attackPower += attackInfo.attackPower;

		attackInfo.attacker = transform.root;
		return attackInfo;
	}
	
	
	void OnTriggerEnter(Collider other){
		other.SendMessage ("Damage", GetAttackInfo());
		status.lastAttackTarget = other.transform.root.gameObject;
		hitSeAudio.Play ();
	}
	
	//攻撃判定の有効、無効
	void OnAttack(){
		collider.enabled = true;
	}
	void OnAttackTermination(){
		collider.enabled = false;
	}
}
}