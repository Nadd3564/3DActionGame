using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class CharaMoveController
	{
		private float GravityPower = 9.8f; 
		private float StoppingDistance = 0.6f;
		public float walkSpeed = 6.0f;
		public float rotationSpeed = 360.0f;
		private float distance;
		public bool arrived = false; 
		public bool forceRotate = false;
		private Vector3 velocity = Vector3.zero; 
		private Vector3 forceRotateDirection;
		public Vector3 destination; 
		private Vector3 destinationXZ;
		public Vector3 direction;
		private Vector3 currentVelocity;
		private Vector3 snapGround;
		private Quaternion characterTargetRotation;
		
		private IMoveController iMoveController;
		
		public CharaMoveController (){
		}


		public float GetGravityPower(){
			return this.GravityPower;	
		}

		public float GetStoppingDist(){
			return this.StoppingDistance;	
		}
		
		public float GetWalkSpeed(){
			return this.walkSpeed;	
		}
		
		public float GetRotationSpeed(){
			return this.rotationSpeed;	
		}

		public float GetDistance(){
			return this.distance;	
		}

		public bool IsArrived(){
			return this.arrived;
		}

		public bool IsForceRotate(){
			return this.forceRotate;
		}

		public Vector3 GetVelocity(){
			return this.velocity;	
		}

		public string getVelocity(){
			string s = GetVelocity().ToString ();
			return s;
		}

		public string getVelocityY(){
			string s = GetVelocity().y.ToString ();
			return s;
		}

		public Vector3 GetForceRotateDirection(){
			return this.forceRotateDirection;	
		}

		public string getForceRotateDirection(){
			string s = GetForceRotateDirection().ToString ();
			return s;
		}

		public Vector3 GetDestination(){
			return this.destination;	
		}

		public string getDestination(){
			string s = GetDestination().ToString ();
			return s;
		}

		public Vector3 GetDestinationXZ(){
			return this.destinationXZ;	
		}

		public string getDestinationXZ(){
			string s = GetDestinationXZ().ToString ();
			return s;
		}

		public Vector3 GetDirection(){
			return this.direction;	
		}

		public string getDirection(){
			string s = GetDirection().ToString ();
			return s;
		}

		public Vector3 GetCurrentVelocity(){
			return this.currentVelocity;	
		}

		public string getCurrentVelocity(){
			string s = GetCurrentVelocity().ToString ();
			return s;
		}

		public Vector3 GetSnapGround(){
			return this.snapGround;	
		}

		public string getSnapGround(){
			string s = GetSnapGround().ToString ();
			return s;
		}

		public Quaternion GetCharacterTargetRot(){
			return this.characterTargetRotation;	
		}

		public string getCharacterTargetRot(){
			string s = GetCharacterTargetRot().ToString ();
			return s;
		}

		public float SetDistance(float f){
			return this.distance = f;	
		}

		public bool SetArrived(bool flg){
			return this.arrived = flg ;
		}

		public bool SetForceRotate(bool flg){
			return this.forceRotate = flg;
		}

		public void SetGravityAcceleration(){
			this.velocity += Vector3.down * GetGravityPower() * Time.deltaTime;
		}
		
		public void SetVelocityY(){
			this.velocity.y = 0;
		}
		
		public void SetCurrentVelocity(){
			this.currentVelocity = velocity;
		}

		public void SetVelocityZero(){
			this.velocity = Vector3.zero;
		}

		public void SmoothVelocity(){
			this.velocity = Vector3.Lerp(currentVelocity, velocity,Mathf.Min (Time.deltaTime * 5.0f ,1.0f));
		}

		public void SetWalkSpdVelocity(){
			this.velocity = direction * GetWalkSpeed();
		}

		public void SetDestXZ(){
			this.destinationXZ = destination; 
		}

		public void SetDestAlign(float f){
			destinationXZ.y = f;
		}

		public void SnapZero(){
			this.snapGround = Vector3.zero;
		}
		
		public void SnapDown(){
			this.snapGround = Vector3.down;
		}
		
		public void DestArrived(){
			if (IsArrived() || GetDistance() < GetStoppingDist())
				SetArrived(true);	
		}

		public bool WalkRotateCondition(){
			if (velocity.magnitude > 0.1f && !IsArrived ())
				return true;
			return false;
		}

		public void WalkStop(){
			if (iMoveController.LessThanVMagnitude())
				SetArrived (true);
		}

		//移動速度を求める
		public void WalkSpeedVelocity(){
			if (IsArrived ())
				SetVelocityZero ();
			else 
				SetWalkSpdVelocity ();
		}

		//目的地を指定する（引数が目的地）
		public void SetDestination(Vector3 destination)
		{
			SetArrived (false);
			this.destination = destination;
		}

		public void SetDirection(Vector3 direction)
		{
			forceRotateDirection = direction;
			forceRotateDirection.y = 0;
			forceRotateDirection.Normalize();
			SetForceRotate (true);
		}

		public void SetTargetRot(){
			this.characterTargetRotation = Quaternion.LookRotation (GetDirection ());
		}
		
		public void SetTargetForceRot(){
			this.characterTargetRotation = Quaternion.LookRotation (GetForceRotateDirection ());
		}

		public void WalkRotation(){
			if (!IsForceRotate ()) 
			{
				//行きたい方向へ向く
				if (WalkRotateCondition ()) { 
					SetTargetRot ();
					iMoveController.SetTransFormRot();		
				}
			} 
			else 
			{
				//強制向き指定
				SetTargetForceRot();
				iMoveController.SetTransFormRot();			
			}
		}




		//移動に関する総合処理
		public void MoveManagement(float f, float distance){
			if (iMoveController.IsGrounded()) {
				//水平面移動のみなのでXZを扱う
				SetDestXZ();
				
				//高さを目的地と現在と合わせる
				SetDestAlign(f);
				
				//目的地への方向を求める
				iMoveController.DirectionSeek();
				
				//目的地への距離を求める
				SetDistance(distance);
				
				//現在の速度を退避
				SetCurrentVelocity();
				
				//目的に近づいたら到着
				DestArrived();
				
				//移動速度を求める
				WalkSpeedVelocity();
				
				//スムーズに動くよう補間
				SmoothVelocity();
				SetVelocityY();
				
				//向きを行きたい方向へ向ける
				WalkRotation();
				
				//接地していたら地面に押し付ける
				SnapDown();
			}
		}



		public void SetMoveController(IMoveController iMoveController) {
			this.iMoveController = iMoveController;
		}
		
	}
}
