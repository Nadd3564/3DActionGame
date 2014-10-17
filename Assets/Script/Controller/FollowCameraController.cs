using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class FollowCameraController
	{
		public Vector3 offset = Vector3.zero;
		public Vector3 lookPosition;
		public Vector3 relativePos;
		public Vector2 delta;
		public float distance = 5.0f;
		public float horizontalAngle = 180.0f;
		public float rotAngle = 180.0f;
		public float verticalAngle = 10.0f;
		public float anglePerPixel;
		private ICameraController cameraController;

		
		public FollowCameraController (){
		
		}


		public Vector3 GetOffSet(){
			return this.offset;
		}

		public string getOffSet(){
			string s = GetOffSet().ToString ();
			return s;	
		}

		public Vector3 GetLookPosition(){
			return this.lookPosition;	
		}

		public string getLookPosition(){
			string s = GetLookPosition().ToString ();
			return s;	
		}

		public Vector3 GetRelativePos(){
			return this.relativePos;	
		}

		public string getRelativePos(){
			string s = GetRelativePos().ToString ();
			return s;	
		}

		public Vector2 GetDelta(){
			return this.delta;	
		}

		public string getDelta(){
			string s = GetDelta().ToString ();
			return s;	
		}

		public virtual float GetAnglePerPixel(){
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

		//注視対象からの相対位置を求める
		//relativePos = 0,0,-GetDistance()を原点中心にx軸にGetVerticalAngle()度、y軸にGetHorizontalAngle度回転させた時の位置
		public void RelativePos(){
			this.relativePos = Quaternion.Euler(GetVerticalAngle(), GetHorizontalAngle(), 0) * new Vector3(0,0,-GetDistance());
		}

		//ドラッグ入力でカメラのアングルを更新
		public bool MoveAngle(){
			if (!cameraController.Moved ())
								return false;

			if(cameraController.Moved()){
				if(GetAnglePerPixel() < 0.0f)
					throw new ArgumentOutOfRangeException("The AnglePerPixel Must Be Positive.", default(Exception));

				//１ピクセル移動した時の回転速度
				SetAnglePerPixel();
				
				//スライド時のカーソル移動量
				cameraController.Delta();

				SetUpHorizontalAngle(GetDelta ().x * GetAnglePerPixel());
				SetHorizontalAngle();
				SetDownVerticalAngle(GetDelta ().y * GetAnglePerPixel());
				SetVerticalAngle();
			}
			return true;
		}

		//カメラの位置と回転を更新
		public bool CameraPosUpdate(){
			if (!cameraController.NotNullLookTarget())
				return false;

			if(cameraController.NotNullLookTarget()){
				cameraController.Look();
				
				//注視対象からの相対位置を求める
				RelativePos();
				
				//注視対象の位置にオフセットを加算した位置へ移動させる
				cameraController.SetPosition();
				
				//transform.LookAt(controller.GetLookPosition());
				cameraController.LookAtTrans();

				//障害物を避ける
				cameraController.AvoidObstacle();
			}
			return true;
		}


		public void SetCameraController(ICameraController cameraController) {
			this.cameraController = cameraController;
		}
		
	}
}