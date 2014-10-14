using UnityEngine;
using System.Collections;
using Cradle;
using Cradle.FM;

namespace Cradle{
public class EnemyGenerator : MonoBehaviour, IGeneratorController {
		//生成される敵
		public GameObject enemyPrefab;
		GameObject[] existEnemys;
		public EnemyGeneratorController controller;

		public void OnEnable() {
			controller.SetGeneratorController (this);
		}

		void Start () {
			NewExitEnemys ();
			StartCoroutine (Exec());
		}

		IEnumerator Exec(){
			while(true){
				controller.generate(existEnemys.Length);
				yield return new WaitForSeconds(controller.GetRePopTime());
			}
		}

		public void NewExitEnemys(){
				this.existEnemys = new GameObject[controller.GetMaxActive()];
		}

		public void Instantiate(int enemyCount){
			existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position, transform.rotation) as 
				GameObject;
		} 

		public bool SameNullEnemys(int enemyCount){
			if (existEnemys [enemyCount] == null)
				return true;
			return false;
		}

	}
	}