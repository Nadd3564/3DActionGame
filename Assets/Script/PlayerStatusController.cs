using UnityEngine;
using System.Collections;

public class PlayerStatusController : MonoBehaviour {
	const float RayCastMaxDistance = 100.0f;
	CharaStatus status;
	CharaAnimation charaAnimation;
	Transform attackTarget;
	InputManager inputManager;
	public float attackRange = 1.5f;

	//状態
	enum State{
		Walking,
		Attacking,
		Died,
	};

	State state = State.Walking;
	State nextState = State.Walking;

	void Start () {
		status = GetComponent<CharaStatus> ();
		charaAnimation = GetComponent<CharaAnimation> ();
		inputManager = FindObjectOfType<InputManager>();
	}

	void Update () {
		switch (state) {
		case State.Walking:
			Walking();
			break;
		case State.Attacking:
			Attacking();
			break;
		}

		if(state != nextState){
			state = nextState;
			switch(state){
			case State.Walking:
				WalkStart();
				break;
			case State.Attacking:
				AttackStart();
				break;
			case State.Died:
				Died();
				break;
			}
		}
	}
	
	void Walking()
	{
		if (inputManager.Clicked()) {
			Vector2 clickPos = inputManager.GetCursorPosition();
			Ray ray = Camera.main.ScreenPointToRay(clickPos);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo,RayCastMaxDistance,1 << LayerMask.NameToLayer("Ground"))) {
				SendMessage("SetDestination",hitInfo.point);
			}
		}
	}
}
