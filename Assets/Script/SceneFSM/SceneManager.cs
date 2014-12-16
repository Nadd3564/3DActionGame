using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;


namespace Cradle.DesignPattern{
	public class SceneManager : MonoBehaviour, IManagerController
	{
		// タイトル画面テクスチャ
		public Texture2D bg;
		public static SceneManager instance;
	
		public SceneManagerController managerCtrl;


		public void OnEnable() {
			managerCtrl.SetManagerController (this);
		}


		void Awake()
		{
			//Singleton
			if(managerCtrl.IsNullInstance()) {
				managerCtrl.SetInstance(this);
				DontDestroyOnLoad(gameObject);
			} else {
				DestroyImmediate(gameObject);
			}

		}


		void OnGUI()
		{
			//描画状態更新
			managerCtrl.GetActiveState ().Render ();
			
			//タイトル画面gui破棄
			OverrideTitleGui ();
		}
		
		void Start()
		{
			//状態の初期化
			managerCtrl.InitState (this);
		}
		
		void Update()
		{
			//状態の更新
			managerCtrl.ActiveState ();

			//認証ゲームオブジェクト破棄
			DestroyAuthentication ();

			//BGMゲームオブジェクト破棄
			DestroyBGM ();
		}


		public Texture2D GetBgTexture(){
			return this.bg;
		}

		//タイトル画面gui上書き
		public void OverrideTitleGui(){
			if(managerCtrl.IsNotLogInScene()){
				string controlName = gameObject.GetHashCode ().ToString ();
				GUI.SetNextControlName ("MyPassField");
				Rect bounds = new Rect (0, 0, 0, 0);
				GUI.TextField (bounds, "", 0);
			}
		}

		//認証ゲームオブジェクト破棄
		public void DestroyAuthentication(){
			if(managerCtrl.IsNotLogInScene())
			Destroy (GameObject.Find("New Game Object"));	
		}

		//BGMゲームオブジェクト破棄
		public void DestroyBGM(){
			if(managerCtrl.IsPlayScene())
				Destroy(GameObject.Find("BGM"));
		}

		//次の状態へ遷移
		public void SwitchState(ISceneState newState) 
		{
			managerCtrl.SwitchState (newState);
		}

	}
	
}