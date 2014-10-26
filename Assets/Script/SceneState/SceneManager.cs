using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern{
	public class SceneManager : MonoBehaviour
	{
		// タイトル画面テクスチャ
		public Texture2D bg;
		// 現在のゲームの状態を保持
		private ISceneState activeState;

		public static SceneManager instance;
	

		public Texture2D GetBgTexture(){
			return this.bg;
		}

	
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
			if(NotNullState())
				activeState.StateUpdate();
		}


		void SetInstance(){
			instance = this;
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