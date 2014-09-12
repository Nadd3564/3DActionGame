using UnityEngine;
using System.Collections;

public class GameRuleSettings : MonoBehaviour {
	//自分のPCのプレイヤーゲームオブジェクト
	public GameObject player;
	//実体化するプレイヤーのプレハブ
	public GameObject playerPrefab;
	//開始位置
	public Transform startPoint;
	public FollowCamera followCamera;

	//残り時間
	public float timeRemaining = 5.0f * 60.0f;
	public bool gameOver = false;
	public bool gameClear = false;
	public float sceneChangeTime = 20.0f;

	public AudioClip clearSeClip;
	AudioSource clearSeAudio;

	void Start(){
		//オーディオの初期化
		clearSeAudio = gameObject.AddComponent<AudioSource>();
		clearSeAudio.loop = false;
		clearSeAudio.clip = clearSeClip;
	}


	void Update () {
		//プレイヤーの発生
		if(player == null && (Network.isServer || Network.isClient)){
			Vector3 shiftVector = new Vector3(Network.connections.Length * 1.5f, 0, 0);
			player = 
				Network.Instantiate(playerPrefab, startPoint.position + shiftVector, startPoint.rotation, 0) as GameObject;
			followCamera.lookTarget = player.transform;
			//名前を送信する
			//NetworkManager networkManager = FindObjectOfType(typeof(NetworkManager)) as NetworkManager;
			//player.networkView.RPC("SetName", RPCMode.AllBuffered, networkManager.GEtPlayerName());
		}

		//ゲームオーバー、クリア後、タイトルへ
		if(gameOver || gameClear){
			sceneChangeTime -= Time.deltaTime;
			if(sceneChangeTime <= -3.0f){
				Application.LoadLevel("TitleScene");
			}
			return;
		}

		timeRemaining -= Time.deltaTime;
		//残り時間が無くなったらゲームオーバー
		if(timeRemaining <= 0.0f){
			GameOver();
		}
	}

	public void GameOver(){
		gameOver = true;
		Debug.Log ("GameOver");
	}

	public void GameClear(){
		gameClear = true;
		Debug.Log ("GameClear");

		clearSeAudio.Play ();
	}
}
