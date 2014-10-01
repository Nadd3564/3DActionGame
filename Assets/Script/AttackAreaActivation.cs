using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class AttackAreaActivation : MonoBehaviour, IAAreaActivationController
{
	Collider[] attackAreaColliders; //攻撃判定コライダーの配列
	AttackArea[] attackAreas;
	public AudioClip attackSeClip;
	AudioSource attackSeAudio;
	public AAreaActivationController AAAcontroller;

		
	public void OnEnable() {
		//AAAcontroller.SetEffectController (this);
	}

	void Start () {
		//AttackArea[] attackAreas = GetComponentsInChildren<AttackArea> ();
		FindAttackAreaComponent ();
		//attackAreaColliders = new Collider[attackAreas.Length];
		AttackAreaColliders ();
		for(int attackAreaCount = 0; attackAreaCount < attackAreas.Length; attackAreaCount++){
			attackAreaColliders[attackAreaCount] = attackAreas[attackAreaCount].collider;
			attackAreaColliders[attackAreaCount].enabled = false; 
		}
		//オーディオの初期化
			AddAudioSourceComponent ();
			AttackSeAudioClip ();
			AttackSeAudioLoop ();
	}

		public void FindAttackAreaComponent(){
			this.attackAreas = GetComponentsInChildren<AttackArea> ();
		}

		void AttackAreaColliders(){
			this.attackAreaColliders = new Collider[attackAreas.Length];
		} 

		public void AddAudioSourceComponent(){
			this.attackSeAudio = gameObject.AddComponent<AudioSource>();
		}
		
		public void AttackSeAudioClip(){
			this.attackSeAudio.clip = attackSeClip;
		}
		
		public void AttackSeAudioLoop(){
			this.attackSeAudio.loop = false;	
		}
	//AnimatorイベントのStartAttackHitを受け取ってコライダを有効に
	void StartAttackHit(){
		foreach (Collider attackAreaCollider in attackAreaColliders)
						attackAreaCollider.enabled = true;

		//SE再生
		attackSeAudio.Play ();
	}
	//AnimatorイベントのEndAttackHitを受け取ってコライダを無効に
	void EndAttackHit(){
		foreach (Collider attackAreaCollider in attackAreaColliders)
						attackAreaCollider.enabled = false;
	}
}
}