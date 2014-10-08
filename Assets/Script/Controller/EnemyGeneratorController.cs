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
	
		private IGeneratorController generatorController;
		
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

		public void SetGeneratorController(IGeneratorController generatorController) {
			this.generatorController = generatorController;
		}
		
	}
}