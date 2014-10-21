using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;


namespace Cradle{
public class TitleScenenCtrl : MonoBehaviour {
	    // タイトル画面テクスチャ
	    public Texture2D bgTexture;
		public string passwordToEdit = "My Password";
		private  LogIn.SpaceBook logIn;
		public string ID  =  " ";
	    void OnGUI()
	    {
			//入力IDが一致する場合、次のシーンへ
			if( Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return && ID == "ID"){
				if( GUI.GetNameOfFocusedControl() == "file" ){
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
			GUI.SetNextControlName ("file");
			GUI.Label(new Rect(-100, -100, 1, 1), "");
			ID = GUI.TextField(new Rect(327,290,200,20), ID );
			passwordToEdit = GUI.PasswordField(new Rect(327, 310, 200, 20), passwordToEdit, "*"[0], 25);
			
		}
	
	}
}