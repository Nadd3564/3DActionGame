using System;
namespace Cradle
{
	public interface IGeneratorController
	{
		void NewExitEnemys();
		void Instantiate(int enemyCount);
		bool SameNullEnemys(int enemyCount);
	}	
}