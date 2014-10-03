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
		private float calcTime = 0.0f;
		private float distance;
		
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
		
		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void SetMoveController(IMoveController iMoveController) {
			this.iMoveController = iMoveController;
		}
		
	}
}
