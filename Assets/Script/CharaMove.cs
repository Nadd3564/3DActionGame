using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{

public class CharaMove : MonoBehaviour, IMoveController {
		Vector3 velocity = Vector3.zero; 
		CharacterController characterController; 
		Vector3 forceRotateDirection;
		public Vector3 destination; 
		Vector3 destinationXZ;
		Vector3 direction;
		Vector3 currentVelocity;
		Vector3 snapGround;
		Quaternion characterTargetRotation;
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
			SetGravityAcceleration (Vector3.down * cMcontroller.GetGravityPower() * Time.deltaTime);

			//接地時地面に押し付ける
			SetSnapGround (Vector3.zero);

			//CharacterControllerを使って動かす
			characterController.Move(velocity * Time.deltaTime+snapGround);
			WalkStop ();

			//強制的に向きを変えるのを解除
			ForceRotateCancel ();
		}

		public void FindCharacterControllerComponent(){
			this.characterController = GetComponent<CharacterController>();
		}

		void SetSnapGround(Vector3 snapGround){
			this.snapGround = snapGround;
			cMcontroller.CalcBoostTime ();
		}

		void SetDest(){
			this.destination = transform.position;
		}

		void SetDestXZ(){
			this.destinationXZ = destination; 
		}

		void SetDestAlign(){
			this.destinationXZ.y = transform.position.y;
		}

		//目的地への方向を求める
		void DirectionSeek(){
			this.direction = (destinationXZ - transform.position).normalized;
		}

		void SetVelocity(Vector3 velocity){
			this.velocity = velocity;
		}

		void SetGravityAcceleration(Vector3 velocity){
			this.velocity += velocity;
		}

		void SetVelocityY(float velocity){
			this.velocity.y = velocity;
		}

		void SetCurrentVelocity(){
			this.currentVelocity = velocity;
		}

		void SetTargetRotation(Quaternion q){
			this.characterTargetRotation = q;
		}

		void SetTransFormRotation(Quaternion q){
			this.transform.rotation = q;
		}

		//移動速度を求める
		void WalkSpeedVelocity(){
			if (cMcontroller.IsArrived())
				SetVelocity(Vector3.zero);
			else 
				SetVelocity(direction * cMcontroller.GetWalkSpeed());
		}


		public void WalkRotation(){
			if (!cMcontroller.IsForceRotate()) 
			{
				//行きたい方向へ向く
				if (WalkRotateCondition()) 
				{ 
					SetTargetRotation(Quaternion.LookRotation(direction));
					SetTransFormRotation(Quaternion.RotateTowards(transform.rotation,characterTargetRotation,cMcontroller.GetRotationSpeed() * Time.deltaTime));
				}
			}
			else 
			{
				//強制向き指定
					SetTargetRotation(Quaternion.LookRotation(forceRotateDirection));
					SetTransFormRotation(Quaternion.RotateTowards(transform.rotation,characterTargetRotation,cMcontroller.GetRotationSpeed() * Time.deltaTime));
			}
		}

		bool WalkRotateCondition(){
			if (velocity.magnitude > 0.1f && !cMcontroller.IsArrived ())
								return true;
						return false;
		}


		//移動に関する総合処理
		public void IsGrounded(){
			if (characterController.isGrounded) {
				//水平面移動のみなのでXZを扱う
				SetDestXZ();

				//高さを目的地と現在と合わせる
				SetDestAlign();

				//目的地への方向を求める
				DirectionSeek();

				//目的地への距離を求める
				cMcontroller.SetDistance(Vector3.Distance(transform.position,destinationXZ));

				//現在の速度を退避
				SetCurrentVelocity();

				//目的に近づいたら到着
				cMcontroller.DestArrived();

				//移動速度を求める
				WalkSpeedVelocity();

				//スムーズに動くよう補間
				SetVelocity(Vector3.Lerp(currentVelocity, velocity,Mathf.Min (Time.deltaTime * 5.0f ,1.0f)));
				SetVelocityY(0);

				//向きを行きたい方向へ向ける
				WalkRotation();

				//接地していたら地面に押し付ける
				SetSnapGround (Vector3.down);
			}
		}

		void WalkStop(){
			if (characterController.velocity.magnitude < 0.1f)
				cMcontroller.SetArrived (true);
		}

		void ForceRotateCancel(){
			if (cMcontroller.IsForceRotate () && Vector3.Dot (transform.forward, forceRotateDirection) > 0.99f)
				cMcontroller.SetForceRotate (false);
		}
	
		//目的地を指定する（引数が目的地）
		public void SetDestination(Vector3 destination)
		{
			cMcontroller.SetArrived (false);
			this.destination = destination;
		}
	
		//指定した向きを向かせる
		public void SetDirection(Vector3 direction)
		{
			forceRotateDirection = direction;
			forceRotateDirection.y = 0;
			forceRotateDirection.Normalize();
			cMcontroller.SetForceRotate (true);
		}

		public void StopMove()
		{
			destination = transform.position;
		}

		//目的地に到着したかを調べる
		public bool Arrived()
		{
			return cMcontroller.IsArrived();
		}
	}
}