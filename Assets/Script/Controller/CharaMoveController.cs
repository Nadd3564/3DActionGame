using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class CharaMoveController
	{
		private float GravityPower = 9.8f; 
		private float StoppingDistance = 0.6f;
		public bool arrived = false; 
		public bool forceRotate = false;
		public float walkSpeed = 6.0f;
		public float rotationSpeed = 360.0f;
		private float distance;
		public Vector3 velocity = Vector3.zero; 
		public Vector3 forceRotateDirection;
		public Vector3 destination; 
		public Vector3 destinationXZ;
		public Vector3 direction;
		public Vector3 currentVelocity;
		public Vector3 snapGround;
		public Quaternion characterTargetRotation;
		
		private IMoveController iMoveController;
		
		public CharaMoveController (){
		}
		
		public bool IsArrived(){
			return this.arrived;
		}

		public bool SetArrived(bool flg){
			return this.arrived = flg ;
		}

		public bool IsForceRotate(){
			return this.forceRotate;
		}

		public bool SetForceRotate(bool flg){
			return this.forceRotate = flg;
		}

		public float GetDistance(){
			return this.distance;	
		}

		public float SetDistance(float f){
			return this.distance = f;	
		}

		public void DestArrived(){
			if (IsArrived() || GetDistance() < GetStoppingDist())
				 SetArrived(true);	
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

		public float GetGravityPower(){
			return this.GravityPower;	
		}

		public Vector3 GetVelocity(){
			return this.velocity;	
		}

		public Vector3 GetDirection(){
			return this.direction;	
		}

		public Vector3 GetForceRotateDirection(){
			return this.forceRotateDirection;	
		}


		public Vector3 GetDestinationXZ(){
			return this.destinationXZ;	
		}

		public Vector3 GetSnapGround(){
			return this.snapGround;	
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

		public Quaternion GetCharacterTargetRot(){
			return this.characterTargetRotation;	
		}

		public bool WalkRotateCondition(){
			if (velocity.magnitude > 0.1f && !IsArrived ())
				return true;
			return false;
		}


		public void SetDestXZ(){
			this.destinationXZ = destination; 
		}

		public void SnapZero(){
			this.snapGround = Vector3.zero;
		}

		public void SnapDown(){
			this.snapGround = Vector3.down;
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

		public void SetDirection(Vector3 direction)
		{
			forceRotateDirection = direction;
			forceRotateDirection.y = 0;
			forceRotateDirection.Normalize();
			SetForceRotate (true);
		}



		public void SetMoveController(IMoveController iMoveController) {
			this.iMoveController = iMoveController;
		}
		
	}
}
