using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class EnemyList
    {
        // A base version of each possible enemy exists in this class. When starting a fight 3 enemies are randomly pulled from the list.
        // When the game is further developed i will add different methods that pull enemies that are specific to a certain location or encounter.
        public List<Character> enemyList;
        Random random = new Random();
        public EnemyList()
        {
            enemyList = new List<Character>();
            Character footSoldier = new FootSoldier();
            Character Archer = new Archer();
            Character Anchor = new Character(4);
            Character Golem = new Character(4);
            enemyList.Add(footSoldier);
            enemyList.Add(Archer);
            enemyList.Add(Anchor);
            enemyList.Add(Golem);
        }
        public Character getEnemy()
        {
            int num =random.Next(0, enemyList.Count);
            return enemyList[num];
        }
    }
}
