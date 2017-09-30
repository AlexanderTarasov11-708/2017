using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex
{
	//Управление роботом
	
    class Program
    {
    	static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
		{
			return enemyInFront && ((enemyName != "boss")||(enemyName == "boss" && robotHealth>=50));
		}
    }
}