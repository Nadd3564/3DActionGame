using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
	public class ApproachState : FSMState {

		public ApproachState(Transform[] wp)
		{
			this.SetWayPoints (wp);
			this.SetStateID (FSMStateID.Approaching);
			this.SetRotSpeed (360.0f);
			this.FindNextPoint ();
		}
		
		public override void Reason(Transform player, Transform npc)
		{
			this.SetDest (player);
			this.SetDist (Vector3.Distance (npc.position, destPos));
		
			if(this.LessThanCheckReach(dist, 2.0f))
			{
				Debug.Log("Switch to Attack state");
				npc.GetComponent<EnemyCtrl>().SetTransition(Transition.ReachPlayer);
			}
			else if(this.GreaterThanCheckReach(dist, 10.0f))
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
			this.SetDest (player);

			//ターゲット地点に回転
			if(IsTestScene())
			this.SetRot (npc, npc.position);

			//目的地をプレイヤーに変更
			npc.GetComponent<CharaMove> ().SendMessage ("SetDestination", destPos);
		}

	}
}