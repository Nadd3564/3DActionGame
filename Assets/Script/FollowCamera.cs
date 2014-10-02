using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class FollowCamera : MonoBehaviour, ICameraController {
		public Transform lookTarget;
		public Vector3 offset = Vector3.zero;
		public FollowCameraController controller;
		InputManager inputManager;
		
		public void OnEnable() {
			controller.SetCameraController (this);
		}

		void Start () {
			FindInputComponent ();
		}

		void LateUpdate(){
			if(inputManager.Moved()){
				float anglePerPixel = controller.GetRotAngle() / (float)Screen.width;
				Vector2 delta = inputManager.GetDeltaPosition();
				controller.SetUpHorizontalAngle(delta.x * anglePerPixel);
				controller.SetHorizontalAngle(Mathf.Repeat(controller.GetHorizontalAngle(), 360.0f));
				controller.SetDownVerticalAngle(delta.y * anglePerPixel);
				controller.SetVerticalAngle(Mathf.Clamp(controller.GetVerticalAngle(), -60.0f, 60.0f));
			}



			if(lookTarget != null){
				Vector3 lookPosition = lookTarget.position + offset;
				Vector3 relativePos = Quaternion.Euler(controller.GetVerticalAngle(), controller.GetHorizontalAngle(), 0) * new Vector3(0,0,-controller.GetDistance());
				transform.position = lookPosition + relativePos;
				transform.LookAt(lookPosition);
				RaycastHit hitInfo;
				if(Physics.Linecast(lookPosition, transform.position, out hitInfo, 1<<LayerMask.NameToLayer("Ground")))
					transform.position = hitInfo.point;
			}
		}

		public void FindInputComponent(){
			this.inputManager = FindObjectOfType<InputManager> ();
		}
	}
}