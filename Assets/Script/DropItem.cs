using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class DropItem : MonoBehaviour {
	public enum ItemKind{
		Attack,
		Heal,
	};

	public ItemKind kind;
	public AudioClip itemSeClip;
	TerrainCollider tCollider;

	void OnTriggerEnter(Collider other){
				//Playerか判定
				if (other.tag == "Player"){
						//アイテム取得
						CharaStatus iStatus = other.GetComponent<CharaStatus> ();
						iStatus.GetItem (kind);
						//取得したらアイテムを消す
						Destroy (gameObject);

			AudioSource.PlayClipAtPoint(itemSeClip, transform.position);
				//地面か判定
		} else if(other.tag == "Terrain"){
			this.collider.isTrigger = false;
		}
		}
	
	void Start () {
		Vector3 velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
		rigidbody.velocity = velocity;
		tCollider = GetComponent<TerrainCollider>();
	}

	void Update () {
	
	}
}
}