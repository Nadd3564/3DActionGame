using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class CharaAnimationController
	{
		public bool isDown = false;
		public bool attacked = false;
		private CharaStatusController statusController;
		private IAnimationController animationController;
		
		public CharaAnimationController (){
		}

		public CharaStatusController CharaStatusCtrl(){
		return statusController = new CharaStatusController ();
		}

		public bool IsAttacked(){
			return this.attacked;
		}

		public bool SetAttacked(bool flg){
			return this.attacked = flg;
		}

		public bool IsDown(){
			return this.isDown; 		
		}

		public bool SetDown(bool flg){
			return this.isDown = flg; 	
		}

		public bool StopAttack(){
				if (IsAttacked () && !isAttacking()) {
						SetAttacked (false);
				return false;
					}
			return true;
		}

		public bool isAttacking(){
			CharaStatusCtrl ();
			return statusController.IsAttacking ();		
		}

		public bool SetAttacking(bool flg){
			CharaStatusCtrl ();
			return statusController.SetAttacking (flg);		
		}

		public void SetAnimationController(IAnimationController animationController) {
			this.animationController = animationController;
		}
		
	}
}