using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JSONReadSampleWeb : MonoBehaviour {
	// Use this for initialization
	void Start () {
		// コルーチン実行開始
		StartCoroutine("GetJSON");
	}
	
	IEnumerator GetJSON(){
		// webサーバへアクセス
		WWW www = new WWW("http://007.planner-labo03.info/Cradle/src/main/java/jp/com/inotaku/domain/Item.java");
		// webサーバから何らかの返答があるまで停止
		yield return www;
		// もし、何らかのエラーがあったら
		if(!string.IsNullOrEmpty(www.error)){
			// エラー内容を表示
			Debug.LogError(string.Format("Fail Whale!\n{0}", www.error));
			yield break; // コルーチンを終了
		}
		// webサーバからの内容を文字列変数に格納
		string json = www.text; 
		// 以降JSONのパースは同じ    
		IList familyList = (IList)Json.Deserialize(json);
		
		foreach(IDictionary person in familyList){
			string name = (string)person["item"];
			Debug.Log("item:"+name);
			
			/*long age = (long)person["age"];
			Debug.Log("age:"+age);
			
			IList hobbes = (IList)person["hobby"];
			foreach(string hobby in hobbes){
				Debug.Log("hobby:"+hobby);
			}*/
		}
	}
}