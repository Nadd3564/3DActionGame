using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.FM;

namespace Cradle{
public class GameRuleSettings : MonoBehaviour, IRuleController {
			public AudioClip clearSeClip;
			AudioSource clearSeAudio;
			public GameRuleSettingsController controller;
			
			
			public void OnEnable() {
				controller.SetRuleController (this);
			}

			void Awake(){
				Destroy (GameObject.Find("BGM"));	
			}

			//前SceneのGuiを破棄
			void OnGUI()
			{
				string controlName = gameObject.GetHashCode ().ToString ();
				GUI.SetNextControlName ("MyPassField");
				Rect bounds = new Rect (0, 0, 0, 0);
				GUI.TextField (bounds, "", 0);
			}

			void Start(){
					//ゲームスピード初期化
					controller.InitializeGameSpeed ();
					//オーディオの初期化
					FindAudioComponent ();
					DisableLoopSE ();
					ClipSE ();
			}


			void Update () {
				//ゲームオーバー、クリア後、タイトルへ
				controller.ReturnTitle ();
			}

			public void GameOver(){
				controller.SetGameOver (true);
				Debug.Log ("GameOver");
			}

			public void GameClear(){
				controller.SetGameClear (true);
				Debug.Log ("GameClear");
				PlaySE ();
			}

			public void FindAudioComponent(){
				this.clearSeAudio = gameObject.AddComponent<AudioSource>();
			}

			public void DisableLoopSE(){
				this.clearSeAudio.loop = false;
			}

			public void ClipSE(){
				this.clearSeAudio.clip = clearSeClip;
			}

			public void PlaySE(){
				this.clearSeAudio.Play ();
			}

		}
}