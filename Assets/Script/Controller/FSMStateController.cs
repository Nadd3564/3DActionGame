using System;
using UnityEngine;
using Cradle;

namespace Cradle.FM
{
	[Serializable]
	public class FSMStateController : FSMState
	{
		//攻撃の間隔
		private float calcTime = 0.0f;
		private IFSMStateController fsmSController;
		
		public FSMStateController(){
			
		}

		public override void Reason (Transform player, Transform npc){}

		public override void Act(Transform player, Transform npc){}

		public void SetDist(float f){
			this.dist = f;
		}

		public void SetStateID(FSMStateID fsmState){
			this.stateID = fsmState;
		}
		
		public void SetRotSpeed(float f){
			this.RotSpeed = f;
		}

		
		//TansitionとIDのチェック
		public bool CheckTransOrID(Transition transition, FSMStateID id){
			if(EmptyTrans(transition) || EmptyID(id))
				return true;
			return false;
		}
		
		public bool EmptyTrans(Transition t){
			if(t == Transition.None)
				return true;
			return false;
		}
		
		public bool EmptyID(FSMStateID f){
			if(f == FSMStateID.None)
				return true;
			return false;
		}
		
		
		
		//distが一定の距離内かチェック
		public bool CheckDist(float f, float l, float o){
			if (MoreThanCheckReach (f, l) && LessCheckReach (f, o))
				return true;
			return false;
		}
		
		public bool MoreThanCheckReach(float f, float l){
			if (f >= l)
				return true;
			return false;
		}
		
		public bool LessCheckReach(float f, float o){
			if (f < o)
				return true;
			return false;
		}
		
		public bool LessThanCheckReach(float f, float o){
			if (f <= o)
				return true;
			return false;
		}

		public float CheckXRange(float f, float l){
			float xPos = Mathf.Abs (f - l);	
			return xPos;
		}

		public float CheckZRange(float f, float l){
			float zPos = Mathf.Abs (f - l);	
			return zPos;
		}

		public bool LessThanXPos(float xPos){
			if(xPos <= 10)	
				return true;
			return false;
		}

		public bool LessThanZPos(float zPos){
			if(zPos <= 10)	
				return true;
			return false;
		}


		public bool CheckRange(float xPos, float zPos){
		if (LessThanXPos(xPos) && LessThanZPos(zPos))
				return true;
			return false;
		}

		public virtual float CalcTime() {
			return Mathf.Max (this.calcTime - Time.deltaTime, 0.0f);
		}
		
		public void CalcBoostTime() {
			this.calcTime = CalcTime ();
		}
		
		public void SetFSMStateController(IFSMStateController fsmSController) {
			this.fsmSController = fsmSController;
		}
		
	}
}