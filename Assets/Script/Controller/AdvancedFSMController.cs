using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cradle.FM;

namespace Cradle
{
	[Serializable]
	public class AdvancedFSMController
	{
		private float calcTime = 0.0f;

		private IAdvancedController iAController;
		
		public AdvancedFSMController (){

		}

		//状態が存在しないときの条件式
		/*public void EmptyStates(FSMState fsmState){
						if (FSMStateCount(fsmStates.Count)) {
								fsmStates.Add (fsmState);
								currentState = fsmState;
								SetCurrentStateID(currentState.ID, fsmState.ID);
								return;
						}
				}*/

		public bool FSMStateCount(int i){
				if (i == 0)
					return true;
			return false;
		}

		public bool AsTrans(Transition trans){
			if (trans == Transition.None)
					return true;
			return false;
		}

		public bool AsFSMStateID(FSMStateID f, FSMStateID s){
			if (f == s)
				return true;
			return false;
		}

		public void SetCurrentStateID(FSMStateID f, FSMStateID s){
			f = s;
		}
		
		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void SetAdvancedController(IAdvancedController iAController) {
			this.iAController = iAController;
		}
		
	}
}