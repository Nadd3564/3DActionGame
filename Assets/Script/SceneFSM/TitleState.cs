using UnityEngine;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern {
	public class TitleState : ISceneState { 
		private SceneManager manager;


		public TitleState(SceneManager stateManager) {
			//初期化
			manager = stateManager;
			Time.timeScale = 0;
		}


		public void StateUpdate() {
			InputWithSwitchState (GetKeyUpRet());
		}
		
		// Startボタンを生成して、ボタンが押されたときに、LogInStateに遷移
		public void Render() {

			// 解像度対応
			ResolutionSupport ();
			
			// タイトル画面テクスチャ表示
			GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), manager.GetBgTexture());
			
			//スタートボタン描画とクリック時に遷移
			InputWithSwitchState(StartButton());
		}


		public bool GetKeyUpRet(){
			return Input.GetKeyUp (KeyCode.Return);
		}

		public bool StartButton(){
			return GUI.Button(new Rect(327, 290, 200, 54), "Start", ButtonStyle());
		}

		//ログインシーンへ遷移
		public void InputWithSwitchState(bool method){
			if(method) { 
				Application.LoadLevel("LogInScene");
				Time.timeScale = 0;
				manager.SwitchState(new LogInState(manager)); 
			}
		}

		// ボタンのスタイルを準備.
		public GUIStyle ButtonStyle(){
			GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
			return buttonStyle;
		}

		//解像度
		void ResolutionSupport(){
			GUI.matrix = Matrix4x4.TRS(
				Vector3.zero,
				Quaternion.identity,
				new Vector3(Screen.width / 854.0f, Screen.height / 480.0f, 1.0f));	
		}


	}
	
}
