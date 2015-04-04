using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class TargetCursorController
	{
		//目的地
		private Vector3 destination = new Vector3( 0.0f, 0.5f, 0.0f );
		//位置
		private Vector3 position = new Vector3( 0.0f, 0.5f, 0.0f );
		//オフセット位置
		private Vector3 offset;
		// 半径
		private float radius = 1.0f;
		// 回転速度
		private float angularVelocity = 480.0f;
		// 角度
		private float angle = 0.0f;

		private ICursorController cursorController;


		public TargetCursorController(){

		}

		public Vector3 GetDestination(){
			return this.destination;	
		}

		public string getDestination(){
			string s = GetDestination ().ToString ();
			return s;
		}

		public float getDestinationY(){
			return destination.y;
		}

		public void SetDestination(Vector3 iPos){
			destination = iPos;
		}

		public void SetDestinationY(float yPos){
			destination.y = yPos;	
		}

		public Vector3 GetPosition(){
			return this.position;	
		}

		public string getPosition(){
			string s = GetPosition ().ToString ();
			return s;
		}

		public Vector3 GetOffSet(){
			return this.offset;	
		}

		public string getOffSet(){
			string s = GetOffSet ().ToString ();
			return s;
		}

		public void SetUpPosition(){
			this.position += ( destination - position ) / 10.0f;	
		}

		public void SetDest(){
			this.position = destination;
		}

		public void OffSet(){
			this.offset = Quaternion.Euler (0.0f, GetAngle(), 0.0f) * new Vector3 (0.0f, 0.0f, GetRadius() );
		}

		public float GetAngle(){
			return this.angle;	
		}

		public float GetRadius(){
			return this.radius;	
		}

		public float GetAngularVelocity(){
			return this.angularVelocity;	
		}

		public void SetUpAngle(float f){
			this.angle += f;	
		}

		public float SetAngularVelocity(float f){
			return this.angularVelocity * f;	
		}

		public void SetCursorController(ICursorController cursorController) {
			this.cursorController = cursorController;
		}
		
	}
}