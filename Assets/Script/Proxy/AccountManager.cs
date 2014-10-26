using UnityEngine;
using System;
using System.Collections.Generic;
using Cradle;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern{
	public class AccountManager : Inheritance {

		public void StartUp(){
				}

		// Subjectに該当
		private class UserBook {
			static internal SortedList <string,UserBook> community = new SortedList <string,UserBook> (100);
			string pages;
			string name;
			string gap = "\n\t\t\t\t";
			
			static public bool IsUnique (string name) {
				return community.ContainsKey(name);
			}
			
			internal UserBook (string n) {
				name = n;
				community [n] = this;
				Debug.Log("instatiate");
			}

			internal void Add(string s) {
				pages += gap + s;
				Debug.Log(gap+"======== "+name+"'s UserBook =========");
				Debug.Log(pages);
				Debug.Log(gap+"===================================");
			}
			
			internal void Add(string friend, string message) {
				community[friend].Add(message);
				Debug.Log ("UserBook.Add");
			}
			
			internal void Comment(string who, string friend) {
				community[who].pages += gap + friend + "さんが、あなたのSpaceBookにコメントします。";
				Debug.Log ("UserBook.Comment");
			}
		}
		
		// プロキシに該当
		public class MyUserBook {
			UserBook myUserBook;
			string password;
			string name;
			bool loggedIn = false;

			LogInSceneCtrl ctrl;

			void Register ( ) {
				Debug.Log("UserBookに登録してください");
				ctrl = FindObjectOfType<LogInSceneCtrl>();
				do {
					Debug.Log("UserBook名は固有となります");
					Console.Write("ユーザー名を入力ください: " + "user");
					name = ctrl.GetID();
					Debug.Log("ユーザ名 : " + name);
				} while (UserBook.IsUnique(name));
				Debug.Log("パスワードを入力してください: ");
			}

			 public void PassRegister (string name) {
				ctrl = FindObjectOfType<LogInSceneCtrl>();

				// パスワードの入力
				password = ctrl.GetPass ();
				Debug.Log("UserBookに登録頂きありがとうございます");
				Authenticate (name);

			}

			bool Authenticate (string name) {
				Debug.Log ("Authenname : " + name);
				Debug.Log("こんにちは、 " + name + "さん。パスワードを入力してください: ");
				ctrl = FindObjectOfType<LogInSceneCtrl>();
				string supplied = ctrl.GetPass ();
				if (supplied == password) {
					loggedIn = true;
					Debug.Log("UserBookにログインしました");
					if (myUserBook == null) myUserBook = new UserBook(name);
					return true;
				}

				Debug.Log("Incorrect password");
				return false;
			}
			
			public void Add(string message) {
				
				Check( );
				if (loggedIn) myUserBook.Add(message);
				Debug.Log ("Add");
			}
			
			public void Add(string friend, string message) {
				Check( );
				if (loggedIn) myUserBook.Add(friend, name + "のコメント: " + message);
			}
			
			public void Comment(string who) {
				Check( );
				if (loggedIn) myUserBook.Comment(who,name);
			}
			
			public void Check( ) {
				if (!loggedIn) {
					if (password == null)
						Register( );
					//if (myUserBook == null) Authenticate( );
					//if (myUserBook == null && password != null) Authenticate( );
			}
		}
	}
}
}