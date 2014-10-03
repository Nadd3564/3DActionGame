using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class AttackArea : MonoBehaviour, IAttackAreaController 
	{
	CharaStatus status;
	public AudioClip hitSeClip;
	AudioSource hitSeAudio;
	AttackInfo attackInfo;
	public AttackAreaController aAcontroller;

	public void OnEnable() {
		aAcontroller.SetAttackAreaController (this);
	}

	void Start () {
		FindCharaStatusComponent ();
		FindAttackInfoComponent ();
		//オーディオの初期化
		AddAudioSourceComponent ();
		HitSeAudioClip ();
		HitSeAudioLoop ();
	}

	//ダメージ値と攻撃者を設定して返す
	AttackInfo GetAttackInfo(){
			attackInfo.SetAttackPower (status.GetPower());

		//攻撃強化中
	if (status.GetPowerBoost ())
			attackInfo.SetAttackBoostPower (attackInfo.GetAttackPower());
			attackInfo.SetAttacker (transform.root);
			return attackInfo;
	}
	
	void OnTriggerEnter(Collider other){
		other.SendMessage ("Damage", GetAttackInfo());
		status.SetLastAttackTarget (other.transform.root.gameObject); 
		PlayAudio ();
	}
	
	//攻撃判定の有効、無効
	void OnAttack(){
		collider.enabled = true;
	}
	void OnAttackTermination(){
		collider.enabled = false;
	}

	public void FindCharaStatusComponent(){
		this.status = transform.root.GetComponent<CharaStatus>();
	}
		
	public void FindAttackInfoComponent(){
		this.attackInfo = GetComponentInChildren<AttackInfo>();
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

	public void PlayAudio(){
		this.hitSeAudio.Play ();
	}
 }
}