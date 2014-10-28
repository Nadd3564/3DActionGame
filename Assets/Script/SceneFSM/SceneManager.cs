using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;
using LitJson;


namespace Cradle.DesignPattern{
	public class SceneManager : MonoBehaviour
	{
		// タイトル画面テクスチャ
		public Texture2D bg;
		private string id;
		private string password;
		private bool ProxyFlg = false;
		// 現在のゲームの状態を保持
		private ISceneState activeState;

		public static SceneManager instance;
	

		void Awake()
		{
			//Singleton
			if(NullInstance()) {
				SetInstance();
				DontDestroyOnLoad(gameObject);
			} else {
				DestroyImmediate(gameObject);
			}

		}

		void OnGUI()
		{
			//描画状態更新
			activeState.Render();

			//タイトル画面gui破棄
			DestroyTitleGui ();
		}
		
		void Start()
		{
			activeState = new TitleState(this);
		}
		
		void Update()
		{
			//状態の更新
			ActiveState ();

			//認証ゲームオブジェクト破棄
			DestroyAuthentication ();

			//BGMゲームオブジェクト破棄
			DestroyBGM ();
		}



		public Texture2D GetBgTexture(){
			return this.bg;
		}
		
		public string GetId(){
			return this.id;
		}
		
		public string GetPass(){
			return this.password;
		}

		public void SetId(string id){
			this.id = id;
		}
		
		public void SetPass(string password){
			this.password = password;
		}
		
		public bool IsProxyFlg(){
			return this.ProxyFlg;	
		}
		
		public void SetProxyFlg(){
			this.ProxyFlg = true;
		}
		
		void SetInstance(){
			instance = this;
		}


		//状態の更新
		public void ActiveState(){
			if(NotNullState())
				activeState.StateUpdate();
		}

		//タイトル画面gui破棄
		public void DestroyTitleGui(){
			if(Application.loadedLevelName != "LogInScene"){
				string controlName = gameObject.GetHashCode ().ToString ();
				GUI.SetNextControlName ("MyPassField");
				Rect bounds = new Rect (0, 0, 0, 0);
				GUI.TextField (bounds, "", 0);
			}
		}

		//認証ゲームオブジェクト破棄
		public void DestroyAuthentication(){
		if (Application.loadedLevelName != "LogInScene")
			Destroy (GameObject.Find("New Game Object"));	
		}

		//BGMゲームオブジェクト破棄
		public void DestroyBGM(){
			if(Application.loadedLevelName == "PlayScene")
				Destroy(GameObject.Find("BGM"));
		}


		public bool NullInstance(){
			if(instance == null)
				return true;
			return false;
		}


		public bool NotNullState(){
			if(activeState != null)
				return true;
			return false;
		}
		
		public void SwitchState(ISceneState newState) 
		{
			activeState = newState;
		}

	}
	
}