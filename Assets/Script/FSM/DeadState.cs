using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class DeadState : FSMState {

	public DeadState()
	{
		stateID = FSMStateID.Dead;
	}

	public override void Reason(Transform player, Transform npc)
	{

	}

	public override void Act(Transform player, Transform npc)
	{

	}
}
}