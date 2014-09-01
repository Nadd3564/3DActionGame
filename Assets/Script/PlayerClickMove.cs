using UnityEngine;
using System.Collections;

public class PlayerClickMove : MonoBehaviour {
	const float RayCastMaxDistance = 100.0f;
	public InputManager inputManager;


	void Start () {
		inputManager = FindObjectOfType<InputManager>();
	}

	void Update () {
		Walking ();
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
