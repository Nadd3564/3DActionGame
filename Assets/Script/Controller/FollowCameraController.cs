using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class FollowCameraController
	{
		public float distance = 5.0f;
		public float horizontalAngle = 0.0f;
		public float rotAngle = 180.0f;
		public float verticalAngle = 10.0f;
		private float calcTime = 0.0f;
		private ICameraController cameraController;
		
		public FollowCameraController (){
			
		}
		
		public float GetDistance(){
			return this.distance;		
		}

		public float GetRotAngle(){
			return this.rotAngle;		
		}

		public float GetHorizontalAngle(){
			return this.horizontalAngle;		
		}

		public float SetHorizontalAngle(float f){
			return this.horizontalAngle = f;		
		}

		public float SetUpHorizontalAngle(float f){
			return this.horizontalAngle += f;		
		}

		public float GetVerticalAngle(){
			return this.verticalAngle;		
		}

		public float SetVerticalAngle(float f){
			return this.verticalAngle = f;		
		}

		public float SetDownVerticalAngle(float f){
			return this.verticalAngle -= f;		
		}
		
		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void SetCameraController(ICameraController cameraController) {
			this.cameraController = cameraController;
		}
		
	}
}