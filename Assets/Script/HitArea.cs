using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {

	//攻撃情報を伝達
	void Damage (AttackArea.AttackInfo attackInfo) {
		transform.root.SendMessage ("Damage", attackInfo);
	}

}
