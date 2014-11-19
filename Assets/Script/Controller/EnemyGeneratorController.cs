using System;
using UnityEngine;

namespace Cradle
{
	[Serializable]
	public class EnemyGeneratorController
	{
		//アクティブの最大数
		public int maxActive = 2;
		//再出現までの時間
		public float RePopTime = 8.0f;
	
		private IGeneratorController gController;
		
		public EnemyGeneratorController (){

		}

		public int GetMaxActive(){
			return this.maxActive;		
		}
		
		public int SetMaxActive(int i){
			return this.maxActive = i;		
		}
		
		public float GetRePopTime(){
			return this.RePopTime;		
		}
		
		public float SetRePopTime(float f){
			return this.RePopTime = f;		
		}

		public void Generate(int i, int EnemysLength){
			for(int enemyCount = i; enemyCount < EnemysLength; ++ enemyCount){
				if(gController.SameNullEnemys(enemyCount)){
					//敵作成
					if(!gController.Instantiate(enemyCount)){
						throw new ArgumentException("The Instantiate Must Be True.", default(Exception));
					}
					return;
				}
			}	
		}


		public void SetGeneratorController(IGeneratorController gController) {
			this.gController = gController;
		}

		//For Tests
		public void GenerateTest(){
			if(Application.loadedLevelName == "TestScene")
				IntegrationTest.Pass();
		}
		
	}
}