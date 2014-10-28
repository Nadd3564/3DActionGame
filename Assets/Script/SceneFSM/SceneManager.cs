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
			activeState.Render();
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

		//認証ゲームオブジェクト破棄
		public void DestroyAuthentication(){
		if (Application.loadedLevelName != "LogInScene")
			Destroy (GameObject.Find("New Game Object"));	
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