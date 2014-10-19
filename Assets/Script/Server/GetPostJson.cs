using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace Cradle.Server{
public class GetPostJson : MonoBehaviour {
		public GetPostJsonController controller;


	void Start () {
		StartCoroutine(controller.Get("http://localhost:8080/Cradle/json/1"));
		StartCoroutine(controller.Post("http://localhost:8080/Cradle/json/"));  
	}
	
	void Update () {
		
	}
	
}
}