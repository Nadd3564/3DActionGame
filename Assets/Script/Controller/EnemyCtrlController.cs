using System;
using UnityEngine;
using Cradle.FM;

namespace Cradle.FM
{
	[Serializable]
	public class EnemyCtrlController
	{
		private GameObject[] pointList;
		public float waitBaseTime = 2.0f; //待機時間
		public float waitTime; //残り待機時間
		public float walkRange = 5.0f; //移動範囲
		public float DestroyTime = 5.0f;	//死体消滅時間
		private Vector3 destinationPosition;
	
		private IEnemyController enemyController;
		
		
		public EnemyCtrlController(){
	
		}

		public void BuildFSM()
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

			enemyController.AddFSMState (Search(waypoints));
			enemyController.AddFSMState (Approach(waypoints));
			enemyController.AddFSMState (Attack(waypoints));
			enemyController.AddFSMState (Dead(waypoints));
		}

		public SearchState Search(Transform[] waypoints){
			SearchState search = new SearchState (waypoints);
			search.AddTransition (Transition.SawPlayer, FSMStateID.Approaching);
			search.AddTransition (Transition.NoHealth, FSMStateID.Dead);
			return search;
		}



		public ApproachState Approach(Transform[] waypoints){
			ApproachState approach = new ApproachState (waypoints);
			approach.AddTransition (Transition.LostPlayer, FSMStateID.Searching);
			approach.AddTransition (Transition.ReachPlayer, FSMStateID.Attacking);
			approach.AddTransition (Transition.NoHealth, FSMStateID.Dead);
			return approach;
		}

		public AttackState Attack(Transform[] waypoints){
			AttackState attack = new AttackState (waypoints);
			attack.AddTransition (Transition.LostPlayer, FSMStateID.Searching);
			attack.AddTransition (Transition.SawPlayer, FSMStateID.Approaching);
			attack.AddTransition (Transition.NoHealth, FSMStateID.Dead);
			return attack;
		}

		public DeadState Dead(Transform[] waypoints){
			DeadState dead = new DeadState ();
			dead.AddTransition (Transition.NoHealth, FSMStateID.Dead);
			return dead;
		}

		//ElapsedTimeがattackRateを超えたら攻撃
		public bool attackStart()
		{
			if(!enemyController.attackCount())
			{
				return false;
			}

			if(enemyController.attackCount())
			{
				if(!enemyController.setAttacking())
					throw new ArgumentException("The setAttacking Must be True.");
				
				enemyController.setAttacking();
				enemyController.setElapsedTime(0.0f);
			}
			//移動を止める
			enemyController.SendMsgStop ();
			return true;
			return false;
		}


		public float GetWaitTime(){
			return this.waitTime;	
		}

		public float SetWaitTime(float f){
			return this.waitTime = f;	
		}

		public float SetDownWaitTime(float f){
			return this.waitTime -= f;	
		}

		public float GetWaitBaseTime(){
			return this.waitBaseTime;	
		}

		public float GetDestroyTime(){
			return this.DestroyTime;	
		}

		public float GetWalkRange(){
			return this.walkRange;	
		}

		//目的地の取得
		public Vector3 GetDestination(){
			return this.destinationPosition;	
		}

		public string getDestination(){
			string s = GetDestination ().ToString ();
			return s;
		}

		//移動先の設定
		public void DestPos(Vector3 destPos){
			this.destinationPosition = destPos;		
		}
		public bool IsEnemyHit(string s){
		if (s == "EnemyHit")
				return true;
			return false;
		}

		public bool IsTagCheck(string s, string t){
			if (s == t)
				return true;
			return false;
		}

		public bool LessThanHP(int i){
		if (i <= 0)
				return true;
			return false;
		}

		public bool ThanItemPrefab(int itemLength){
			if (itemLength == 0)
				return true;
			return false;
		}

		public bool ThanTime(){
			if (GetWaitTime () > 0.0f)
				return true;
			return false;
		}

		public bool LessThanTime(){
			if (GetWaitTime() <= 0.0f)
				return true;
			return false;
		}

		public void SetEnemyController(IEnemyController enemyController) {
			this.enemyController = enemyController;
		}
		
	}
}