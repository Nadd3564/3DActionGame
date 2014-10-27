using UnityEngine;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern {
	public class LogInState : ISceneState { 

		private	bool flg = false;
		private string id = "";
		private string passwordToEdit = "";
		private GUIStyle color;
		private GUIStyle buttonStyle;
		
		private SceneManager manager;
		
		public LogInState(SceneManager stateManager) { 
			//初期化
			manager = stateManager;
		}
		
		public void StateUpdate() { 
		}
		
		public void Render() { 
			// スタイルを準備.
			SetButtonStyle ();
			SetTextStyle ();

			// 解像度対応
			ResolutionSupport ();
			
			// タイトル画面テクスチャ表示
			GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), manager.GetBgTexture());

			//入力ユーザ情報が一致する場合、次のシーンへ
			LogInAndNextScene (id);
			
			//ゲーム終了(Exitボタンを押す、または、Escapeを押す)
			GameQuit ();
			
			//ユーザIDとパスワード入力フィールド表示
			InputIdField ();
			InputPassField ();

			//Enterを押すとID項目へフォーカス
			FocusId ();
			
			//Enterを押すとPassword項目へフォーカス(ID項目に文字が存在する場合)
			FocusPass ();
			
			//Enterを押すと入力パスワードを登録
			IsLogIn ();
		}


		public string GetID(){
			return this.id;	
		}
		
		public string GetPass(){
			return this.passwordToEdit;	
		}

		public bool IsFlg(){
			return this.flg;	
		}
		
		public void SetFlg(){
			this.flg = true;
		}

		// スタイルを準備.
		void SetButtonStyle(){
			this.buttonStyle = new GUIStyle(GUI.skin.button);
		}

		void SetTextStyle(){
			this.color = new GUIStyle ();
			color.padding.top = 5;
			color.normal.textColor = Color.black;
		}

		// 解像度対応
		void ResolutionSupport(){
			GUI.matrix = Matrix4x4.TRS(
				Vector3.zero,
				Quaternion.identity,
				new Vector3(Screen.width / 854.0f, Screen.height / 480.0f, 1.0f));
		}

		//入力ユーザ情報が一致する場合、次のシーンへ
		public void LogInAndNextScene(string id){
			if (IsCheckInputId(id)) {
				if (IsCheckFocusWithPass()) {
					Application.LoadLevel ("PlayScene");
					manager.SwitchState(new PlayState(manager));
				}
			}
		}

		public bool IsCheckFocusWithPass(){
			if(IsCheckFocus() && IsCheckPassWithFlg())	
				return true;
			return false;
		}

		public bool IsCheckPassWithFlg(){
			if(CheckPass (passwordToEdit) && IsFlg())
				return true;
			return false;
		}

		public bool IsCheckFocus(){
			if(GUI.GetNameOfFocusedControl () == "MyPassField")	
				return true;
			return false;
		}

		public bool IsCheckInputId(string id){
			if(IsKeyDownWithReturn() && CheckID(id) || IsLogInButton())	
				return true;
			return false;
		}

		//LogInボタン表示
		public bool IsLogInButton(){
			if (GUI.Button (new Rect (327, 360, 100, 20), "LogIn", buttonStyle))
			return true;
			return false;
		}

		public bool IsKeyDownWithReturn(){
			if(IsKeyDown() && IsReturn())	
				return true;
			return false;
		}

		public bool IsKeyDown(){
			if(Event.current.type == EventType.KeyDown)	
				return true;
			return false;
		}


		//ゲーム終了(Exitボタンを押す、または、Escapeを押す)
		public void GameQuit(){
			if (IsButtonOrEscape())
				Application.Quit();
		}

		public bool IsButtonOrEscape(){
			if (GUI.Button (new Rect (427, 360, 100, 20), "Exit", buttonStyle) || Input.GetKeyDown(KeyCode.Escape))
				return true;
			return false;
		}

		//id入力項目表示
		public void InputIdField(){
			GUI.Label (new Rect(327,270,200,10), "ID", color);
			GUI.SetNextControlName("MyIdField");
			id = GUI.TextField(new Rect(327,290,200,20),id);
		}

		//password入力項目表示
		public void InputPassField(){
			GUI.Label (new Rect(327,310,200,10), "Password", color);
			GUI.SetNextControlName ("MyPassField");
			passwordToEdit = GUI.PasswordField(new Rect(327, 330, 200, 20), passwordToEdit, "*"[0], 25);
		}

		public bool IsKeyUpRetWithNotEmpId(){
			if (IsKeyUpReturn() && IsNotEmptyId())
				return true;
				return false;
		}

		//Enterを押すとID項目へフォーカス
		public void FocusId(){
			if (IsKeyUpReturn()) {
				GUI.FocusControl ("MyIdField");
			}
		}

		//Enterを押すとPassword項目へフォーカス(ID項目に文字が存在する場合)
		public void FocusPass(){
			if (IsKeyUpRetWithNotEmpId()) {
				GUI.FocusControl ("MyPassField");
				//テストログ
				Debug.Log ("Success : ");
			}
		}

		//Enterを押すと入力パスワードを登録
		public void IsLogIn(){
			if (IsCheckInput()) {
				//テストログ
				Debug.Log("Register");
				SetFlg();
			}
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
		
		//ユーザ認証
		private bool CheckID(string ID){
			if (ID != this.id) {
				//テストログ
				Debug.Log("ID : Failed");
				return false;
			}
			
			if (ID == this.id) {
				//テストログ
				Debug.Log("ID : Success");		
			}
			return true;
			
		}
		
		private bool CheckPass(string Password){
			if (Password != passwordToEdit) {
				//テストログ
				Debug.Log("Password : Failed");
				return false;
			}
			
			if (Password == passwordToEdit) {
				//テストログ
				Debug.Log("Password : Success");		
			}
			return true;
			
		}

	}
}