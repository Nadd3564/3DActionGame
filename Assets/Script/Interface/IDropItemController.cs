using System;
namespace Cradle
{
	public interface IDropItemController
	{
		void PlaySE();
		void PopItem();
		void FindTerrainColliderComponent ();
		bool SetTrigger(bool flg);
		bool IsNotNull();
	}	
}