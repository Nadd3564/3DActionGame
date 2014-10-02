using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class DropItemController
	{
		
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

		public void SetDropItemController(IDropItemController dropItemController) {
			this.dropItemController = dropItemController;
		}
		
	}
}