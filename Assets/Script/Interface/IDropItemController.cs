using System;
namespace Cradle
{
	public interface IDropItemController
	{
		void PlaySE();
		void PopItem();
		void FindTerrainColliderComponent ();
		void SetTrigger(bool flg);
		bool IsNotNull();
	}	
}