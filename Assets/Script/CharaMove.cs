using UnityEngine;
using System.Collections;
using Cradle;

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
			IsGrounded ();

			//重力
			cMcontroller.SetGravityAcceleration ();

			//接地時地面に押し付ける
			cMcontroller.SnapZero ();

			//CharacterControllerを使って動かす
			characterController.Move(cMcontroller.GetVelocity() * Time.deltaTime+cMcontroller.GetSnapGround());
			WalkStop ();

			//強制的に向きを変えるのを解除
			ForceRotateCancel ();
		}

		public void FindCharacterControllerComponent(){
			this.characterController = GetComponent<CharacterController>();
		}

		void SetDest(){
			cMcontroller.destination = transform.position;
		}

		void SetDestAlign(){
			cMcontroller.destinationXZ.y = transform.position.y;
		}

		//目的地への方向を求める
		void DirectionSeek(){
			cMcontroller.direction = (cMcontroller.GetDestinationXZ() - transform.position).normalized;
		}

		void SetTargetRotation(Quaternion q){
			cMcontroller.characterTargetRotation = q;
		}

		void SetTransFormRotation(Quaternion q){
			this.transform.rotation = q;
		}

		//移動速度を求める
		void WalkSpeedVelocity(){
			if (cMcontroller.IsArrived ())
								cMcontroller.SetVelocityZero ();
						else 
								cMcontroller.SetWalkSpdVelocity ();
		}


		public void WalkRotation(){
			if (!cMcontroller.IsForceRotate()) 
			{
				//行きたい方向へ向く
				if (cMcontroller.WalkRotateCondition()) 
				{ 
					SetTargetRotation(Quaternion.LookRotation(cMcontroller.GetDirection()));
					SetTransFormRotation(Quaternion.RotateTowards(transform.rotation,cMcontroller.GetCharacterTargetRot(),cMcontroller.GetRotationSpeed() * Time.deltaTime));
				}
			}
			else 
			{
				//強制向き指定
					SetTargetRotation(Quaternion.LookRotation(cMcontroller.GetForceRotateDirection()));
					SetTransFormRotation(Quaternion.RotateTowards(transform.rotation,cMcontroller.GetCharacterTargetRot(),cMcontroller.GetRotationSpeed() * Time.deltaTime));
			}
		}

		//移動に関する総合処理
		public void IsGrounded(){
			if (characterController.isGrounded) {
				//水平面移動のみなのでXZを扱う
				cMcontroller.SetDestXZ();

				//高さを目的地と現在と合わせる
				SetDestAlign();

				//目的地への方向を求める
				DirectionSeek();

				//目的地への距離を求める
				cMcontroller.SetDistance(Vector3.Distance(transform.position,cMcontroller.GetDestinationXZ()));

				//現在の速度を退避
				cMcontroller.SetCurrentVelocity();

				//目的に近づいたら到着
				cMcontroller.DestArrived();

				//移動速度を求める
				WalkSpeedVelocity();

				//スムーズに動くよう補間
				cMcontroller.SmoothVelocity();
				cMcontroller.SetVelocityY();

				//向きを行きたい方向へ向ける
				WalkRotation();

				//接地していたら地面に押し付ける
				cMcontroller.SnapDown();
			}
		}

		void WalkStop(){
			if (characterController.velocity.magnitude < 0.1f)
				cMcontroller.SetArrived (true);
		}

		void ForceRotateCancel(){
			if (cMcontroller.IsForceRotate () && Vector3.Dot (transform.forward, cMcontroller.GetForceRotateDirection()) > 0.99f)
				cMcontroller.SetForceRotate (false);
		}
	
		//目的地を指定する（引数が目的地）
		public void SetDestination(Vector3 destination)
		{
			cMcontroller.SetArrived (false);
			cMcontroller.destination = destination;
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