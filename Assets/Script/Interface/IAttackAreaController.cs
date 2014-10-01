using System;
namespace Cradle
{
	public interface IAttackAreaController
	{
		void FindCharaStatusComponent();
		void FindAttackInfoComponent();
		void AddAudioSourceComponent();
		void HitSeAudioClip();
		void HitSeAudioLoop();
		void PlayAudio();
	}	
}