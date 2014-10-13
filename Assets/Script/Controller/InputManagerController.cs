using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class InputManagerController
	{
		private Vector2 slideStartPosition;
		private Vector2 prevPosition;
		private Vector2 delta = Vector2.zero;
		private bool moved = false;
		
		private IInputController inputController;
		
		public InputManagerController (){
		
		}

		public Vector2 GetSlideStartPosition(){
			return this.slideStartPosition;		
		}

		public string getSlideStartPosition(){
			string s = GetSlideStartPosition().ToString ();
			return s;
		}

		public Vector2 GetPrevPosition(){
			return this.prevPosition;		
		}
		
		public string getPrevPosition(){
			string s = GetPrevPosition().ToString ();
			return s;
		}

		public Vector2 GetDeltaPosition(){
			return this.delta;
		}

		public string getDeltaPosition(){
			string s = GetDeltaPosition().ToString ();
			return s;
		}

		public bool IsMoved(){
			return this.moved;
		}
		
		public bool SetMoved(bool flg){
			return this.moved = flg;	
		} 
		
		public void SetSlideStartPosition(){
			this.slideStartPosition = IsGetCursorPosition ();		
		}

		public void GetDeltaDistance(){
			//移動量を求める
			this.delta = IsGetCursorPosition () - this.prevPosition;		
		}

		public void StayDelta(){
			this.delta = Vector2.zero;	
		}

		public void PrevPosition(){
			//カーソル位置を更新
			this.prevPosition = IsGetCursorPosition ();		
		}

		public Vector2 IsGetCursorPosition()
		{
			return Input.mousePosition;
		}



		public bool IsClicking(){
			if (!IsMoved() && inputController.InputGetButtonUpFire1() || inputController.InputGetButtonFire1())
				return true;
			else
				return false;
		}


		//スライド開始地点
		public void SlideStart(){
					if (inputController.InputGetButtonDown())
							SetSlideStartPosition ();
				}

		//画面の一割以上移動させたらスライド開始
		public void Sliding()
		{
			if (inputController.InputGetButton()) {
							SlidingCursor();
			}
		}

		public void SlidingCursor(){
			if (Vector2.Distance (GetSlideStartPosition (), IsGetCursorPosition ())
			    >= (Screen.width * 0.1f))
				SetMoved (true);
		}

		//移動量を求める
		public void Moved(){
					if (IsMoved ())
							GetDeltaDistance ();
					else
							StayDelta ();		
		}

		//スライド操作が終了したか
		public void StopSlide(){
			if (inputController.InputGetButtonUp() && !inputController.InputGetButton())
						SetMoved (false);
		}

		public void SetInputController(IInputController inputController) {
			this.inputController = inputController;
		}

	}
}