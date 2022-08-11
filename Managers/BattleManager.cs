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

        public void DamageCalculator(int Attacker,int Index,int Victim)
        {
            Move attack = party.party[Attacker].UseMove(Index);
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
            if (attack.AtkType == "atk")
            {
                damage = damage / AI.party[Victim].Def;
            }
            else
            {
                damage = damage / AI.party[Victim].SpDef;
            }
            AI.party[Victim].takeDamage(damage);
        }
    }
}
