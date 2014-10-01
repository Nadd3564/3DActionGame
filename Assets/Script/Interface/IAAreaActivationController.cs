using System;
namespace Cradle
{
	public interface IAAreaActivationController
	{
		void FindAttackAreaComponent();
		void AttackAreaColliders();
		void AddAudioSourceComponent ();
		void AttackSeAudioClip ();
		void AttackSeAudioLoop ();
	}	
}