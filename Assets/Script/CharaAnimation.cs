using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
	public class CharaAnimation : MonoBehaviour, IAnimationController {
		public CharaAnimationController cAController;
		Animator animator;
		CharaStatus status;
		Vector3 prePosition;
		Vector3 delta_position;
		
		
		public void OnEnable() {
			cAController.SetAnimationController(this);
		}
		
		void Start () {
			FindAnimatorComponent ();
			FindCharaStatusComponent ();
			SetPrePosition ();
		}
		
		void Update () {
			DeltaPosition ();
			AnimatorSetSpdFloat ();
			cAController.StopAttack ();
			AnimatorSetAtkBool ();
			
			if(!cAController.IsDown() && IsDead()){
				cAController.SetDown(true);
				AnimatorSetDownTrigger();
			}
			
			SetPrePosition ();
		}
		
		public void FindAnimatorComponent() {
			this.animator = GetComponent<Animator> ();
		}
		
		public void FindCharaStatusComponent(){
			this.status = GetComponent<CharaStatus>();
		}
		
		public bool isAttacked(){
			return cAController.IsAttacked ();
		}
		
		public bool isSetAttacked(bool flg){
			return cAController.SetAttacked(flg);
		}
		
		void EndAttack(){
			cAController.SetAttacked (true);
		}
		
		void StartAttackHit(){
			Debug.Log ("StartAttackHit");
		}
		
		void EndAttackHit(){
			Debug.Log ("EndAttackHit");
		}
		
		public void SetPrePosition(){
			prePosition = transform.position;
		}
		
		public bool IsDead(){
			return status.IsDead ();		
		}
		
		public void DeltaPosition(){
			this.delta_position = transform.position - prePosition;
		}
		
		public void AnimatorSetSpdFloat(){
			this.animator.SetFloat ("Speed", delta_position.magnitude / Time.deltaTime);
		}
		
		public void AnimatorSetAtkBool(){
			this.animator.SetBool ("Attacking", (!isAttacked() && status.isAttacking()));
		}
		
		public void AnimatorSetDownTrigger(){
			this.animator.SetTrigger("Down");
		}
	}
	
}