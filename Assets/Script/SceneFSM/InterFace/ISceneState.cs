using UnityEngine;

namespace Cradle.DesignPattern
{
	public interface ISceneState 
	{
		void StateUpdate();
		void Render();
	}
}