using System;

namespace Cradle
{
	public interface IMoveController
	{
		void FindCharacterControllerComponent();
		bool LessThanVMagnitude();
		void SetTransFormRot();
		bool IsGrounded();
		void DirectionSeek();
	}	
}