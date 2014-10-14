using System;
namespace Cradle
{
	public interface IAnimationController
	{
		void FindAnimatorComponent();
		void FindCharaStatusComponent();
		void SetPrePosition();
		void AnimatorSetSpdFloat();
		void AnimatorSetAtkBool();
		void AnimatorSetDownTrigger(); 
		void DeltaPosition();
		bool IsDead();
	}	
}