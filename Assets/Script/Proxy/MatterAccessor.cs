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
			Matter matter;
			private string id;
			private string password;


			public string GetId(){
				return this.id;		
			}

			public string GetPass(){
				return this.password;		
			}

			public string Authenticate (string suppliedId, string suppliedPass) {
				this.id = suppliedId;
				Debug.Log ("ID : " + id);
				this.password = suppliedPass;
				Debug.Log ("Pass : " + password);
				if (this.id != id)
					return "AuthenticateProxy: can not access";
				else if(this.password != password)
					return "AuthenticateProxy: can not access";
				else
					matter = new Matter( );
				return "AuthenticateProxy: Success Authenticated";
			}
			
			public string Request( ) {
				if (matter == null)
					return "AuthenticateProxy: The Method Must Authentication";
				else return "AuthenticateProxy: " + matter.Request( );
			}

		}
	}

}