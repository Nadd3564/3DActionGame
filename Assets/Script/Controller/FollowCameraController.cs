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
		public float anglePerPixel;
		private ICameraController cameraController;

		
		public FollowCameraController (){
			
		}

		public float GetAnglePerPixel(){
			return this.anglePerPixel;		
		}

		//１ピクセル移動した時の回転速度
		public void SetAnglePerPixel(){
			this.anglePerPixel = GetRotAngle() / (float)Screen.width;		
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

		public void SetHorizontalAngle(){
			this.horizontalAngle = Mathf.Repeat(GetHorizontalAngle(), 360.0f);		
		}

		public float SetUpHorizontalAngle(float f){
			return this.horizontalAngle += f;		
		}

		public float GetVerticalAngle(){
			return this.verticalAngle;		
		}

		public void SetVerticalAngle(){
			this.verticalAngle = Mathf.Clamp(GetVerticalAngle(), -60.0f, 60.0f);		
		}

		public float SetDownVerticalAngle(float f){
			return this.verticalAngle -= f;		
		}

		public void SetCameraController(ICameraController cameraController) {
			this.cameraController = cameraController;
		}
		
	}
}