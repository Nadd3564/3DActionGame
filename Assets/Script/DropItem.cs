using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {
	public enum ItemKind{
		Attack,
		Heal,
	};

	public ItemKind kind;

	void OnTriggerEnter(Collider other){
			//Playerか判定
		if(other.tag == "Player"){
			//アイテム取得
			CharaStatus iStatus = other.GetComponent<CharaStatus>();
			iStatus.GetItem(kind);
			//取得したらアイテムを消す
			Destroy(gameObject);
		}
	}


	void Start () {
		Vector3 velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
		rigidbody.velocity = velocity;
	}

	void Update () {
	
	}
}
