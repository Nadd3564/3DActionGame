using UnityEngine;
using System;
using System.Collections.Generic;
using Cradle;

namespace Cradle.DesignPattern{
public class LogIn {
	
	// Subjectに該当
	//private class SpaceBook {
		public class SpaceBook {
		static SortedList <string,SpaceBook> community = new SortedList <string,SpaceBook> (100);
		string pages;
		string name;
		string gap = "\n\t\t\t\t";
		
		//static public bool IsUnique (string name) {
		static public bool IsUnique (string name) {
			return community.ContainsKey(name);
		}
		
		//internal SpaceBook (string n) {
			public SpaceBook(string n){
			name = n;
			community [n] = this;
		}
		
		internal void Add(string s) {
			pages += gap+s;
			Console.Write(gap+"======== "+name+"'s SpaceBook =========");
			Console.Write(pages);
			Console.WriteLine(gap+"===================================");
		}
		
		internal void Add(string friend, string message) {
			community[friend].Add(message);
		}
		
		internal void Comment(string who, string friend) {
			community[who].pages += gap + friend + "さんが、あなたのSpaceBookにコメントします。";
		}
	}
	
	// プロキシに該当
	public class MySpaceBook {
		
		SpaceBook mySpaceBook;
		LogIn.SpaceBook Space = new LogIn.SpaceBook("a");
		string password;
		string name;
		bool loggedIn = false;
		
		void Register ( ) {
			Console.WriteLine("SpaceBookに登録してください");
			do {
				Console.WriteLine("SpaceBook名は固有となります");
				Console.Write("ユーザー名を入力ください: ");
				name = Console.ReadLine( );
			} while (SpaceBook.IsUnique(name));
			Console.Write("パスワードを入力してください: ");
			// パスワードの入力
			password = Console.ReadLine( );
			Console.WriteLine("SpaceBookに登録頂きありがとうございます");
		}
		
		bool Authenticate ( ) {
			Console.Write("こんにちは、 "+name+"さん。パスワードを入力してください: ");
			string supplied = Console.ReadLine( );
			if (supplied==password) {
				loggedIn = true;
				Console.WriteLine("SpaceBookにログインしました");
				if (mySpaceBook == null) mySpaceBook = new SpaceBook(name);
				return true;
			}
			Console.WriteLine("Incorrect password");
			return false;
		}
		
		public void Add(string message) {
			
			Check( );
			if (loggedIn) mySpaceBook.Add(message);
		}
		
		public void Add(string friend, string message) {
			Check( );
			if (loggedIn) mySpaceBook.Add(friend, name + "のコメント: "+message);
		}
		
		public void Comment(string who) {
			Check( );
			if (loggedIn) mySpaceBook.Comment(who,name);
		}
		
		void Check( ) {
			if (!loggedIn) {
				if (password==null)
					Register( );
				if (mySpaceBook == null) Authenticate( );
			}
		}
	}
}
}