using UnityEngine;
using System;
using System.Collections;
using Cradle;
using Cradle.Resource;

namespace Cradle{

public class CharaMove : MonoBehaviour, IMoveController {
		CharacterController characterController; 
		public CharaMoveController cMcontroller;

		public void OnEnable() {
			cMcontroller.SetMoveController (this);
		}
	
		void Start () {
			FindCharacterControllerComponent ();
			SetDest ();
		}
	

		void Update () {
			//移動に関する総合処理
			try{
				cMcontroller.MoveManagement (transform.position.y,
				                             Vector3.Distance(transform.position,cMcontroller.GetDestinationXZ()));
			} catch(ArgumentOutOfRangeException e){
				Debug.Log("SaveExceptionLog : " + e);
				TextReadWriteManager write = new TextReadWriteManager();
				write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
			}


			//重力
			cMcontroller.SetGravityAcceleration ();

			//接地時地面に押し付ける
			cMcontroller.SnapZero ();

			//CharacterControllerを使って動かす
			characterController.Move(cMcontroller.GetVelocity() * Time.deltaTime+cMcontroller.GetSnapGround());
			cMcontroller.WalkStop ();

			//強制的に向きを変えるのを解除
			ForceRotateCancel ();
		}

		public void FindCharacterControllerComponent(){
			this.characterController = GetComponent<CharacterController>();
		}

		void SetDest(){
			cMcontroller.destination = transform.position;
		}

		//目的地への方向を求める
		public void DirectionSeek(){
			cMcontroller.direction = (cMcontroller.GetDestinationXZ() - transform.position).normalized;
		}

		public void SetTransFormRot(){
			this.transform.rotation = Quaternion.RotateTowards(transform.rotation,cMcontroller.GetCharacterTargetRot(),cMcontroller.GetRotationSpeed() * Time.deltaTime);
		}

		public bool IsGrounded(){
			if (characterController.isGrounded)
				return true;
			return false;
		}

		public bool LessThanVMagnitude(){
			if (characterController.velocity.magnitude < 0.1f)
								return true;
			return false;
		} 

		void ForceRotateCancel(){
			if (cMcontroller.IsForceRotate () && Vector3.Dot (transform.forward, cMcontroller.GetForceRotateDirection()) > 0.99f)
				cMcontroller.SetForceRotate (false);
		}
	
		//目的地を指定する（引数が目的地）
		public void SetDestination(Vector3 destination)
		{
			cMcontroller.SetDestination (destination);
		}
	
		//指定した向きを向かせる
		public void SetDirection(Vector3 direction)
		{
			cMcontroller.SetDirection (direction);
		}

		public void StopMove()
		{
			cMcontroller.destination = transform.position;
		}

		//目的地に到着したかを調べる
		public bool Arrived()
		{
			return cMcontroller.IsArrived();
		}

	}
}