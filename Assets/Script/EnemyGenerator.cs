using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	//生成される敵
	public GameObject enemyPrefab;
	GameObject[] existEnemys;
	//アクティブの最大数
	public int maxActive = 2;

	void Start () {
		existEnemys = new GameObject[maxActive];
		StartCoroutine (Exec());
	}

	IEnumerator Exec(){
		while(true){
			Generate();
			yield return new WaitForSeconds( 3.0f );
		}
	}

	void Generate(){
		for(int enemyCount = 0; enemyCount < existEnemys.Length; ++ enemyCount){
			if(existEnemys[enemyCount] == null){
				//敵作成
				existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position, transform.rotation) as 
					GameObject;
				return;
			}
		}
	}
}
