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
			AnimatorSetFloat ();
			cAController.StopAttack ();
			AnimatorSetBool ();
			
			if(!cAController.IsDown() && IsDied()){
				cAController.SetDown(true);
				AnimatorSetTrigger();
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
		
		public bool IsDied(){
			return this.status.IsDead ();		
		}
		
		public void DeltaPosition(){
			this.delta_position = transform.position - prePosition;
		}
		
		public void AnimatorSetFloat(){
			this.animator.SetFloat ("Speed", delta_position.magnitude / Time.deltaTime);
		}
		
		public void AnimatorSetBool(){
			this.animator.SetBool ("Attacking", (!isAttacked() && status.isAttacking()));
		}
		
		public void AnimatorSetTrigger(){
			this.animator.SetTrigger("Down");
		}
	}
	
}