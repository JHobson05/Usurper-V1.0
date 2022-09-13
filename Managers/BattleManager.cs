﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class BattleManager
    {
        Party party,AI;
        Random random = new Random();

        public BattleManager( Party p, Party e)
        {
            party = p;
            AI = e;
        }

        //This method is a function as the integer returned is used to figure out what type of move was used by the AI.
        public int EasyAIMove(int Attacker,MoveList movelist)
        {
            int temp = random.Next(0,4);
            int MoveID = AI.party[Attacker].Moves[temp];
            AIAttackCalculator(Attacker, MoveID, 0, movelist);
            return MoveID;
        }

        public void playerAttackCalculator(int Attacker,int Index,int Victim,MoveList movelist)
        {
            Move attack = movelist.Moves[Index];
            double damage;
            if (AI.party[Victim].HP <= 0)
            {
                return;
            }
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
            if (AI.party[Victim].HP < 0)
            {
                AI.party[Victim].killCharacter();
            }
        }

        public void AIAttackCalculator(int Attacker, int Index, int Victim, MoveList movelist)
        {
            Move attack = movelist.Moves[Index];
            double damage;
            if(party.party[Victim].HP <= 0)
            {
                return;
            }
            if (attack.AtkType == "atk")
            {
                damage = attack.BasePower * AI.party[Attacker].Atk;
            }
            else
            {
                damage = attack.BasePower * AI.party[Attacker].SpAtk;
            }
            if (attack.Type == AI.party[Attacker].Type)
            {
                damage = Math.Round(damage * 1.2);
            }
            if (attack.AtkType == "atk")
            {
                damage = damage / party.party[Victim].Def;
            }
            else
            {
                damage = damage / party.party[Victim].SpDef;
            }
            party.party[Victim].takeDamage(damage);
            if (party.party[Victim].HP < 0)
            {
                party.party[Victim].killCharacter();
            }
        }
    }
}
