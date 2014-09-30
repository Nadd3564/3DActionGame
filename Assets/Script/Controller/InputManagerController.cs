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
		private float calcTime = 0.0f;
		
		private IInputController inputController;
		
		public InputManagerController (){
		
		}

		public Vector2 GetSlideStartPosition(){
			return this.slideStartPosition;		
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

		public Vector2 GetPrevPosition(){
			return this.prevPosition;		
		}

		public void PrevPosition(){
			//カーソル位置を更新
			this.prevPosition = IsGetCursorPosition ();		
		}

		public Vector2 IsGetCursorPosition()
		{
			return Input.mousePosition;
		}

		public Vector2 IsGetDeltaPosition(){
			return this.delta;
		}

		public bool IsClicked(){
			return IsClicking ();
		}

		public bool IsClicking(){
			if (!IsMoved() && InputGetButtonUpFire1() || InputGetButtonFire1())
				return true;
			else
				return false;
		}


		//スライド開始地点
		public void SlideStart(){
					if (InputGetButtonDown())
							SetSlideStartPosition ();
							CalcBoostTime ();
				}

		//画面の一割以上移動させたらスライド開始
		public void Sliding()
		{
					if (InputGetButton()) {
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
			if (InputGetButtonUp() && !InputGetButton())
						SetMoved (false);
		}

		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}

		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}

		public void SetInputController(IInputController inputController) {
			this.inputController = inputController;
		}

		public bool InputGetButtonFire1(){
			return Input.GetButton("Fire1");		
		}
		
		public bool InputGetButtonUpFire1(){
			return Input.GetButtonUp("Fire1");		
		}
		
		public bool InputTestGetButtonFire1(){
			return InputGetButtonFire1 ();		
		}
		
		public bool InputTestGetButtonUpFire1(){
			return InputGetButtonUpFire1 ();		
		}
		
		public bool InputGetButton(){
			return Input.GetButton("Fire2");		
		}
		
		public bool InputGetButtonDown(){
			return Input.GetButtonDown("Fire2");		
		}
		
		public bool InputGetButtonUp(){
			return Input.GetButtonUp("Fire2");		
		}
		
		public bool InputTestGetButton(){
			return InputGetButtonDown();		
		}
		
		public bool InputTestGetButtonDown(){
			return InputGetButtonDown();		
		}
		
		public bool InputTestGetButtonUp(){
			return InputGetButtonUp();		
		}
		
	}
}