using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.DesignPattern;

namespace Cradle.DesignPattern{
public class Inheritance : MonoBehaviour {

		protected virtual void StartUp(){}
		protected virtual void Main(){}
		protected virtual void MainFixedUpdate(){}
		
		
		// Use this for initialization
		void Start () {
			StartUp ();
		}
		
		// Update is called once per frame
		void Update () {
			Main ();
		}
		
		void FixedUpdate(){
			MainFixedUpdate ();
		}
}
}