using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class GameRuleSettings : MonoBehaviour {
	//残り時間
	public float timeRemaining = 5.0f + 60.0f;
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
		//ゲームオーバー、クリア後、タイトルへ
		if(gameOver || gameClear){
			sceneChangeTime -= Time.deltaTime;
			if(sceneChangeTime <= -10.0f){
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
}