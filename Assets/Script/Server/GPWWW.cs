using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class GPWWW : MonoBehaviour {

	void Start () {
		StartCoroutine(Get("http://localhost:8080/Cradle/json/3"));
		StartCoroutine(Post("http://localhost:8080/Cradle/json"));  
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

			var json = www.text; 
			// 自作したGetResponseクラスにレスポンスを格納する
			GetResponse response = JsonMapper.ToObject<GetResponse> (json);
			Debug.Log("itemid :" + response.itemId);
			Debug.Log("itemname" + response.itemName);
			Debug.Log("itemType" + response.itemType);
			Debug.Log("price" + response.price);
			Debug.Log("attack" + response.attack);
			Debug.Log("defence" + response.defence);
			Debug.Log("description" + response.description);
			Debug.Log("updateTime" + response.updateTime);
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
class GetResponse {
	public int itemId;
	public string itemName;
	public string itemType;
	public int price;
	public int attack;
	public int defence;
	public string description;
	public long updateTime;
	//public List<string> friend_names;
}

[System.Serializable]
class Data{
	public int itemId;
	public string itemName;
	public string itemType;
	public int price;
	public int attack;
	public int defence;
	public string description;
	public long updateTime;
}