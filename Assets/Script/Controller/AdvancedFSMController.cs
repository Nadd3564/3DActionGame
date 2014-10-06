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


		/*public bool EmptyID(){
		if (id == FSMStateID.None)
								return true;
			return false;
		}

		public List<FSMState> GetFsmStates(){
			return this.fsmStates;	
		} */

		//状態が存在しないときの条件式
		/*public void EmptyStates(){
						if (FSMStateCount()) {
								fsmStates.Add (fsmState);
								currentState = fsmState;
								currentStateID = fsmState.ID;
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

		/*public void RemoveState(FSMStateID fsmState){
			//状態を削除
			foreach(FSMState state in fsmStates)
			{
				if(state.ID == fsmState)
				{
					fsmStates.Remove(state);
					return;
				}
			}
		}*/




		/*public void EmptyFSM(FSMState fsmState){
						//状態が存在しないときの条件式
						if (SameCount()) {
								fsmStates.Add (fsmState);
								currentState = fsmState;
								currentStateID = fsmState.ID;
								return;
						}
				}*/



		/*public bool SameCount(){
			if (fsmStates.Count == 0)
					return true;
			return false;
		}*/
		
		public bool IsPlayer(string tag) {
			if (tag == "Player")
				return true;
			return false;
			if(tag != "Player")
				throw new DifferentStringException();
		}
		
		public bool IsTerrain(string tag) {
			if (tag == "Terrain")
				return true;
			return false;	
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