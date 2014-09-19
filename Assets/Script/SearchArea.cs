using UnityEngine;
using System.Collections;
using Cradle.FM;

namespace Cradle{
public class SearchArea : MonoBehaviour {
	EnemyCtrl enemyCtrl;

	void Start () {
	//EnemyStatusControllerをキャッシュする
		enemyCtrl = transform.root.GetComponent<EnemyCtrl> ();
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {
	//Playerタグをターゲットにする
		if (other.tag == "Player")
						enemyCtrl.SetAttackTarget (other.transform);
	}
}
}