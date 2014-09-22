using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

namespace Cradle.Server{
public class JSONSampleWeb : MonoBehaviour {

	void Start () {
		// コルーチン実行開始
		StartCoroutine(GetJSON("http://localhost:8080/Cradle/json/4"));
		StartCoroutine(PostJSON("http://localhost:8080/Cradle/json/"));
	}
	
	IEnumerator GetJSON(string url){
		// HEADERはHashtableで記述
		Hashtable header = new Hashtable ();
		header.Add ("Accept-Language", "ja");
		
		// 送信開始
		WWW www = new WWW (url, null, header);
		yield return www;

		// webサーバからの内容を文字列変数に格納
		var json = Json.Deserialize(www.text) as IDictionary<string, object>;
		Debug.Log (www.text);
	}

	IEnumerator PostJSON(string url){

		string jsonString = "{\"itemName\":\"Spear\",\"itemType\":\"aa\",\"price\":30000,\"attack\":100,\"defense\":0,\"description\":\"10000\"}";

		// HEADERはHashtableで記述
		Hashtable header = new Hashtable ();
		header.Add ("Content-Type", "text/json");
		header.Add("Content-Length", jsonString.Length);

		var encording = new System.Text.UTF8Encoding ();

		print("jsonString: " + jsonString);

		// 送信開始
		var request = new WWW (url, encording.GetBytes(jsonString), header);
		yield return request;


		// 成功
		if (request.error == null) {
			Debug.Log("WWW Ok!: " + request.data);
		}
		// 失敗
		else{
			Debug.Log("WWW Error: "+ request.error);          
		}

	}

}



/*data.AddField("itemId", 10);
		data.AddField("itemName", "Add");
		data.AddField("itemType", "武器");
		data.AddField("price", 100);
		data.AddField("attack", 10);
		data.AddField("defence", 10);
		data.AddField("description", "すごい");
		data.AddField("updateTime", 10);*/

// レスポンスのJSONを格納するクラス
/*class GetResponse {
	public int itemId;
	public string itemName;
	public string itemType;
	public int price;
	public int attack;
	public int defence;
	public string description;
	public long updateTime;
	//public List<string> friend_names;
}*/
}