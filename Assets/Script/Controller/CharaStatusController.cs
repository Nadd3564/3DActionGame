using System;
using UnityEngine;
using Cradle;

namespace Cradle
{
	[Serializable]
	public class CharaStatusController
	{
		/*public int HP = 100;
		public int MaxHP = 100;
		public int Power = 10;*/
		public float HP = 100.0f;
		public float MaxHP = 100.0f;
		public float Power = 10.0f;
		public bool attacking = false;
		public bool died = false;
		public bool powerBoost = false;
		public string charactername = "Player";
		private float powerBoostTime = 0.0f;
		
		private IEffectController effectController;
		
		public CharaStatusController (){
		}


		public float GetHP(){
			return this.HP;	
		}

		public float GetMaxHP(){
			return this.MaxHP;
		}

		public float GetPower(){
			return this.Power;	
		}

		public bool IsAttacking(){
			return this.attacking;	
		}

		public bool IsDied(){
			return this.died;	
		}

		public bool IsPowerBoost(){
			return this.powerBoost;	
		}

		public string GetCharacterName(){
			return this.charactername;
		}

		public float GetPowerBoostTime(){
			return this.powerBoostTime;	
		}

		public float SetHP(float hp){
			return this.HP = hp;	
		}

		public float HealHP(float hp){
			return this.HP += hp;	
		}

		public float DamageHP(float hp){
			return this.HP -= hp;	
		}
		
		public bool SetAttacking(bool flg){
			return this.attacking = flg;
		}
		
		public bool SetDied(bool flg){
			return this.died = flg;	
		}
		
		public void EnablePowerBoost() {
			this.powerBoost = true;
		}

		public void DisablePowerBoost() {
			this.powerBoost = false;
		}

		public void SetBoostTime (float boostTime) {
			this.powerBoostTime = boostTime;
		}
		
		public void CalcBoostTime() {
			this.powerBoostTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.powerBoostTime - Time.deltaTime, 0.0f);
		}
		
		public void CalcHP() {
			this.HP = Math.Min ( (int) (this.HP + this.MaxHP / 2), this.MaxHP);
		}
		
		public bool CanBoost() {
			if(powerBoostTime > 0.0f) 
				return true;
			return false;
		}
		
		public bool IsPlayer(string tag) {
			if (tag == charactername)
				return true;
				return false;					
		}

		public bool IsNPC(string tag){
			if (tag != charactername)
				return true;
			return false;		
		}

		public void PowerUp(){
			if (CanBoost ()) {
					EnablePowerBoost ();
					CalcBoostTime ();
			} else {
					effectController.StopEffect ();
			}
			}


		//アイテム取得
		public void GetItem(DropItemController.ItemKind itemKind){
			switch(itemKind){
			case DropItemController.ItemKind.Attack:
				SetBoostTime(10.0f);
				effectController.PlayEffect();
				break;
			case DropItemController.ItemKind.Heal:
				if(GetHP() > GetMaxHP())
					throw new ArgumentException("The Heal Must Be LessThan MaxHP.", default(Exception));

				CalcHP();
				break;
			}
		}


		public void SetEffectController(IEffectController effectController) {
			this.effectController = effectController;
		}

	}
}
