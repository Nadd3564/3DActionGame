using UnityEngine;
using System.Collections;

public class ApproachState : FSMState {

	public ApproachState(Transform[] wp)
	{
		waypoints = wp;
		stateID = FSMStateID.Approaching;

		//curRotSpeed = 1.0f;
		//curSpeed = 100.0f;

		FindNextPoint ();
		}

	public override void Reason(Transform player, Transform npc)
	{
		destPos = player.position;

		float dist = Vector3.Distance (npc.position, destPos);
		if(dist <= 200.0f)
		{
			Debug.Log("Switch to Attack state");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.ReachPlayer);
		}
		else if(dist >= 300.0f)
		{
			Debug.Log("Switch to Search state");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.LostPlayer);
		}
	}

	public override void Act(Transform player, Transform npc)
	{
		destPos = player.position;

		Quaternion targetRotation = Quaternion.LookRotation (destPos - npc.position);
		npc.rotation = Quaternion.Slerp (npc.rotation, targetRotation, Time.deltaTime /* curRotSpeed*/);

		npc.Translate (Vector3.forward * Time.deltaTime /* curSpeed*/);
	}
}
