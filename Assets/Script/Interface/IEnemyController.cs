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
	}
}