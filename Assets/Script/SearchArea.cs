using UnityEngine;
using System.Collections;

public class SearchArea : MonoBehaviour {
	EnemyStatusController enemyCtrl;

	void Start () {
	//EnemyStatusControllerをキャッシュする
		enemyCtrl = transform.root.GetComponent<EnemyStatusController> ();
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {
	//Playerタグをターゲットにする
		if (other.tag == "Player")
						enemyCtrl.SetAttackTarget (other.transform);
	}
}
