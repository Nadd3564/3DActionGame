using UnityEngine;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern {
	public class TitleState : ISceneState { 
		private SceneManager manager;


		public TitleState(SceneManager stateManager) {
			//初期化
			manager = stateManager;
			Time.timeScale = 0;
			Debug.Log("change");
		}


		public void StateUpdate() {
			if(Input.GetKeyUp(KeyCode.Return)) { 
				Application.LoadLevel("LogInScene");
				Time.timeScale = 0;
				manager.SwitchState(new LogInState(manager)); 
			}
		}
		
		// Startボタンを生成して、ボタンが押されたときに、LogInStateに遷移
		public void Render() {
			// スタイルを準備.
			GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
			
			// 解像度対応
			GUI.matrix = Matrix4x4.TRS(
				Vector3.zero,
				Quaternion.identity,
				new Vector3(Screen.width / 854.0f, Screen.height / 480.0f, 1.0f));
			
			// タイトル画面テクスチャ表示
			GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), manager.GetBgTexture());
			
			//スタートボタン
			if(GUI.Button(new Rect(327, 290, 200, 54), "Start", buttonStyle)){
				Application.LoadLevel("LogInScene");
				Time.timeScale = 0;
				manager.SwitchState(new LogInState(manager)); 
			}
		}

		public void StateFixedUpdate(){
			
		}

	}
	
}
