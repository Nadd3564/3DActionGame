using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class TargetCursor : MonoBehaviour, ICursorController {
		// 目的地
		public Vector3 destination = new Vector3( 0.0f, 0.5f, 0.0f );
		Vector3 position = new Vector3( 0.0f, 0.5f, 0.0f );
		Vector3 offset;
		public TargetCursorController controller;

		public void OnEnable() {
			controller.SetCursorController (this);
		}

	
		void Start(){
			//初期位置を目的地に設定
			SetPosition (transform.position);
			SetDest ();
		}
		
		void Update () {
			SetUpPosition ();
			//回転速度
			controller.SetUpAngle (controller.SetAngularVelocity(Time.deltaTime));
			//相対位置
			OffSet ();
			//エフェクトの位置
			EffectPosition ();
		}

		public void SetPosition(Vector3 iPosition) {
			destination = iPosition;
			//高さを固定
			destination.y = 0.5F;
		}

		public void SetUpPosition(){
			this.position += ( destination - position ) / 10.0f;	
		}

		public void SetDest(){
			this.position = destination;
		}

		public void OffSet(){
			this.offset = Quaternion.Euler (0.0f, controller.GetAngle(), 0.0f) * new Vector3 (0.0f, 0.0f, controller.GetRadius() );
		}

		public void EffectPosition(){
			this.transform.localPosition = position + offset;
			controller.CalcBoostTime ();
		}
	}
}