using UnityEngine;
using System.Collections;

namespace Cradle{
	public class ContinueBGM : MonoBehaviour {

			private static ContinueBGM instance = null;

			public static ContinueBGM Instance {
				get { return instance; }
			}

			void Awake() {

				if (instance != null && instance != this) {
					Destroy(this.gameObject);
					return;
				} else {
					instance = this;
				}
				DontDestroyOnLoad(this.gameObject);
			}

		}
}
 