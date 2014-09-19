using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class Finder : MonoBehaviour {
	GameObject obj;

	// Use this for initialization
	void Start () {
		obj = GameObject.FindGameObjectWithTag ("Item");
		Debug.Log (obj);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}