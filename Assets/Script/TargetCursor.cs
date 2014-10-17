using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class TargetCursor : MonoBehaviour, ICursorController {
		// 目的地
		public TargetCursorController controller;

		public void OnEnable() {
			controller.SetCursorController (this);
		}

	
		void Start(){
			//初期位置を目的地に設定
			SetPosition (transform.position);
			controller.SetDest ();
		}
		
		void Update () {
			controller.SetUpPosition ();
			//回転速度
			controller.SetUpAngle (controller.SetAngularVelocity(Time.deltaTime));
			//相対位置
			controller.OffSet ();
			//エフェクトの位置
			EffectPosition ();
		}


		//位置を設定する
		public void SetPosition(Vector3 iPosition) {
			controller.destination = iPosition;
			//高さを固定
			controller.destination.y = 0.5F;
		}

		public void EffectPosition(){
			this.transform.localPosition = controller.GetPosition() + controller.GetOffSet();
		}
	}
}