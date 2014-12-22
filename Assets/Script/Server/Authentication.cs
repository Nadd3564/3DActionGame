using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;
using LitJson;

namespace Cradle.DesignPattern{
	public class Authentication : MonoBehaviour{
		private string id;
		private string password;
		private bool ProxyFlg = false;

		
		void Update(){
			StartCoroutine(BasicAuthenticate());
		}
	

		//基本認証
		IEnumerator BasicAuthenticate() {
			var form = new WWWForm();
			form.AddField("name", "value");
			var headers = form.headers;
			var rawData = form.data;
			var url = "http://localhost:8080/Cradle/";

			//入力をBase64へシリアライズ
			headers["Authorization"] = 
				"Basic " + System.Convert.ToBase64String(
					System.Text.Encoding.ASCII.GetBytes(GetId() + ":" + GetPass()));
			
			//テスト中のため、ログを表示
			Debug.Log (GetId() + ":" + GetPass());
			
			var www = new WWW(url, rawData, headers);
			yield return www;
			
			
			// 成功
			if (www.error == null) {
				Debug.Log("Get Success");
				SetProxyFlg();

				//サーバーからJson形式のファイルを受け取る
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
				Debug.Log("Get Failure : " + www.error); 
				//サーバ＾との連動が完全になるまで仮処理
				SetProxyFlg();
			}
		}


		public string GetId(){
			return this.id;
		}
		
		public string GetPass(){
			return this.password;
		}

		public void SetId(string id){
			this.id = id;
			//テスト中のため、ログを表示
			Debug.Log (GetId());
		}
		
		public void SetPass(string password){
			this.password = password;
			//テスト中のため、ログを表示
			Debug.Log (GetPass());
		}
		
		public bool IsProxyFlg(){
			return this.ProxyFlg;	
		}
		
		public void SetProxyFlg(){
			this.ProxyFlg = true;
		}

	}
	//サーバーからのレスポンスを格納
	class GetResponse {
		public int itemId;
		public string itemName;
		public string itemType;
		public int price;
		public int attack;
		public int defence;
		public string description;
		public long updateTime;
	}
}