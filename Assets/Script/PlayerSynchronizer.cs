using UnityEngine;
using System.Collections;

public class PlayerSynchronizer : MonoBehaviour {
	//ステータスをパッキングするときのビットフィールド
	enum BitField{
		Attacking = 0,
		Died,
	};

	//送受信情報
	Vector3 position;
	Quaternion rotation;

	CharaStatus status;
	
	void Start () {
		position = transform.position;
		rotation = transform.rotation;
		status = GetComponent<CharaStatus>();
	}

	void Update () {
		if(!networkView.isMine){
			transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * 5.0f);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5.0f);
		}
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info){
		if (stream.isWriting) {
						//送信
						Vector3 pos = transform.position;
						Quaternion rot = transform.rotation;
						stream.Serialize (ref pos);
						stream.Serialize (ref rot);
						if (status != null) {
								int hp = status.HP;
								int packedFlags = PackStatusFlags ();
								stream.Serialize (ref hp);
								stream.Serialize (ref packedFlags);
						}

				} else {
			//受信
			stream.Serialize(ref position);
			stream.Serialize(ref rotation);
			if(status != null){
				int hp = 0;
				int flags = 0;
				stream.Serialize(ref hp);
				stream.Serialize(ref flags);
				status.HP = hp;
				UnpackStatusBit(flags);
			}
		}
	}

	int PackStatusFlags(){
		int packed = 0;
		packed |= status.attacking ? (1 << (int)BitField.Attacking) : 0;
		packed |= status.died ? (1 << (int)BitField.Died) : 0;
		return packed;
	}

	void UnpackStatusBit(int bit){
		status.attacking = (bit & (1 << (int)BitField.Attacking)) != 0;
		status.died = (bit & (1 << (int)BitField.Died)) != 0;
	}

}
