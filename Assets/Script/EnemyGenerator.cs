using UnityEngine;
using System;
using System.Collections;
using Cradle;
using Cradle.FM;
using Cradle.Resource;

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
					try{
						controller.Generate(0, existEnemys.Length);
					}catch(ArgumentException e){
						Debug.Log("SaveErrorLog : " + e);
						TextReadWriteManager write = new TextReadWriteManager();
						write.WriteTextFile(Application.dataPath + "/" + "ErrorLog_Cradle.txt", e.ToString());
					}
					yield return new WaitForSeconds(controller.GetRePopTime());
				}
			}

			public void NewExitEnemys(){
					this.existEnemys = new GameObject[controller.GetMaxActive()];
			}

			public bool Instantiate(int enemyCount){
				existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position, transform.rotation) as 
					GameObject;
				return true;
				return false;
			} 

			public bool SameNullEnemys(int enemyCount){
				if (existEnemys [enemyCount] == null)
					return true;
				return false;
			}

		}
}