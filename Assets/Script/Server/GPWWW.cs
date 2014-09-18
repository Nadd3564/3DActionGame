using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class GPWWW : MonoBehaviour {

	void Start () {
		StartCoroutine(Get("http://localhost:8080/Cradle/json/3"));
		StartCoroutine(Post("http://localhost:8080/Cradle/json/"));  
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
		JsonData obj = new JsonData();
		obj["itemName"] = "katana";
		obj["itemType"] = "buki";
		obj["price"] = 300;
		obj["attack"] = 10;
		obj["defence"] = 0;
		obj["description"] = "atk+10 speed+10";

		// シリアライズする(LitJson.JsonData→JSONテキスト)
		string postJsonStr = obj.ToJson();
		Debug.Log(postJsonStr);
		byte[] postBytes = Encoding.Default.GetBytes (postJsonStr);
		
		// 送信開始
		WWW www = new WWW (url, postBytes, header);
		yield return www;
		
		// 成功
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.data);
		}
		// 失敗
		else{
			Debug.Log("WWW Error: "+ www.error);          
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

/*[System.Serializable]
class Data{
	public int itemId;
	public string itemName;
	public string itemType;
	public int price;
	public int attack;
	public int defence;
	public string description;
	public long updateTime;
}*/