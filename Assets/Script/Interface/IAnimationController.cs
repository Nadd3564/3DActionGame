using System;
namespace Cradle
{
	public interface IAnimationController
	{
		void FindAnimatorComponent();
		void FindCharaStatusComponent();
		void SetPrePosition();
		void AnimatorSetFloat();
		void AnimatorSetBool();
		void AnimatorSetTrigger(); 
		void DeltaPosition();
		bool IsDied();
	}	
}