using System;
using Cradle.FM;

namespace Cradle.FM
{
	public interface IEnemyController
	{
		void Log();
		void SetBasePosition();
		void FindPlayer();
		void CreateHitEffect();
		void EffectPos();
		void InitItem();
		void JumpItem();
		void SetTag();
		void PlayDeathSE();
		void AttackStart();
		void DropItem();
		void Died();
		void AddFSMState(FSMState fsmstate);
		bool attackCount();
		float setElapsedTime(float f);
		void SendMsgStop();
		bool setAttacking();
	}
}