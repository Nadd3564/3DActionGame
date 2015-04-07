using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class DropItemController
	{

		public enum ItemKind
		{
			Attack,
			Heal,
		};

		public ItemKind kind;
		//For Tests
		public bool GroundedItem = false;
		public bool PopItem = false;

		private IDropItemController iDropItemController;


		public DropItemController (){
		}

		public ItemKind GetAttackKind(){
			return ItemKind.Attack;	
		}

		public ItemKind GetHealKind(){
			return ItemKind.Heal;	
		}

		public ItemKind itemKind(){
			return ItemKind.Heal; 
				return ItemKind.Attack;	
		}

		//For Tests
		public bool IsGroundedItem(){
			return this.GroundedItem;	
		}

		public bool IsPopItem(){
			return this.PopItem;	
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

		public bool CheckTerrain(string tag, bool f){
			if (!IsTerrain (tag)) {
				return false;
			}

			iDropItemController.SetTrigger (f);
			return true;
			}


		//For Tests
		public bool CheckInsitantiateItem(){
			if(IsNotNullWithSceneName() && !IsPopItem())
				return true;
			return false;
		}

		//For Tests
		public bool IsNotNullWithSceneName(){
			if(IsTestScene() && iDropItemController.IsNotNull())
				return true;
			return false;
		}

		//For Tests
		public bool IsTestScene(){
			if(Application.loadedLevelName == "TestScene")
				return true;
			return false;
		}

		public void SetDropItemController(IDropItemController iDropItemController) {
			this.iDropItemController = iDropItemController;
		}
		
	}
}