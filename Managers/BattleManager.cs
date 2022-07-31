using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class BattleManager
    {
        Party party,AI;

        public BattleManager( Party p, Party e)
        {
            party = p;
            AI = e;
        }

        public void DamageCalculator(int Attacker,Move attack,int Victim)
        {
            double damage;
            if(attack.AtkType == "atk")
            {
                damage = attack.BasePower * party.party[Attacker].Atk;
            }
            else
            {
                damage = attack.BasePower * party.party[Attacker].SpAtk;
            }
            if(attack.Type == party.party[Attacker].Type)
            {
                damage = Math.Round(damage * 1.2);
            }
            AI.party[Victim].takeDamage(damage);
        }
    }
}
