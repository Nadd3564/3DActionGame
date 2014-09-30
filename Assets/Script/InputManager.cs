﻿using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
	public class InputManager : MonoBehaviour, IInputController {
		
		public InputManagerController inputController;
		
		public void OnEnable() {
			inputController.SetInputController (this);
		}
		
		void Update () {
			//スライド開始地点
			inputController.SlideStart ();				
			
			//画面の一割以上移動させたらスライド開始
			inputController.Sliding ();
			
			//スライド操作が終了したか
			inputController.StopSlide ();
			
			//移動量を求める
			inputController.Moved ();
			
			//カーソル位置を更新
			inputController.PrevPosition ();
		}
		
		//クリックされたか
		public bool Clicked(){
			return inputController.IsClicked ();		
		}
		
		//スライド時のカーソルの移動量
		public Vector2 GetDeltaPosition(){
			return inputController.IsGetDeltaPosition();
		}
		
		//スライド中か
		public bool Moved(){
			return inputController.IsMoved();
		}
		
		public Vector2 GetCursorPosition()
		{
			return inputController.IsGetCursorPosition();
		}
		
	}
}
