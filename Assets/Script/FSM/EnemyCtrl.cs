using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle.FM{
public class EnemyCtrl : AdvancedFSM {
	CharaStatus status;
	CharaAnimation charaAnimation;
	//CharaMove characterMove;
	Transform attackTarget;
	GameRuleSettings gameRuleSettings;
	public GameObject hitEffect;
	public float waitBaseTime = 2.0f; //待機時間
	float waitTime; //残り待機時間
	public float walkRange = 5.0f; //移動範囲
	public Vector3 basePositon; //初期位置を保存
	public GameObject[] dropItemPrefab; //複数のアイテムを入れる配列
	GameObject target;
	GUILayer layer;
	public AudioClip deathSeClip;
	AudioSource deathSeAudio;
	
	protected override void StartUp ()
	{
		status = GetComponent<CharaStatus>();
		charaAnimation = GetComponent<CharaAnimation>();
		//characterMove = GetComponent<CharaMove> ();
		basePositon = transform.position;
		waitTime = waitBaseTime;
		gameRuleSettings = FindObjectOfType<GameRuleSettings> ();
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

	void WalkStart(){
		StateStartCommon ();
	}
	
	/*void Walking(){
		//待機時間がまだあれば
		if (waitTime > 0.0f) {
			//待機時間を減らす
			waitTime -= Time.deltaTime;
			//待機時間が無くなったら
			if (waitTime <= 0.0f) {
				//範囲内の何処か
				Vector2 randomValue = Random.insideUnitCircle * walkRange;
				//移動先の設定
				Vector3 destinationPosition = basePositon + new Vector3 (randomValue.x, 0.0f, randomValue.y);
				//目的地の指定
				SendMessage ("SetDestination", destinationPosition);
			}
		} else {
			//目的地へ到着
			if(Arrived()){
				//待機状態へ
				waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
			}
			//ターゲットを発見したら追跡
			if(attackTarget){
				SetTransition(Transition.LostPlayer);
			}
		}
	}*/


	public void AttackStart(){
		StateStartCommon ();
		status.attacking = true;
		
		//敵の方向に振り向かせる
		//Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
		//SendMessage ("SetDirection", targetDirection);
		
		//移動を止める
		SendMessage ("StopMove");
	}

	//攻撃中の処理
	public void Attacking(){
		if (charaAnimation.isAttacked ())
						SetTransition (Transition.SawPlayer);
		//待機時間を再設定
		waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
		//ターゲットをリセット
		attackTarget = null;
	}

	void Damage(AttackArea.AttackInfo attackInfo){
		//ヒットエフェクト
		GameObject effect = Instantiate (hitEffect, transform.position, Quaternion.identity) as GameObject;
		effect.transform.localPosition = transform.position + new Vector3 (0.0f, 0.5f, 0.0f);
		Destroy (effect, 0.3f);
		
		status.HP -= attackInfo.attackPower;
		if(status.HP <= 0){
			status.HP = 0;
			//死体を攻撃できないようにする
			foreach (Transform child in transform){
				if(child.tag == "EnemyHit"){
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

	public void dropItem(){
		if(dropItemPrefab.Length == 0){ return; }
		GameObject dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)];
		Vector3 vec = dropItem.transform.up;
		vec.y += 1.0f;
		Instantiate (dropItem, transform.position + vec, Quaternion.identity);
	}
	
	public void Died(){
		status.died = true;
		dropItem ();
		Destroy (gameObject, 5);
		AudioSource.PlayClipAtPoint (deathSeClip, transform.position);
		if(gameObject.tag == "Boss"){
			gameRuleSettings.GameClear();
		}
	}


	//ステータスを初期化
	void StateStartCommon(){
		status.attacking = false;
		status.died = false;
	}
	

	//攻撃対象を設定する
	public void SetAttackTarget(Transform target){
		attackTarget = target;
	}
}
}