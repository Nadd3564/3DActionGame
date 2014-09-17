using UnityEngine;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System.Linq;
using UniRx;

public class JSONSampleWeb : MonoBehaviour {

	void Start () {
		// コルーチン実行開始
		StartCoroutine(GetJSON("http://localhost:8080/Cradle/json/3"));
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
		// 以降JSONのパースは同じ    
		Debug.Log (www.text);
	}

	IEnumerator PostJSON(string url){

		// HEADERはHashtableで記述
		Hashtable header = new Hashtable ();
		header.Add ("Content-Type", "application/json; charset=UTF-8");

		JSONObject data = new JSONObject();
		data.AddField ("itemId", 1);
		data.AddField ("itemName", "ルーンソード");

		string postJsonStr = MiniJSON.Json.Serialize(data);
		byte[] postBytes = System.Text.Encoding.UTF8.GetBytes (postJsonStr);
		// 送信開始
		WWW www = new WWW (url, postBytes, header);
		yield return www;

		// 成功
		if (www.error == null) {
			Debug.Log("Post Success");
		}
		// 失敗
		else{
			Debug.Log("Post Failure");          
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