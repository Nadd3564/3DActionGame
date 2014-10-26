using UnityEngine;
using System;
using System.Collections.Generic;
using Cradle;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern{
public class LogIn : AccountManager {

	// Use this for initialization
	void StartUp () {

		}

	// Update is called once per frame
	void Main () {
			MySpaceBook me = new MySpaceBook ();
			me.Add("こんにちは");
			me.Add("今日は１５時間プログラミングを教えました");
			Debug.Log ("Success : " + me);
			
			MySpaceBook jiro = new MySpaceBook ();
			jiro.Comment("taro");
			jiro.Add("taro","自分は１９時間♪");
			jiro.Add("じゃあ、今から花火見に行ってくる");
			Debug.Log ("Success : " + jiro);
	}

}
}