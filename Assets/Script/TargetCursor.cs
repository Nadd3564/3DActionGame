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
			SetPosition (this.transform.position);
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

		public void SetPosition(Vector3 iPosition) {
			//位置を設定する
			controller.SetDestination (iPosition);
			//高さを固定
			controller.SetDestinationY (0.5f);
		}

		public void EffectPosition(){
			this.transform.localPosition = controller.GetPosition() + controller.GetOffSet();
		}
	}
}