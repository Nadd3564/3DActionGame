using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

namespace Cradle
{
	[Serializable]
	public class GetPostJsonController
	{

		private IDropItemController iDropItemController;
		
		public GetPostJsonController (){
		}
		
		public IEnumerator Get (string url) {
			// HEADER
			Hashtable header = new Hashtable ();
			header.Add ("Accept-Language", "ja");
			
			// 送信開始
			WWW www = new WWW (url, null, header);
			yield return www;
			
			// 成功
			if (www.error == null) {
				Debug.Log("Get Success");
				
				var json = www.text; 
				// GetResponseクラスにレスポンスを格納する
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


		public IEnumerator Post (string url) {
			// HEADERはHashtableで記述
			Hashtable header = new Hashtable ();
			header.Add ("Content-Type", "application/json; charset=UTF-8");
			
			// LitJsonを使いJSONデータを生成
			JsonData obj = new JsonData();
			obj["itemName"] = "katana";
			obj["itemType"] = "buki";
			obj["price"] = 300;
			obj["attack"] = "10";
			obj["defense"] = "0";
			obj["description"] = "atk";
			
			// シリアライズする(LitJson.JsonData→JSONテキスト)
			string postJsonStr = obj.ToJson();
			Debug.Log(postJsonStr);
			byte[] postBytes = Encoding.Default.GetBytes (postJsonStr);
			
			// 送信開始
			WWW www = new WWW (url, postBytes, header);
			yield return www;
			
			// 成功
			if (ErrorCheck(www)) {
				Debug.Log("WWW Ok!: " + www.data);
			}
			// 失敗
			else{
				Debug.Log("WWW Error: "+ www.error);          
			}
		}

		public bool ErrorCheck(WWW www){
			if (www.error == null)
								return true;
			return false;
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

}