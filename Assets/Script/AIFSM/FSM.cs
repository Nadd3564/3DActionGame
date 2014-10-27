using UnityEngine;
using System;
using System.Collections;
using Cradle;
using Cradle.FM;
using Cradle.Resource;

namespace Cradle.FM{
public class FSM : MonoBehaviour, IFSMController {
			//索敵する地点のリスト
			protected GameObject[] pointList;
			
			public FSMController controller;
				
			public void OnEnable() {
				controller.SetFSMController (this);
			}

			protected Transform getPlayerTrans(){
				return controller.GetPlayerTrans ();	
			}

			//攻撃の間隔
			protected float setAttackRate(float f){
				return controller.SetAttackRate (f);	
			}

			public float setElapsedTime(float f){
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

			public bool attackCount(){
			try{
				return controller.AttackCount ();
			} catch(TimeoutException e){
				Debug.Log("SaveExceptionLog : " + e);
				TextReadWriteManager write = new TextReadWriteManager();
				write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
			}

			return true;
			}
			
			protected void setPlayerTransform(Transform trans){
				controller.SetPlayerTransform (trans);	
			}

			protected virtual void StartUp(){}
			protected virtual void StateUpdate(){}
			protected virtual void StateFixedUpdate(){}


			// Use this for initialization
			void Start () {
				StartUp ();
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