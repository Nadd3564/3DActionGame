using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class FollowCamera : MonoBehaviour, ICameraController {
		public Transform lookTarget;
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
			//ドラッグ入力でカメラのアングルを更新
			controller.MoveAngle ();

			//カメラの位置と回転を更新
			controller.CameraPosUpdate ();
		}

		public void FindInputComponent(){
			this.inputManager = FindObjectOfType<InputManager> ();
		}

		public bool Moved(){
			return this.inputManager.Moved ();	
		}

		public bool NotNullLookTarget(){
			if (lookTarget != null)
								return true;
			return false;
		}

		public void LookAtTrans(){
			this.transform.LookAt(controller.GetLookPosition());
		}

		//スライド時のカーソル移動量
		public void Delta(){
			controller.delta = inputManager.GetDeltaPosition();
		}

		public void Look(){
			controller.lookPosition = lookTarget.position + controller.GetOffSet();
		}

		//注視対象の位置にオフセットを加算した位置へ移動させる
		public void SetPosition(){
			this.transform.position = controller.GetLookPosition() + controller.GetRelativePos();
		}

		public void SetHitInfo(Vector3 hitInfo){
			this.transform.position = hitInfo;	
		}

		//障害物を避ける
		public void AvoidObstacle(){
			RaycastHit hitInfo;
			if (Physics.Linecast (controller.GetLookPosition(), transform.position, out hitInfo, 1 << LayerMask.NameToLayer ("Ground")))
				SetHitInfo (hitInfo.point);
		}

	}
}