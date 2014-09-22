using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class SearchState : FSMState {

	public SearchState(Transform[] wp)
	{
		waypoints = wp;
		stateID = FSMStateID.Searching;
		curRotSpeed = 360.0f;
		curSpeed = 2.0f;
	}

	public override void Reason(Transform player, Transform npc)
	{
		if(Vector3.Distance(npc.position, player.position) <= 7.0f)
		{
			Debug.Log("Switch to Approach State");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.SawPlayer);
		}
	}

	public override void Act(Transform player, Transform npc)
	{
			//ターゲットを見失ったらパトロール
		npc.GetComponent<EnemyCtrl>().Walking(destPos);

			//ターゲット地点が遠すぎる場合、パトロール地点を再度設定
			if(Vector3.Distance(npc.position, destPos) >= 50.0f){
				Debug.Log("Reached to the destination point/ncalculating the next point");
				FindNextPoint();
			}

		//ターゲット地点に到着した場合に、パトロール地点を再度設定
		if(Vector3.Distance(npc.position, destPos) <= 0.6f)
		{
			Debug.Log("Reached to the destination point/ncalculating the next point");
			FindNextPoint();
		}
		


		
	}
}
}