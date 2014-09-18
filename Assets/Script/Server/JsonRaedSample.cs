using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class JsonReadSample : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GetJSON();
	}
	
	void GetJSON(){
		// JSONフォーマットデータを文字列として、文字列変数「json」に保持
		string json = "["+
			"{"+
				"\"name\":\"son\","+
				"\"age\":21,"+
				"\"hobby\":[\"baseball\",\"car\"]"+
				"},"+
				"{"+ 
				"\"name\":\"daughter\","+
				"\"age\":18,"+
				"\"hobby\":[\"shopping\",\"tv game\"]"+
				"},"+
				"{"+ 
				"\"name\":\"daddy\","+
				"\"age\":42,"+
				"\"hobby\":[\"car\",\"fishing\"]"+
				"}"+
				"]";
		// JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
		IList familyList = (IList)Json.Deserialize(json);
		// リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
		foreach(IDictionary person in familyList){
			// nameは文字列なので、文字列型へキャストしてから変数へ格納
			string name = (string)person["name"];
			Debug.Log("name:"+name);
			// ageは整数型なので、long型にキャストしてから変数へ格納
			long age = (long)person["age"];
			Debug.Log("age:"+age);
			// hobbyは配列なので、リストにキャストしてから、変数へ格納
			IList hobbes = (IList)person["hobby"];
			// 配列の内容は文字列なので、文字列変数に一つ一つ代入しながら、処理
			foreach(string hobby in hobbes){
				Debug.Log("hobby:"+hobby);
			}
		}
	}
}