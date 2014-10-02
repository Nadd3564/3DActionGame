using System;

namespace Cradle
{
	public interface IRuleController
	{
		void FindAudioComponent();
		void DisableLoopSE();
		void ClipSE();
		void PlaySE();
		void InitializeGameSpeed();
		void SwitchScene();
	}	
}