using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class AttackState : FSMState {

	public AttackState(Transform[] wp)
	{
		waypoints = wp;
		stateID = FSMStateID.Attacking;
		//curRotSpeed = 1.0f;
		//curSpeed = 100.0f;
		FindNextPoint ();
	}

	public override void Reason(Transform player, Transform npc)
	{
		//プレイヤーとの距離を確認
		float dist = Vector3.Distance (npc.position, player.position);
		if(dist >= 0.0f && dist < 8.0f)
		{

			//ターゲット地点に回転
			Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime /* curRotSpeed*/);

			//前進
			//npc.GetComponent<AdvancedFSM> ().SetDestination (player.position);

			Debug.Log("Switch to Approach State");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.SawPlayer);
		}

		//距離が遠すぎる場合
		else if(dist >= 6.0f)
		{
			Debug.Log("Switch to Search State");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.LostPlayer);
		}
	}

	public override void Act(Transform player, Transform npc)
	{
		//ターゲット地点をプレーヤーポジションに設定
		//destPos = player.position;

		//前進
		//npc.GetComponent<AdvancedFSM> ().SendMessage ("SetDestination", destPos);

		//攻撃
		npc.GetComponent<EnemyCtrl> ().AttackStart ();
		npc.GetComponent<EnemyCtrl> ().Attacking ();

		/*//砲台は常にプレーヤーに向きます。
		Transform turret = npc.GetComponent<NPCTankController>().turret;
		Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
		turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
		
		//射撃
		npc.GetComponent<NPCTankController>().ShootBullet();*/
	}
}
}