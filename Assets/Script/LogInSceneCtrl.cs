using UnityEngine;
using System;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;


namespace Cradle{
public class LogInSceneCtrl : AccountManager {
		bool flg = false;
	    // タイトル画面テクスチャ
	    public Texture2D bgTexture;
		public string ID = "";
		public string passwordToEdit = "";
		MyUserBook me;
		private GUIStyle color;


		void Main(){
			me = new MyUserBook ();
		}


		void OnGUI()
	    {
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
	        GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), bgTexture);


			//入力ユーザ情報が一致する場合、次のシーンへ
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return && CheckID (ID) || GUI.Button (new Rect (327, 360, 100, 20), "LogIn", buttonStyle)) {
				if (GUI.GetNameOfFocusedControl () == "MyPassField" && CheckPass (passwordToEdit) && flg) {
					Application.LoadLevel ("PlayScene");
					}
				}

			//ゲーム終了(Exitボタンを押す、または、Escapeを押す)
			if (GUI.Button (new Rect (427, 360, 100, 20), "Exit", buttonStyle) || Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();

			//ユーザIDとパスワード入力フィールド表示
			GUI.Label (new Rect(327,270,200,10), "ID", color);
			GUI.SetNextControlName("MyIdField");
			ID = GUI.TextField(new Rect(327,290,200,20),ID);
			GUI.Label (new Rect(327,310,200,10), "Password", color);
			GUI.SetNextControlName ("MyPassField");
			passwordToEdit = GUI.PasswordField(new Rect(327, 330, 200, 20), passwordToEdit, "*"[0], 25);

			//me = new MySpaceBook ();
			//Enterを押すとID項目へフォーカス
			if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
					GUI.FocusControl ("MyIdField");
			}

			//Enterを押すとPassword項目へフォーカス(ID項目に文字が存在する場合)
			if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return && ID != "") {
					GUI.FocusControl ("MyPassField");
						
					me.Add("Hello");
					Debug.Log ("Success : " + me);
			}

			//Enterを押すと入力パスワードを登録
			if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return && ID != "" && passwordToEdit != "") {
					me.PassRegister(ID);
					Debug.Log("Passregi");
					this.flg = true;
			}
			
			
			
		}


		public string GetID(){
			return this.ID;	
		}

		public string GetPass(){
			return this.passwordToEdit;	
		}


		//ユーザ認証
		private bool CheckID(string ID){
			if (ID != this.ID) {
				Debug.Log("ID : Failed");
				return false;
			}
			
			if (ID == this.ID) {
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