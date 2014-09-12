using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {
	public enum ItemKind{
		Attack,
		Heal,
	};

	public ItemKind kind;
	public AudioClip itemSeClip;

	//拾われたフラグ
	bool isPickedUp = false;

	void OnTriggerEnter(Collider other){
		//ドロップするエネミーにぶつからないようにisTriggerをTrueに
		//this.collider.isTrigger = true;
				//Playerか地面か判定
				if (other.tag == "Player"){
			//this.collider.isTrigger = false;
						//アイテム取得
						CharaStatus iStatus = other.GetComponent<CharaStatus> ();
						iStatus.GetItem (kind);
			AudioSource.PlayClipAtPoint(itemSeClip, transform.position);
			//アイテム取得をオーナーへ通知する
			PlayerStatusController playerCtrl = other.GetComponent<PlayerStatusController>();
			if(playerCtrl.networkView.isMine){
				if(networkView.isMine)
					GetItemOnNetwork(playerCtrl.networkView.viewID);
				else
					networkView.RPC("GetItemOnNetwork", networkView.owner, playerCtrl.networkView.viewID);
			}
		}
	}

	[RPC]
	//アイテム取得
	void GetItemOnNetwork(NetworkViewID viewId){
		//拾われたフラグ
		if (isPickedUp)
						return;
		isPickedUp = true;

		//拾ったPlayerを探す
		NetworkView player = NetworkView.Find (viewId);
		if (player == null)
						return;

		//拾ったPlayerにアイテムを与える
		if (player.isMine)
						player.SendMessage ("GetItem", kind);
				else
						player.networkView.RPC ("GetItem", player.owner, kind);


		Network.Destroy (gameObject);
		Network.RemoveRPCs (networkView.viewID);
	}

	void OnNetworkInsitantiate(NetworkMessageInfo info){
		if (!networkView.isMine)
						Destroy (rigidbody);
	}

	void Start () {
		Vector3 velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
		rigidbody.velocity = velocity;
	}

	void Update () {
	
	}
}
