using UnityEngine;
using System.Collections;
using Cradle;

namespace Cradle{
public class DropItem : MonoBehaviour, IDropItemController {

		public enum ItemKind
		{
			Attack,
			Heal,
		};

		public ItemKind kind;
		public AudioClip itemSeClip;
		public CharaStatus iStatus;
		public DropItemController controller;
		Vector3 velocity;
		TerrainCollider tCollider;
		
		public void OnEnable() {
			controller.SetDropItemController (this);
		}

		void OnTriggerEnter(Collider other){
			//Playerか判定
			if (controller.IsPlayer(other.tag))
			{
				//アイテム取得
				FindCharaStatusComponent(other);
				iStatus.GetItem (kind);
				//取得したらアイテムを消す
				Destroy (gameObject);
				PlaySE();
			} 
			//地面か判定
			if(controller.IsTerrain(other.tag))
			{
				SetTrigger(false);
			}
		}
	
		void Start () {
			PopItem ();
			FindTerrainColliderComponent ();
		}

		public void FindTerrainColliderComponent(){
			this.tCollider = GetComponent<TerrainCollider>();
		}

		public void FindCharaStatusComponent(Collider other) {
			this.iStatus = other.GetComponent<CharaStatus>();
		}

		public void PlaySE(){
			AudioSource.PlayClipAtPoint(itemSeClip, transform.position);
			controller.CalcBoostTime ();
		}

		public void SetTrigger(bool flg){
			this.collider.isTrigger = flg;
		}

		public void PopItem(){
			this.velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
			this.rigidbody.velocity = velocity;
		}

	}
}