using UnityEngine;
using System;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern{
	public class MatterAccessor{
		public interface IMatter {
			string Request ( );
		}
		
		private class Matter {
			public string Request( ) {
				return "matter Request " + "Application start\n";
			}
		}


		public class AuthenticateProxy : IMatter {
			// 認証プロキシ
			private Matter matter;
			private string id;
			private string password;


			public string GetId(){
				return this.id;		
			}

			public string GetPass(){
				return this.password;		
			}

			public void SetId(string suppliedId){
				this.id = suppliedId;		
			}

			public void SetPass(string suppliedPass){
				this.password = suppliedPass;		
			}

			public bool IsNullIdWithPass(string passid){
				if (passid == null)
					return true;
				return false;
			}
			public bool IsNullMatter(){
				if (matter == null)
					return true;
				return false;
			}

			public string MatterRequest(){
				if (IsNullIdWithPass(this.id))
					return "AuthenticateProxy: can not access";
				else if(IsNullIdWithPass(this.password))
					return "AuthenticateProxy: can not access";
				else
					matter = new Matter( );
				return "AuthenticateProxy: Success Authenticated";	
			}

			public string Authenticate (string suppliedId, string suppliedPass) {
				SetId (suppliedId);
				//テスト中のため、ログを表示
				Debug.Log ("ID : " + id);

				SetPass (suppliedPass);
				//テスト中のため、ログを表示
				Debug.Log ("Pass : " + password);

				return MatterRequest ();
			}
			
			public string Request( ) {
				if (IsNullMatter())
					return "AuthenticateProxy: The Method Must Authentication";
				else 
					return "AuthenticateProxy: " + matter.Request( );
			}

		}
	}

}