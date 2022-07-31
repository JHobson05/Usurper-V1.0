using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class EnemyList
    {
        // A base version of each possible enemy exists in this class. When starting a fight 3 enemies are randomly selected.
        // When the game is further developed i will add different methods that pull enemies that are specific to a certain location or encounter.
        public List<Character> enemyList;
        Random random = new Random();
        public EnemyList()
        {
            enemyList = new List<Character>();
            Character footSoldier = new Character(4);
            footSoldier.SetEnemy(100, 5, 3, 6, 4, "", "Foot Soldier", "Metal");
            Character Archer = new Character(4);
            Archer.SetEnemy(60, 7, 3, 3, 4, "", "Archer", "Metal");
            Character Anchor = new Character(4);
            Anchor.SetEnemy(120, 4, 2, 9, 5, "", "Anchor", "Metal");
            Character Golem = new Character(4);
            Golem.SetEnemy(110, 7, 3, 7, 4, "", "Golem", "Earth");
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
