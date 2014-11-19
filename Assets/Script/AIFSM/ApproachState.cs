using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
	public class ApproachState : FSMState {

		public ApproachState(Transform[] wp)
		{
			SetWayPoints (wp);
			SetStateID (FSMStateID.Approaching);
			SetRotSpeed (360.0f);
			FindNextPoint ();
		}
		
		public override void Reason(Transform player, Transform npc)
		{
			SetDest (player);
			SetDist (Vector3.Distance (npc.position, destPos));
		
			if(LessThanCheckReach(dist, 2.0f))
			{
				Debug.Log("Switch to Attack state");
				npc.GetComponent<EnemyCtrl>().SetTransition(Transition.ReachPlayer);
			}
			else if(GreaterThanCheckReach(dist, 10.0f))
			{
				Debug.Log("Switch to Search state");
				npc.GetComponent<EnemyCtrl>().SetTransition(Transition.LostPlayer);
			}
		}
		
		public override void Act(Transform player, Transform npc)
		{
			//攻撃フラグを初期化
			npc.GetComponent<EnemyCtrl> ().StateStartCommon ();

			//ターゲット地点をプレーヤーポジションに設定
			SetDest (player);

			//ターゲット地点に回転
			if(IsTestScene())
			SetRot (npc, npc.position);

			//目的地をプレイヤーに変更
			npc.GetComponent<CharaMove> ().SendMessage ("SetDestination", destPos);
		}

	}
}