using UnityEngine;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern {
	public class LogInState : ISceneState { 

		bool flg = false;
		public string id = "";
		public string passwordToEdit = "";
		private GUIStyle color;

		
		private SceneManager manager;
		
		public LogInState(SceneManager stateManager) { 
			//初期化
			manager = stateManager;
		}
		
		public void StateUpdate() { 
		}
		
		public void Render() { 
			// スタイルを準備.
			GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
			color = new GUIStyle ();
			color.padding.top = 5;
			color.normal.textColor = Color.black;
			// 解像度対応
			GUI.matrix = Matrix4x4.TRS(
				Vector3.zero,
				Quaternion.identity,
				new Vector3(Screen.width / 854.0f, Screen.height / 480.0f, 1.0f));
			
			// タイトル画面テクスチャ表示
			GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), manager.GetBgTexture());
			
			
			//入力ユーザ情報が一致する場合、次のシーンへ
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return && CheckID (id) || GUI.Button (new Rect (327, 360, 100, 20), "LogIn", buttonStyle)) {
				if (GUI.GetNameOfFocusedControl () == "MyPassField" && CheckPass (passwordToEdit) && flg) {
					Application.LoadLevel ("PlayScene");
					manager.SwitchState(new PlayState(manager));
					
				}
			}
			
			//ゲーム終了(Exitボタンを押す、または、Escapeを押す)
			if (GUI.Button (new Rect (427, 360, 100, 20), "Exit", buttonStyle) || Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();
			
			//ユーザIDとパスワード入力フィールド表示
			GUI.Label (new Rect(327,270,200,10), "ID", color);
			GUI.SetNextControlName("MyIdField");
			id = GUI.TextField(new Rect(327,290,200,20),id);
			GUI.Label (new Rect(327,310,200,10), "Password", color);
			GUI.SetNextControlName ("MyPassField");
			passwordToEdit = GUI.PasswordField(new Rect(327, 330, 200, 20), passwordToEdit, "*"[0], 25);
			
			//Enterを押すとID項目へフォーカス
			FocusId ();
			
			//Enterを押すとPassword項目へフォーカス(ID項目に文字が存在する場合)
			FocusPass ();
			
			//Enterを押すと入力パスワードを登録
			IsLogIn ();
		}


		public bool IsKeyUpRetWithNotEmpId(){
			if (IsKeyUpReturn() && IsNotEmptyId())
				return true;
				return false;
		}



		public void IsLogIn(){
			if (IsCheckInput()) {
				//テストのためログ
				Debug.Log("Register");
				SetFlg();
			}
		}

		public void FocusId(){
			if (IsKeyUpReturn()) {
				GUI.FocusControl ("MyIdField");
			}
		}

		public void FocusPass(){
			if (IsKeyUpRetWithNotEmpId()) {
				GUI.FocusControl ("MyPassField");
				//テストのためログ
				Debug.Log ("Success : ");
			}
		}

		public void SetFlg(){
			this.flg = true;
		}

		public bool IsCheckInput(){
			if(IsKeyUpReturn() && IsNotEmptyIdPass())
				return true;
			return false;
		}


		public bool IsKeyUpReturn(){
			if(IsKeyUp() && IsReturn())
				return true;
			return false;
		}


		public bool IsKeyUp(){
			if(Event.current.type == EventType.KeyUp)
				return true;
			return false;
		}

		public bool IsReturn(){
			if(Event.current.keyCode == KeyCode.Return)
				return true;
			return false;
		}

		public bool IsNotEmptyIdPass(){
			if(IsNotEmptyId() && IsNotEmptyPass())
				return true;
			return false;
		}


		public bool IsNotEmptyId(){
			if(id != "")
				return true;
			return false;
		}

		public bool IsNotEmptyPass(){
			if(passwordToEdit != "")
				return true;
			return false;
		}

		public string GetID(){
			return this.id;	
		}
		
		public string GetPass(){
			return this.passwordToEdit;	
		}
		
		
		//ユーザ認証
		private bool CheckID(string ID){
			if (ID != this.id) {
				Debug.Log("ID : Failed");
				return false;
			}
			
			if (ID == this.id) {
				Debug.Log("ID : Success");		
			}
			return true;
			
		}
		
		private bool CheckPass(string Password){
			if (Password != passwordToEdit) {
				Debug.Log("Password : Failed");
				return false;
			}
			
			if (Password == passwordToEdit) {
				Debug.Log("Password : Success");		
			}
			return true;
			
		}

	}
}