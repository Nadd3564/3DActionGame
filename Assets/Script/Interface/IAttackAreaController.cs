using System;
namespace Cradle
{
	public interface IAttackAreaController
	{
		void FindCharaStatusComponent();
		void AddAudioSourceComponent();
		void HitSeAudioClip();
		void HitSeAudioLoop();
	}	
}