using System;
namespace Cradle
{
	public interface IGeneratorController
	{
		void NewExitEnemys();
		bool Instantiate(int enemyCount);
		bool SameNullEnemys(int enemyCount);
	}	
}