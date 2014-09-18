using UnityEngine;
using System.Collections;

public class AttackAreaActivation : MonoBehaviour {
	Collider[] attackAreaColliders; //攻撃判定コライダーの配列

	public AudioClip attackSeClip;
	AudioSource attackSeAudio;

	void Start () {
		AttackArea[] attackAreas = GetComponentsInChildren<AttackArea> ();
		attackAreaColliders = new Collider[attackAreas.Length];

		for(int attackAreaCount = 0; attackAreaCount < attackAreas.Length; attackAreaCount++){
			attackAreaColliders[attackAreaCount] = attackAreas[attackAreaCount].collider;
			attackAreaColliders[attackAreaCount].enabled = false; 
		}
		//オーディオの初期化
		attackSeAudio = gameObject.AddComponent<AudioSource>();
		attackSeAudio.clip = attackSeClip;
		attackSeAudio.loop = false;
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
