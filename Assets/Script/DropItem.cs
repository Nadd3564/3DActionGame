using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class DropItem : MonoBehaviour, IDropItemController {

		public AudioClip itemSeClip;
		public CharaStatus status;
		Vector3 velocity;
		TerrainCollider tCollider;


		public DropItemController controller;

		public void OnEnable() {
			controller.SetDropItemController (this);
		}

		void OnTriggerEnter(Collider other){
			//Playerか判定
			if (controller.IsPlayer(other.tag))
			{
				//アイテム取得
				FindCharaStatusComponent(other);
				status.GetItem (controller.kind);
				//取得したらアイテムを消す
				Destroy (gameObject);
				PlaySE();
			} 
			//地面か判定
			controller.CheckTerrain (other.tag, false);
		}
	
		void Start () {
			PopItem ();
			FindTerrainColliderComponent ();
		}

		public void FindTerrainColliderComponent(){
			this.tCollider = GetComponent<TerrainCollider>();
		}

		public void FindCharaStatusComponent(Collider other) {
			this.status = other.GetComponent<CharaStatus>();
		}

		public void PlaySE(){
			AudioSource.PlayClipAtPoint(itemSeClip, transform.position);
		}

		public bool SetTrigger(bool flg){
			this.collider.isTrigger = flg;
			return true;
			return false;
		}

		public void PopItem(){
			this.velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
			this.rigidbody.velocity = velocity;
		}

	}
}