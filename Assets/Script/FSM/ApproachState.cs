using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class ApproachState : FSMState {

	public ApproachState(Transform[] wp)
	{
		waypoints = wp;
		stateID = FSMStateID.Approaching;

		curRotSpeed = 360.0f;
		curSpeed = 3.0f;

		FindNextPoint ();
		}

	public override void Reason(Transform player, Transform npc)
	{
		destPos = player.position;

		float dist = Vector3.Distance (npc.position, destPos);
		if(dist <= 2.0f)
		{
			Debug.Log("Switch to Attack state");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.ReachPlayer);
		}
		else if(dist >= 10.0f)
		{
			Debug.Log("Switch to Search state");
			npc.GetComponent<EnemyCtrl>().SetTransition(Transition.LostPlayer);
		}
	}

	public override void Act(Transform player, Transform npc)
	{
		npc.GetComponent<EnemyCtrl> ().WalkStart ();
		npc.GetComponent<EnemyCtrl> ().Walking ();

		destPos = player.position;

		Quaternion targetRotation = Quaternion.LookRotation (destPos - npc.position);
		npc.rotation = Quaternion.Slerp (npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

		obj = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject objs in obj){
		objs.SendMessage("SetDestination", destPos);
			}
		//npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	}
}
}