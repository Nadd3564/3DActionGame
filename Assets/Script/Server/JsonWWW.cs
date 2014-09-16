using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class JsonWWW : MonoBehaviour {
	
	void Start () {
		// IEnumeratorインターフェースを継承したメソッドは、StartCoroutineでコールする
		StartCoroutine(Get("http://www.google.co.jp"));
		StartCoroutine(Post("http://www.google.co.jp"));  // 今回は失敗します
	}
	
	void Update () {
		
	}
	
	IEnumerator Get (string url) {
		// HEADERはHashtableで記述
		Hashtable header = new Hashtable ();
		header.Add ("Accept-Language", "ja");
		
		// 送信開始
		WWW www = new WWW (url, null, header);
		yield return www;
		
		// 成功
		if (www.error == null) {
			Debug.Log("Get Success");
			
			// 本来はサーバからのレスポンスとしてjsonを戻し、www.textを使用するが
			// 今回は便宜上、下記のjsonを使用する
			string txt = "{\"name\": \"okude\", \"level\": 99, \"friend_names\": [\"ichiro\", \"jiro\", \"saburo\"]}";
			// 自作したTestResponseクラスにレスポンスを格納する
			TestResponse response = JsonMapper.ToObject<TestResponse> (txt);
			Debug.Log("name: " + response.name);
			Debug.Log("level: " + response.level);
			Debug.Log("friend_names[0]: " + response.friend_names[0]);
			Debug.Log("friend_names[1]: " + response.friend_names[1]);
			Debug.Log("friend_names[2]: " + response.friend_names[2]);
		}
		// 失敗
		else{
			Debug.Log("Get Failure");           
		}
	}
	
	IEnumerator Post (string url) {
		// HEADERはHashtableで記述
		Hashtable header = new Hashtable ();
		// jsonでリクエストを送るのへッダ例
		header.Add ("Content-Type", "application/json; charset=UTF-8");
		
		// LitJsonを使いJSONデータを生成
		JsonData data = new JsonData();
		data["hogehoge"] = 1;
		// シリアライズする(LitJson.JsonData→JSONテキスト)
		string postJsonStr = data.ToJson();
		byte[] postBytes = Encoding.Default.GetBytes (postJsonStr);
		
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

// レスポンスのJSONを格納するクラス
class TestResponse {
	public string name;
	public int level;
	public List<string> friend_names;
}