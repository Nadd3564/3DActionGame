using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;


namespace Cradle{
public class TitleScenenCtrl : MonoBehaviour {
	    // タイトル画面テクスチャ
	    public Texture2D bgTexture;
		public string ID = "";
		public string passwordToEdit = "user";
		private  LogIn.SpaceBook logIn;

		void OnGUI()
	    {
			//入力IDが一致する場合、次のシーンへ
			if(Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return && CheckID(ID)){
				if( GUI.GetNameOfFocusedControl() == "GETID" && CheckPass(passwordToEdit)){
					Application.LoadLevel("PlayScene");
				}
			}

	        // スタイルを準備.
	        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

			
			// 解像度対応
	        GUI.matrix = Matrix4x4.TRS(
	            Vector3.zero,
	            Quaternion.identity,
	            new Vector3(Screen.width / 854.0f, Screen.height / 480.0f, 1.0f));
	        // タイトル画面テクスチャ表示
	        GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), bgTexture);

			//ユーザIDとパスワード入力フィールド表示
			ID = GUI.TextField(new Rect(327,290,200,20),ID);
			GUI.SetNextControlName ("GETID");
			passwordToEdit = GUI.PasswordField(new Rect(327, 310, 200, 20), passwordToEdit, "*"[0], 25);
		
		}

		//ユーザ認証
		private bool Authentication(string ID, string Password){
			if(CheckID(ID) && CheckPass(Password))
				return true;
			return false;
		}

		private bool CheckID(string ID){
			if (ID != "user") {
				Debug.Log("ID : Failed");
				return false;
			}
			
			if (ID == "user") {
				Debug.Log("ID : Success");		
			}
			return true;

		}
	
		private bool CheckPass(string Password){
			if (Password != "user") {
				Debug.Log("Password : Failed");
					return false;
			}
			
			if (Password == "user") {
				Debug.Log("Password : Success");		
				}
			return true;

		}


	}
}