using UnityEngine;
using System.Collections;

public class GameRuleSettings : MonoBehaviour {
	//残り時間
	public float timeRemaining = 5.0f + 60.0f;
	public bool gameOver = false;
	public bool gameClear = false;

	void Update () {
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
	}
}
