using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;


namespace Cradle{
public class TitleScenenCtrl : MonoBehaviour {
	    // タイトル画面テクスチャ
	    public Texture2D bgTexture;
		public string ID = "";
		public string passwordToEdit = "";
		private  LogIn.SpaceBook logIn;


		void OnGUI()
	    {
			// スタイルを準備.
			GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

			// 解像度対応
	        GUI.matrix = Matrix4x4.TRS(
	            Vector3.zero,
	            Quaternion.identity,
	            new Vector3(Screen.width / 854.0f, Screen.height / 480.0f, 1.0f));

	        // タイトル画面テクスチャ表示
	        GUI.DrawTexture(new Rect(0.0f, 0.0f, 854.0f, 480.0f), bgTexture);

			//入力ユーザ情報が一致する場合、次のシーンへ
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return && CheckID (ID) || GUI.Button (new Rect (327, 330, 100, 20), "LogIn", buttonStyle)) {
					if (GUI.GetNameOfFocusedControl () == "MyPassField" && CheckPass (passwordToEdit)) {
						Application.LoadLevel ("PlayScene");
					}
				}

			//ゲーム終了(Exitボタンを押す、または、Escapeを押す)
			if (GUI.Button (new Rect (427, 330, 100, 20), "Exit", buttonStyle) || Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();

			//ユーザIDとパスワード入力フィールド表示
			GUI.SetNextControlName("MyIdField");
			ID = GUI.TextField(new Rect(327,290,200,20),ID);
			GUI.SetNextControlName ("MyPassField");
			passwordToEdit = GUI.PasswordField(new Rect(327, 310, 200, 20), passwordToEdit, "*"[0], 25);

			//Enterを押すとID項目へフォーカス
			if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return)
				GUI.FocusControl ("MyIdField");

			//Enterを押すとPassword項目へフォーカス(ID項目に文字が存在する場合)
			if(Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return && ID != "")
				GUI.FocusControl ("MyPassField");


		}


		//ユーザ認証
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