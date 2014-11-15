using System;
using Cradle.FM;

namespace Cradle.FM
{
	public interface IEnemyController
	{
		void SetTransition(Transition t);
		void Log();
		void SetBasePosition();
		void FindPlayer();
		void CreateHitEffect();
		void EffectPos();
		void InitItem();
		void JumpItem();
		void PlayDeathSE();
		void AttackStart();
		void DropItem();
		void AddFSMState(FSMState fsmstate);
		bool attackCount();
		float setElapsedTime(float f);
		void SendMsgStop();
		bool setAttacking();
		void GameClear();
		void DiedDestroy();
		void SetDied();
		string SetTag();
		void FindBossTag();
		void Arrived();
		void CanNotAttack();
		void DeadLog();
		void SetHP();
		float GetHP();
	}
}