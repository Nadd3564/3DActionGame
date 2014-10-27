using UnityEngine;
using System.Collections;

namespace Cradle{
	public class ContinueBGM : MonoBehaviour {

			private static ContinueBGM instance = null;

			public static ContinueBGM Instance {
				get { return instance; }
			}

			void Awake() {

			if (DestroyBGM()) {
					Destroy(this.gameObject);
					return;
				} else {
					SetBGM();
				}
				DontDestroyOnLoad(this.gameObject);
			}

		void SetBGM(){
			instance = this;	
		}

		public bool DestroyBGM(){
			if(IsNotNullBGM() && IsNotBGM())	
				return true;
			return false;
		}

		public bool IsNotNullBGM(){
			if(instance != null)
				return true;
			return false;
		}

		public bool IsNotBGM(){
			if(instance != this)
				return true;
			return false;
		}

		}
}
 