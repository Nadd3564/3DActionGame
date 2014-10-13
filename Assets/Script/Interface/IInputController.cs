using System;

namespace Cradle
{
	public interface IInputController
	{
		bool Clicked();
		bool Moved();
		bool InputGetButtonFire1 ();
		bool InputGetButtonUpFire1 ();
		bool InputGetButton ();
		bool InputGetButtonDown ();
		bool InputGetButtonUp();
	}	
}
