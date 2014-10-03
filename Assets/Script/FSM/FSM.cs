using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle.FM{
public class FSM : MonoBehaviour, IFSMController {
		protected Transform playerTransform;

		//NPCの次の到達点
		protected Vector3 destPos;

		//索敵する地点のリスト
		protected GameObject[] pointList;

		public FSMController controller;
			
		public void OnEnable() {
			controller.SetFSMController (this);
		}

		//攻撃の間隔
		protected float setAttackRate(float f){
			return controller.SetAttackRate (f);	
		}

		protected float setElapsedTime(float f){
			return controller.SetElapsedTime (f);	
		}

		protected float setUpElapsedTime(float f){
			return controller.SetUpElapsedTime (f);	
		}

		protected float getAttackRate(){
			return controller.GetAttackRate ();	
		}
		
		protected float getElapsedTime(){
			return controller.GetElapsedTime ();	
		}

		protected bool attackCount(){
			return controller.AttackCount ();
		}
		
		protected void SetPlayerTransform(Transform trans){
			this.playerTransform = trans;	
		}

		protected virtual void StartUp(){}
		protected virtual void StateUpdate(){}
		protected virtual void StateFixedUpdate(){}


		// Use this for initialization
		void Start () {
			StartUp ();
			controller.CalcBoostTime ();
		}
		
		// Update is called once per frame
		void Update () {
			StateUpdate ();
		}

		void FixedUpdate(){
			StateFixedUpdate ();
		}
	}
}