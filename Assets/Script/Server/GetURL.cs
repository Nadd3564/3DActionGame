using UnityEngine;
using System.Collections;
public class GetURL : MonoBehaviour {
	
	void Start () {
		string url = "http://007.planner-labo03.info/Cradle/";
		WWW www = new WWW(url);
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

	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			StartCoroutine(connect("http://007.planner-labo03.info/Cradle/"));
		}
	}
	
	IEnumerator connect(string url) {
		WWW www = new WWW(url);
		
		yield return www;
		
		JSONObject json = new JSONObject(www.text);
		JSONObject id = json.GetField("id");
		
		print("id is " + id.str);
	}
}