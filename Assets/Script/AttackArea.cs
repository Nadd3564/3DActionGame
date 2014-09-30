using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class AttackArea : MonoBehaviour, IAttackAreaController 
	{
	CharaStatus status;
	public AudioClip hitSeClip;
	AudioSource hitSeAudio;
	public AttackAreaController aAcontroller;

		public void OnEnable() {
			aAcontroller.SetAttackAreaController (this);
		}

	void Start () {
		FindCharaStatusComponent ();

		//オーディオの初期化
		AddAudioSourceComponent ();
		HitSeAudioClip ();
		HitSeAudioLoop ();
	}

		public void FindCharaStatusComponent(){
			this.status = transform.root.GetComponent<CharaStatus>();
		}
	
		public void AddAudioSourceComponent(){
			this.hitSeAudio = gameObject.AddComponent<AudioSource>();
		}

		public void HitSeAudioClip(){
			this.hitSeAudio.clip = hitSeClip;
		}

		public void HitSeAudioLoop(){
			this.hitSeAudio.loop = false;	
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