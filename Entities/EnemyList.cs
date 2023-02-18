using System;
using System.Collections.Generic;

namespace Usurper_V1._0
{
    public class EnemyList
    {
        // A base version of each possible enemy exists in this class. When starting a fight depending on which act is chosen a predetermined boss will be selected
        public List<Character> enemyList;
        Random random = new Random();
        public EnemyList()
        {
            enemyList = new List<Character>();
            Character footSoldier = new FootSoldier();
            Character Archer = new Archer();
            Character Anchor = new Anchor();
            Character Golem = new Golem();
            Character Flame = new FlameDemon();
            enemyList.Add(footSoldier);
            enemyList.Add(Archer);
            enemyList.Add(Anchor);
            enemyList.Add(Golem);
            enemyList.Add(Flame);
        }
        public Character getEnemy()
        {
            int num =random.Next(0, enemyList.Count);
            return enemyList[num];
        }
    }
}
