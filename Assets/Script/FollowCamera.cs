using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class FollowCamera : MonoBehaviour, ICameraController {
		public Transform lookTarget;
		public Vector3 offset = Vector3.zero;
		Vector2 delta;
		Vector3 lookPosition;
		Vector3 relativePos;
		InputManager inputManager;
		public FollowCameraController controller;


		public void OnEnable() {
			controller.SetCameraController (this);
		}

		void Start () {
			FindInputComponent ();
		}

		void LateUpdate()
		{				
			MoveAngle ();
			CameraPosUpdate ();
		}

		public void FindInputComponent(){
			this.inputManager = FindObjectOfType<InputManager> ();
		}

		//ドラッグ入力でカメラのアングルを更新
		public void MoveAngle(){
			if(inputManager.Moved()){
				//１ピクセル移動した時の回転速度
				controller.SetAnglePerPixel();

				//スライド時のカーソル移動量
				Delta();

				controller.SetUpHorizontalAngle(delta.x * controller.GetAnglePerPixel());
				controller.SetHorizontalAngle();
				controller.SetDownVerticalAngle(delta.y * controller.GetAnglePerPixel());
				controller.SetVerticalAngle();
				controller.CalcBoostTime();
			}
		}

		//カメラの位置と回転を更新
		public void CameraPosUpdate(){
			if(lookTarget != null){
				Look();
				//注視対象からの相対位置を求める
				RelativePos();

				//注視対象の位置にオフセットを加算した位置へ移動させる
				SetPosition(lookPosition + relativePos);

				transform.LookAt(lookPosition);
				//障害物を避ける
				AvoidObstacle();
			}
		}

		//スライド時のカーソル移動量
		public void Delta(){
			this.delta = inputManager.GetDeltaPosition();
		}

		public void Look(){
			this.lookPosition = lookTarget.position + offset;
		}

		//注視対象からの相対位置を求める
		public void RelativePos(){
			this.relativePos = Quaternion.Euler(controller.GetVerticalAngle(), controller.GetHorizontalAngle(), 0) * new Vector3(0,0,-controller.GetDistance());
		}

		//注視対象の位置にオフセットを加算した位置へ移動させる
		public void SetPosition(Vector3 pos){
			this.transform.position = pos;
		}

		//障害物を避ける
		public void AvoidObstacle(){
			RaycastHit hitInfo;
			if (Physics.Linecast (lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer ("Ground")))
				SetPosition (hitInfo.point);
		}

	}
}