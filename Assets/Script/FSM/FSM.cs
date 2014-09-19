using UnityEngine;
using System.Collections;

namespace Cradle.FM{
public class FSM : MonoBehaviour {
	protected Transform playerTransform;

	//NPCの次の到達点
	protected Vector3 destPos;

	//索敵する地点のリスト
	protected GameObject[] pointList;

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