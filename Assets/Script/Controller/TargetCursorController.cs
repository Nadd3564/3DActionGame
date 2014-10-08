using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class TargetCursorController
	{
		// 半径
		public float radius = 1.0f;
		// 回転速度
		public float angularVelocity = 480.0f;
		// 角度
		public float angle = 0.0f;

		private ICursorController cursorController;
		
		
		public TargetCursorController(){
			
		}

		public float GetAngle(){
			return this.angle;	
		}

		public float GetRadius(){
			return this.radius;	
		}

		public void SetUpAngle(float f){
			this.angle += f;	
		}

		public float SetAngularVelocity(float f){
			return this.angularVelocity * f;	
		}

		public void SetCursorController(ICursorController cursorController) {
			this.cursorController = cursorController;
		}
		
	}
}