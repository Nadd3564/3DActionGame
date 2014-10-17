using System;

namespace Cradle
{
	public interface ICameraController
	{
		void FindInputComponent();
		void AvoidObstacle();
		void SetPosition();
		void Delta();
		bool Moved();
		void Look();
		void LookAtTrans();
		bool NotNullLookTarget();
	}	
}