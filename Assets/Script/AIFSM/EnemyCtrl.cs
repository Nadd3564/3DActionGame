using System.Collections;
using UnityEngine;
using Cradle.FM;
using Cradle;
using Cradle.Resource;

namespace Cradle.FM{
	public class EnemyCtrl : AdvancedFSM, IEnemyController 
		{
			GameObject objPlayer; //Playerの位置
			GameObject dropItem;
			GameObject target;	
			public Vector3 basePosition; //初期位置を保存
			Vector3 vec;
			public GameObject hitEffect;
			private GameObject effect;
			public GameObject[] dropItemPrefab; //複数のアイテムを入れる配列


			CharaStatus status;
			CharaAnimation charaAnimation;
			CharaMove characterMove;
			GameRuleSettings gameRuleSettings;

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
					setPlayerTransform (objPlayer.transform);
					Log ();
		
				try{
					//FSMを構築
					eController.BuildFSM ();
				}catch(UnityException e){
					Debug.Log("SaveExceptionLog : " + e);
					TextReadWriteManager write = new TextReadWriteManager();
					write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
				}
			}

			protected override void StateUpdate ()
			{
				setUpElapsedTime (Time.deltaTime);
				//For Tests
				eController.InstantiateTest (eController.IsdamageEffectTest(), IsNotNullEffect());
				eController.InstantiateTest (eController.IsDeathSeTest(), IsNotNullDeathSeClip());
			}
			
			protected override void StateFixedUpdate()
			{
				CurrentState.Reason (getPlayerTrans(), transform);
				CurrentState.Act (getPlayerTrans(), transform);
			}



			public void GetComponents(){
				FindStatusComponent ();
				FindAnimationComponent ();
				FindMoveComponent ();
				FindGameRuleComponent ();
				FindPlayer ();
			}

			public void Log(){
				if (!getPlayerTrans())
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
				this.gameRuleSettings = FindObjectOfType<GameRuleSettings>();		
			}

			public void SetBasePosition(){
				this.basePosition = transform.position;	
			}



			public void SetTransition(Transition t)
			{
				try{
				RunTransition (t);
				}catch(UnityException e){
					Debug.Log("SaveExceptionLog : " + e);
					TextReadWriteManager write = new TextReadWriteManager();
					write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
				}
			}

			public void Walking(Vector3 destPos){
					//待機時間がまだあれば
					if (eController.ThanTime()) {
						//待機時間を減らす
						eController.SetDownWaitTime(Time.deltaTime);
						//待機時間が無くなったら
						if (eController.LessThanTime()) {
							//移動先の設定（WanderPointのうちランダムにどこかへ）
							eController.DestPos(destPos);
							//目的地の指定
							SendMessage ("SetDestination", eController.GetDestination());
							SendMessage("SetDirection", eController.GetDestination());
						}
					} else {
							Arrived();
					}
				}
			

			public void Arrived(){
				//目的地へ到着
				if(characterMove.Arrived()){
					//待機状態へ
					eController.SetWaitTime(Random.Range(eController.GetWaitBaseTime(), eController.GetWaitBaseTime() * 2.0f));
				}
			}

			public void AttackStart(){
				try{
					eController.attackStart ();
				}catch(UnityException e){
					Debug.Log("SaveExceptionLog : " + e);
					TextReadWriteManager write = new TextReadWriteManager();
					write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
				}
					
			}

			public void SendMsgStop(){
				SendMessage ("StopMove");
			}

			public bool setAttacking(){
				return status.SetAttacking(true);
			}

				void Damage(AttackInfo attackInfo)
			{
				//ヒットエフェクト
				CreateHitEffect ();
				EffectPos ();
				Destroy (effect, 0.3f);

				//HPを減らす
				status.DamageHP(attackInfo.GetAttackPower());

				//死体を攻撃できないようにし、体力0なので倒れる
				try{
					eController.Down();
				}catch (UnityException e){
					Debug.Log("SaveExceptionLog : " + e);
					TextReadWriteManager write = new TextReadWriteManager();
					write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
				}
			}

			public float GetHP(){
				return status.GetHP ();
			}

			public void SetHP(){
				status.SetHP(0);
			}

			//死体を攻撃できないようにする
			public void CanNotAttack(){
				foreach (Transform child in transform)
				{
					if(eController.IsTagCheck(child.tag, "EnemyHit"))
					{
						target = child.gameObject;
					}
				}
				target.layer = 0;
			}

			public void DeadLog(){
				Debug.Log("Switch to Dead State");
			}

			public void CreateHitEffect(){
				this.effect = Instantiate (hitEffect, transform.position, Quaternion.identity) as GameObject;
			}

			public void EffectPos(){
				this.effect.transform.localPosition = transform.position + new Vector3 (0.0f, 0.5f, 0.0f);
			}


			public void DropItem()
			{
				if(eController.ThanItemPrefab(dropItemPrefab.Length)){ return; }
				InitItem ();
				JumpItem ();
				Instantiate (dropItem, transform.position + vec, Quaternion.identity);
			}


			//ランダムでドロップするアイテムを選出
			public void InitItem(){
				this.dropItem = dropItemPrefab[Random.Range(0, dropItemPrefab.Length)];
			}

			//アイテムがポップする
			public void JumpItem(){
				this.vec = dropItem.transform.up;
				this.vec.y += 1.0f;
			}

			public void SetDied(){
				status.setDied (true);
			}

			public void DiedDestroy(){
				Destroy (gameObject, eController.GetDestroyTime());
			}

			public void FindBossTag(){
				//ボスだった場合、ゲームクリア
				foreach (Transform child in transform) {
					if (eController.IsTagCheck (child.tag, "Boss")) {
						GameClear ();
					}
				}
			}

			public void GameClear(){
				this.gameRuleSettings.GameClear();
			}


			public void PlayDeathSE(){
				AudioSource.PlayClipAtPoint (deathSeClip, transform.position);
			}

			public string SetTag(){
				this.gameObject.tag = "Dead";
				string s = this.gameObject.tag;
				return s;
			}

			//ステータスを初期化
			public void StateStartCommon()
			{
				status.SetAttacking (false);
				status.setDied(false);
			}

			//For Tests
			public bool IsNotNullEffect(){
				if(this.effect != null)
				return true;
				return false;
			}

			//For Tests
			public bool IsNotNullDeathSeClip(){
				if(this.deathSeClip != null)
					return true;
				return false;
			}

	}
}