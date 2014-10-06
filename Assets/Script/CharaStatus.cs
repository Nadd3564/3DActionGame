using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle {
	
	public class CharaStatus : MonoBehaviour, IEffectController {
		public GameObject lastAttackTarget = null;
		private ParticleSystem powerUpEffect;
		public CharaStatusController controller;
		
		public void OnEnable() {
			controller.SetEffectController (this);
		}
		
		//アイテム取得
		public void GetItem(DropItemController.ItemKind itemKind){
			switch(itemKind){
			case DropItemController.ItemKind.Attack:
				controller.SetBoostTime(10.0f);
				PlayEffect();
				break;
			case DropItemController.ItemKind.Heal:
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
			
			if(controller.IsNPC(gameObject.tag)){
				return;
			}
			
			controller.DisablePowerBoost ();
			if (controller.CanBoost()) {
				controller.EnablePowerBoost();
				controller.CalcBoostTime();
			} else {
				StopEffect();
			}
		}
		
		public void FindEffectComponent() {
			this.powerUpEffect = transform.Find ("PowerUpEffect").GetComponent<ParticleSystem> ();
		}
		
		public void PlayEffect() {
			this.powerUpEffect.Play ();
		}
		
		public void StopEffect() {
			this.powerUpEffect.Stop();
		}
		
		public int GetPower() {
			return controller.Power;
		}

		public int GetHP(){
			return controller.HP;	
		}

		public int SetHP(int hp){
			return controller.HP = hp;	
		}

		public int HealHP(int hp){
			return controller.HP += hp;	
		}

		public int DamageHP(int hp){
			return controller.HP -= hp;	
		}

		public bool GetPowerBoost() {
			return controller.powerBoost;
		}
		
		public bool isAttacking() {
			return controller.IsAttacking();
		}
		
		public bool SetAttacking(bool flg){
			return controller.attacking = flg;		
		}
		
		public bool IsDead() {
			return controller.died;
		}
		
		public bool SetDied(bool flg){
			return controller.died = flg;
		}

		public GameObject SetLastAttackTarget(GameObject obj){
			return this.lastAttackTarget = obj;
		}

	}
}