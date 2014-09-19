using UnityEngine;
using System.Collections;

namespace Cradle.Server{
public class PostURL : MonoBehaviour {
	
	void Start () {
		
		string url = "http://localhost:8080/Cradle/json/";
		
		JSONObject form = new JSONObject(JSONObject.Type.OBJECT);
		form.AddField("itemname", "value1");
		form.AddField("ItemType", "value2");

		JSONObject arr = new JSONObject (JSONObject.Type.ARRAY);
		form.AddField ("price", arr);
		arr.Add (1);
		arr.Add (2);

		Debug.Log (form);
		//JSONObject[] arr = new JSONObject(JSONObject.Type.ARRAY);



		string postJsonStr = MiniJSON.Json.Serialize(form);
		byte[] postBytes = System.Text.Encoding.Default.GetBytes (postJsonStr);
		WWW www = new WWW(url, postBytes);
		
		StartCoroutine(WaitForRequest(www));
	}
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
			
			// check for errors
			if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.data);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}    
}
}