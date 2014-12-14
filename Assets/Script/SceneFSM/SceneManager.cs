using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;


namespace Cradle.DesignPattern{
	public class SceneManager : MonoBehaviour, IManagerController
	{
		// タイトル画面テクスチャ
		public Texture2D bg;
		// 現在のゲームの状態を保持
		private ISceneState activeState;

		public static SceneManager instance;
	
		public SceneManagerController managerCtrl;
		
		public void OnEnable() {
			managerCtrl.SetManagerController (this);
		}

		void Awake()
		{
			//Singleton
			if(IsNullInstance()) {
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
			//managerCtrl.GetActiveState ().Render ();
			
			//タイトル画面gui破棄
			DestroyTitleGui ();
		}
		
		void Start()
		{
			//状態の初期化
			InitState ();
			//managerCtrl.InitState (this);
		}
		
		void Update()
		{
			//状態の更新
			ActiveState ();
			//managerCtrl.GetActiveState ();

			//認証ゲームオブジェクト破棄
			DestroyAuthentication ();

			//BGMゲームオブジェクト破棄
			DestroyBGM ();
		}


		public ISceneState GetActiveState(){
			return this.activeState;		
		}

		public Texture2D GetBgTexture(){
			return this.bg;
		}
		
		void SetInstance(){
			instance = this;
		}

		public void InitState(){
			activeState = new TitleState(this);
		}

		//状態の更新
		public void ActiveState(){
			if(IsNotNullState())
				activeState.StateUpdate();
				//managerCtrl.GetActiveState().StateUpdate();
		}

		//タイトル画面gui破棄
		public void DestroyTitleGui(){
			if(IsNotLogInScene()){
				string controlName = gameObject.GetHashCode ().ToString ();
				GUI.SetNextControlName ("MyPassField");
				Rect bounds = new Rect (0, 0, 0, 0);
				GUI.TextField (bounds, "", 0);
			}
		}

		//認証ゲームオブジェクト破棄
		public void DestroyAuthentication(){
			if(IsNotLogInScene())
			Destroy (GameObject.Find("New Game Object"));	
		}

		//BGMゲームオブジェクト破棄
		public void DestroyBGM(){
			if(IsPlayScene())
				Destroy(GameObject.Find("BGM"));
		}


		public bool IsNotLogInScene(){
			if(Application.loadedLevelName != "LogInScene")		
				return true;
			return false;
		}

		public bool IsPlayScene(){
			if(Application.loadedLevelName == "PlayScene")
				return true;
			return false;
		}

		public bool IsNullInstance(){
			if(instance == null)
				return true;
			return false;
		}


		public bool IsNotNullState(){
			if(activeState != null)
			//if(managerCtrl.GetActiveState() != null)
				return true;
			return false;
		}
		
		public void SwitchState(ISceneState newState) 
		{
			activeState = newState;
			//managerCtrl.SwitchState (newState);
		}

	}
	
}