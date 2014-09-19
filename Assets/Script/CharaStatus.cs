using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle {

	public class CharaStatus : MonoBehaviour, IEffectController {

		public GameObject lastAttackTarget = null;
		public ParticleSystem powerUpEffect;
		public CharaStatusController controller;

		//アイテム取得
		public void GetItem(DropItem.ItemKind itemKind){
			switch(itemKind){
			case DropItem.ItemKind.Attack:
				controller.SetBoostTime(10.0f);
				PlayEffect();
				break;
			case DropItem.ItemKind.Heal:
				controller.CalcHP();
				break;
			}
		}

		void Start(){
			if(controller.IsPlayer(gameObject.tag)){
				FindEffectComponent();
			}
		}

		void Update(){

			if(controller.IsPlayer(gameObject.tag)){
				return;
			}

			controller.DisablePowerBoost ();
			if (controller.CanBoost()) {
				controller.EnablePowerBoost();
				controller.CalcBoostTime();
					} else {
				//StopEffect (); ここをアクティブにするとエラーが出ます。
 			}
		}

		public void FindEffectComponent() {
			this.powerUpEffect = transform.Find ("PowerUpEffect").GetComponent<ParticleSystem> ();
		}

		 public void PlayEffect() {
			this.powerUpEffect.Play ();
		}

		public void StopEffect() {
			this.powerUpEffect.Stop ();
		}

		public int GetPower() {
			return controller.Power;
		}
		public bool GetPowerBoost() {
			return controller.powerBoost;
		}

		public bool IsAttacking() {
			return controller.attacking;
		}

		public bool IsDead() {
			return controller.died;
		}
		
	}
}