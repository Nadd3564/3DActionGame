using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
	public class AttackState : FSMState {

		public AttackState(Transform[] wp)
		{
			this.SetWayPoints (wp);
			this.SetStateID (FSMStateID.Attacking);
			this.SetRotSpeed (360.0f);
			this.FindNextPoint ();
		}


		public override void Reason(Transform player, Transform npc){
			//プレイヤーとの距離を確認
			this.SetDist (Vector3.Distance (npc.position, player.position));
			if(this.CheckDist(dist, 0.0f, 5.0f ))
			{
				//ターゲット地点に回転
				if(this.IsTestScene())
				SetRot (npc, npc.position);
				
				Debug.Log("Switch to Approach State");
				npc.GetComponent<EnemyCtrl>().SetTransition(Transition.SawPlayer);
			}
			
			//距離が遠すぎる場合
			else if(this.GreaterThanCheckReach(dist, 10.0f))
			{
				Debug.Log("Switch to Search State");
				npc.GetComponent<EnemyCtrl>().SetTransition(Transition.LostPlayer);
			}
		}
		
		public override void Act(Transform player, Transform npc){
			//ターゲット地点をプレーヤーポジションに設定
			this.SetDest (player);
			
			//攻撃
			npc.GetComponent<EnemyCtrl> ().AttackStart ();
		}

	}
}