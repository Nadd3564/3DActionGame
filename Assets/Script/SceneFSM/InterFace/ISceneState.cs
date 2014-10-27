using UnityEngine;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern
{
	public interface ISceneState 
	{
		void StateUpdate();
		void Render();
	}
}