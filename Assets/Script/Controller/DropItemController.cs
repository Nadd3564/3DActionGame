using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class DropItemController
	{
		private float calcTime = 0.0f;
		private IDropItemController dropItemController;
		
		public DropItemController (){
		}

		public bool IsPlayer(string tag) {
			if (tag == "Player")
					return true;
			return false;
		}

		public bool IsTerrain(string tag) {
			if (tag == "Terrain")
			return true;
			return false;	
		}

		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}

		public void SetDropItemController(IDropItemController dropItemController) {
			this.dropItemController = dropItemController;
		}
		
	}
}