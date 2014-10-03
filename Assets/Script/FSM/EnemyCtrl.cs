using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class EnemyCtrl : AdvancedFSM, IEnemyController 
	{
		GameObject objPlayer;
		CharaStatus status;
		CharaAnimation charaAnimation;
		CharaMove characterMove;
		Transform attackTarget;
		GameRuleSettings gameRuleSettings;
		public GameObject hitEffect;
		public Vector3 basePosition; //初期位置を保存
		public GameObject[] dropItemPrefab; //複数のアイテムを入れる配列
		GameObject target;
		public AudioClip deathSeClip;
		AudioSource deathSeAudio;

		public EnemyCtrlController eController;
		
		public void OnEnable() {
			eController.SetEnemyController (this);
		}

		protected override void StartUp ()
		{
				setElapsedTime (3.0f);
				setAttackRate (4.0f);

				//コンポーネント取得
				GetComponents ();
				eController.SetWaitTime (eController.GetWaitBaseTime ());
				SetBasePosition ();
				SetPlayerTransform (objPlayer.transform);
				Log ();

				//FSMを構築
				BuildFSM ();
		}

		protected override void StateUpdate ()
		{
			setUpElapsedTime (Time.deltaTime);
		}
		
		protected override void StateFixedUpdate()
		{
			CurrentState.Reason (playerTransform, transform);
			CurrentState.Act (playerTransform, transform);
		}

		public void GetComponents(){
			FindStatusComponent ();
			FindAnimationComponent ();
			FindMoveComponent ();
			FindGameRuleComponent ();
			FindPlayer ();
		}

		public void Log(){
			if (!playerTransform)
				print ("プレーヤーが存在しません。タグ'Player'を追加してください。");
		}

		public void FindPlayer(){
			this.objPlayer = GameObject.FindGameObjectWithTag ("Player");	
		}

		public void FindStatusComponent(){
			this.status = GetComponent<CharaStatus>();		
		}

		public void FindAnimationComponent(){
			this.charaAnimation = GetComponent<CharaAnimation>();		
		}

		public void FindMoveComponent(){
			this.characterMove = GetComponent<CharaMove>();		
		}

		public void FindGameRuleComponent(){
			this.gameRuleSettings = GetComponent<GameRuleSettings>();		
		}

		public void SetBasePosition(){
			this.basePosition = transform.position;	
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
		
		
		public	void Walking(Vector3 destPos){
				//待機時間がまだあれば
				if (eController.ThanTime()) {
					//待機時間を減らす
					eController.SetDownWaitTime(Time.deltaTime);
					//待機時間が無くなったら
					if (eController.LessThanTime()) {
						//移動先の設定（WanderPointのうちランダムにどこかへ）
						Vector3 destinationPosition = destPos;
						//目的地の指定
						SendMessage ("SetDestination", destinationPosition);
						SendMessage("SetDirection", destinationPosition);
					}
				} else {
					//目的地へ到着
					if(characterMove.Arrived()){
						//待機状態へ
						eController.SetWaitTime(Random.Range(eController.GetWaitBaseTime(), eController.GetWaitBaseTime() * 2.0f));
					}
					//ターゲットを発見したら追跡
					if(attackTarget){
						SetTransition(Transition.ReachPlayer);
					}
				}
			}

		public void AttackStart()
		{
				if(attackCount())
				{
					status.SetAttacking(true);
					setElapsedTime(0.0f);
				}
			
			//移動を止める
			SendMessage ("StopMove");
			Attacking ();
		}


		//攻撃中の処理
		public void Attacking(){
				//ターゲットをリセット
				attackTarget = null;
		}

			void Damage(AttackInfo attackInfo)
		{
			//ヒットエフェクト
			GameObject effect = Instantiate (hitEffect, transform.position, Quaternion.identity) as GameObject;
			effect.transform.localPosition = transform.position + new Vector3 (0.0f, 0.5f, 0.0f);
			Destroy (effect, 0.3f);
			
			status.DamageHP(attackInfo.GetAttackPower());
			if(status.GetHP() <= 0)
			{
					status.SetHP(0);
				//死体を攻撃できないようにする
				foreach (Transform child in transform)
				{
					if(child.tag == "EnemyHit")
					{
						target = child.gameObject;
					}
				}
				target.layer = 0;
				//体力0なので倒れる
				Debug.Log("Switch to Dead State");
				SetTransition(Transition.NoHealth);
				Died();
			}
		}

		public void dropItem()
		{
			if(dropItemPrefab.Length == 0){ return; }
			GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)];
			Vector3 vec = dropItem.transform.up;
			vec.y += 1.0f;
			Instantiate (dropItem, transform.position + vec, Quaternion.identity);
		}
		
		public void Died()
		{
			status.SetDied (true);
			dropItem ();
			Destroy (gameObject, eController.GetDestroyTime());
			AudioSource.PlayClipAtPoint (deathSeClip, transform.position);
			if(gameObject.tag == "Enemy")
			{
					//ボスだった場合、ゲームクリア
					foreach (Transform child in transform)
					{
						if(child.tag == "Boss")
						{
							gameRuleSettings.GameClear();
						}
					}
			}
				//Deadタグへ更新
				this.gameObject.tag = "Dead";
		}


		//ステータスを初期化
		public void StateStartCommon()
		{
			status.SetAttacking (false);
			status.SetDied(false);
		}
		

		//攻撃対象を設定する
		public void SetAttackTarget(Transform target)
		{
			attackTarget = target;
		}
	}
	}