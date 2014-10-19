using UnityEngine;
using System.Collections;
namespace Cradle.Server{
public class Authentication : MonoBehaviour {
		void Start(){
			StartCoroutine(Example());
		}
		
		void Update(){}
	
	IEnumerator Example() {
			var form = new WWWForm();
			form.AddField("name", "value");
			var headers = form.headers;
		    var rawData = form.data;
			var url = "http://localhost:8080/Cradle/";

			headers["Authorization"] = 
				"Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("admin:admin"));

			var www = new WWW(url, rawData, headers);
			yield return www;

			// 成功
			if (www.error == null) {
				Debug.Log("Get Success");
			}
			// 失敗
			else{
				Debug.Log("Get Failure : " + www.error);           
			}
		}
	}
}