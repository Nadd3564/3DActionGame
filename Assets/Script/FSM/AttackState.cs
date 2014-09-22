using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class AttackState : FSMState {


	public AttackState(Transform[] wp)
	{
		waypoints = wp;
		stateID = FSMStateID.Attacking;
		RotSpeed = 360.0f;
		FindNextPoint ();
	}

	public override void Reason(Transform player, Transform npc)
	{
		//プレイヤーとの距離を確認
		float dist = Vector3.Distance (npc.position, player.position);
		if(dist >= 0.0f && dist < 5.0f)
		{
			//ターゲット地点に回転
			Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
			npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * RotSpeed);

			//前進
			arr = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject objs in arr) 
			{
				objs.SendMessage ("SetDestination", destPos);
			}

			Debug.Log("Switch to Approach State");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.SawPlayer);
		}

		//距離が遠すぎる場合
		else if(dist >= 10.0f)
		{
			Debug.Log("Switch to Search State");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.LostPlayer);
		}
	}

	public override void Act(Transform player, Transform npc)
	{
		//ターゲット地点をプレーヤーポジションに設定
		destPos = player.position;
		
		//攻撃
		npc.GetComponent<EnemyCtrl> ().AttackStart ();
		//サーチ状態へ
		npc.GetComponent<EnemyCtrl> ().SetTransition (Transition.LostPlayer);
	}
}
}