using UnityEngine;
using System.Collections;

public class EnemyCtrl : AdvancedFSM {


	protected override void StartUp ()
	{
		GameObject objPlayer = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = objPlayer.transform;

		if (!playerTransform)
						print ("プレーヤーが存在しません。タグ'Player'を追加してください。");

		//FSMを構築
		BuildFSM ();
	}

	protected override void StateUpdate ()
	{

	}

	protected override void StateFixedUpdate()
	{
		CurrentState.Reason (playerTransform, transform);
		CurrentState.Act (playerTransform, transform);
	}

	public void SetTransition(Transition t)
	{
		RunTransition (t);
	}

	private void BuildFSM()
	{
		//ポイントのリスト
		pointList = GameObject.FindGameObjectsWithTag ("WandarPoint");

		Transform[] waypoints = new Transform[pointList.Length];
		int i = 0;
		foreach(GameObject obj in pointList)
		{
			waypoints[i] = obj.transform;
			i++;
		}

		SearchState search = new SearchState (waypoints);
		search.AddTransition (Transition.SawPlayer, FSMStateID.Approaching);
		search.AddTransition (Transition.NoHealth, FSMStateID.Dead);

		ApproachState approach = new ApproachState (waypoints);
		approach.AddTransition (Transition.LostPlayer, FSMStateID.Searching);
		approach.AddTransition (Transition.ReachPlayer, FSMStateID.Attacking);
		approach.AddTransition (Transition.NoHealth, FSMStateID.Dead);

		AttackState attack = new AttackState (waypoints);
		attack.AddTransition (Transition.LostPlayer, FSMStateID.Searching);
		attack.AddTransition (Transition.SawPlayer, FSMStateID.Approaching);
		attack.AddTransition (Transition.NoHealth, FSMStateID.Dead);

		DeadState dead = new DeadState ();
		dead.AddTransition (Transition.NoHealth, FSMStateID.Dead);

		AddFSMState (search);
		AddFSMState (approach);
		AddFSMState (attack);
		AddFSMState (dead);
	}
}


























