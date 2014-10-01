using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{

public class CharaMove : MonoBehaviour, IMoveController {
	Vector3 velocity = Vector3.zero; 
	CharacterController characterController; 
	Vector3 forceRotateDirection;
	public Vector3 destination; 
	public CharaMoveController cMcontroller;
		
		public void OnEnable() {
			cMcontroller.SetMoveController (this);
		}
	
	void Start () {
		FindCharacterControllerComponent ();
		SetDest ();
	}
	
		public void FindCharacterControllerComponent(){
			this.characterController = GetComponent<CharacterController>();
		}

		void SetDest(){
			this.destination = transform.position;
		}

	void Update () {
		if (characterController.isGrounded) {
			Vector3 destinationXZ = destination; 
			destinationXZ.y = transform.position.y;
			
			Vector3 direction = (destinationXZ - transform.position).normalized;
			float distance = Vector3.Distance(transform.position,destinationXZ);
			
			Vector3 currentVelocity = velocity;
			
			if (cMcontroller.IsArrived() || distance < cMcontroller.GetStoppingDist())
					cMcontroller.SetArrived(true);
		
			
			if (cMcontroller.IsArrived())
				velocity = Vector3.zero;
			else 
				velocity = direction * cMcontroller.GetWalkSpeed();
			
			velocity = Vector3.Lerp(currentVelocity, velocity,Mathf.Min (Time.deltaTime * 5.0f ,1.0f));
			velocity.y = 0;
			
			
			if (!cMcontroller.IsForceRotate()) {
				if (velocity.magnitude > 0.1f && !cMcontroller.IsArrived()) { 
					Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
					transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,cMcontroller.GetRotationSpeed() * Time.deltaTime);
				}
			} else {
				Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotateDirection);
				transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,cMcontroller.GetRotationSpeed() * Time.deltaTime);
			}
			
		}
		
		velocity += Vector3.down * cMcontroller.GetGravityPower() * Time.deltaTime;
		
		Vector3 snapGround = Vector3.zero;
		if (characterController.isGrounded)
			snapGround = Vector3.down;
		
		characterController.Move(velocity * Time.deltaTime+snapGround);
		
		if (characterController.velocity.magnitude < 0.1f)
								cMcontroller.SetArrived (true);
		
		if (cMcontroller.IsForceRotate () && Vector3.Dot (transform.forward, forceRotateDirection) > 0.99f)
								cMcontroller.SetForceRotate (false);
		
		
	}
	
	public void SetDestination(Vector3 destination)
	{
		cMcontroller.SetArrived (false);
		this.destination = destination;
	}
	
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

	public bool Arrived()
	{
		return cMcontroller.IsArrived();
	}
	
	
}
}