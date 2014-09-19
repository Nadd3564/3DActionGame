using UnityEngine;
using Cradle;

namespace Cradle{
public class CharaAnimation : MonoBehaviour {
	Animator animator;
	CharaStatus status;
	Vector3 prePosition;
	bool isDown = false;
	bool attacked = false;

	public bool isAttacked(){
		return attacked;
	}

	void StartAttackHit(){
		Debug.Log ("StartAttackHit");
	}

	void EndAttackHit(){
		Debug.Log ("EndAttackHit");
	}

	void EndAttack(){
		attacked = true;
	}

	void Start () {
		animator = GetComponent<Animator>();
		status = GetComponent<CharaStatus>();
		prePosition = transform.position;
	}

	void Update () {
		Vector3 delta_position = transform.position - prePosition;
		animator.SetFloat ("Speed", delta_position.magnitude / Time.deltaTime);

		if(attacked && !status.IsAttacking()){
			attacked = false;
		}

		animator.SetBool ("Attacking", (!attacked && status.IsAttacking()));

		if(!isDown && status.IsDead()){
			isDown = true;
			animator.SetTrigger("Down");
		}

		prePosition = transform.position;
	}
}
}