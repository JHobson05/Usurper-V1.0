using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

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
        //This subroutine acts as a simple AI for the game to allow the enemy to randomly select attacks and targets.
        public int EasyAIMove(int Attacker,MoveList movelist)
        {
            int temp = random.Next(0,4);
            int target = random.Next(0, 2);
            int MoveID = AI.party[Attacker].Moves[temp];
            AttackCalculator(Attacker, MoveID, target, movelist,AI,party);
            return MoveID;
        }

        //This subroutine determines whether the attack will be a low regular high or crit roll. To land a critical hit there is a 1 in 16 chance.
        public double CritRoll()
        {
            double multiplier = 1;
            int value = random.Next(0, 16);
            if (value == 15)
            {
                multiplier = 2;
            }
            else if (value > 10 && value < 15) multiplier = 1.2;
            else if (value < 4) multiplier = 0.8;
            else multiplier = 1;
            return multiplier;
        }
        
        //This subroutine determines if an ability will be applied
        public bool Ability()
        {
            bool ability = false;
            int value = random.Next(0, 10);
            if (value < 7) ability = true;
            else ability = false;
            return ability;
        }

        //This subroutine determines which ability is applied if an ability is successful. The ability can be applied to either the attacker or victim.
        //Trialing a system to prevent repeat code by passing in more parameters.
        public void AbilityInfliction(Move attack,int Attacker, int Victim,Party atkParty, Party enemyParty)
        {
            if (attack.SpEffect)
            {
                int element = attack.Ability;
                if(element == 1)
                {
                    enemyParty.party[Victim].activeAbility =1;
                    enemyParty.party[Victim].Colour = Color.LightBlue;
                }
                else if(element == 2)
                {
                    atkParty.party[Attacker].activeAbility = 2;
                    atkParty.party[Attacker].Colour = Color.LightBlue;
                }
                else if(element == 3)
                {
                    enemyParty.party[Victim].activeAbility = 3;
                    enemyParty.party[Victim].Colour = Color.Yellow;
                }
                else if(element == 4)
                {
                    atkParty.party[Attacker].activeAbility = 4;
                    atkParty.party[Attacker].Colour = Color.Yellow;
                }
                else if (element == 5)
                {
                    enemyParty.party[Victim].activeAbility = 5;
                    enemyParty.party[Victim].Colour = Color.OrangeRed;
                }
                else if (element == 6)
                {
                    atkParty.party[Attacker].activeAbility = 6;
                    atkParty.party[Attacker].Colour = Color.OrangeRed;
                }
            }
            else return;
        }

        /*This is the player attack calculator.The calculator is only used to damage targets, things like AI are seperate subroutines.
        The calculator determines whether abilities are applied a move is dodged and
        whether the attack is a high or low roll. */
        public void AttackCalculator(int Attacker,int Index,int Victim,MoveList movelist,Party atkParty,Party enemyParty)
        {
            Move attack = movelist.Moves[Index];
            double Crit = CritRoll();
            double damage, abilityDamage=0;
            bool ability, dodged = false;
            if (enemyParty.party[Victim].HP <= 0)
            {
                return;
            }
            ability =Ability();
            if (ability)
            {
                AbilityInfliction(attack,Attacker,Victim,atkParty,enemyParty);
            }
            if(atkParty.party[Attacker].activeAbility ==3)
            {
                //Arc web offensive ability
                abilityDamage = 10 * atkParty.party[Attacker].SpDef;
                for (int i = 0; i < 2; i++)
                {
                    atkParty.party[i].takeDamage(abilityDamage);
                }
            }
            //Static charge defensive ability.
            if (enemyParty.party[Victim].activeAbility == 4)
            {
                abilityDamage = 5 * enemyParty.party[Victim].SpAtk;
                atkParty.party[Attacker].takeDamage(abilityDamage);
            }
            int dodge = random.Next(1, 101);
            //FrostBite defensive ability
            if(enemyParty.party[Victim].activeAbility == 2)
            {
                if (dodge <= 70)
                {
                    dodged = true;
                    return;
                }
            }
            else if(dodge <= 10)
            {
                dodged = true;
                return;
            }
            if(attack.AtkType == "atk")
            {
                damage = attack.BasePower * atkParty.party[Attacker].Atk;
                //Brittle offensive ability
                if(enemyParty.party[Victim].activeAbility == 1)
                {
                    damage = damage * 1.5;
                }
                else if(enemyParty.party[Victim].activeAbility == 6)
                {
                    atkParty.party[Attacker].takeDamage(30);
                }
                damage = damage / enemyParty.party[Victim].Def;
            }
            else
            {
                damage = attack.BasePower * atkParty.party[Attacker].SpAtk;
                damage = damage / enemyParty.party[Victim].SpDef;
            }
            if(attack.Type == atkParty.party[Attacker].Type)
            {
                damage = Math.Round(damage * 1.2);
            }
            damage = Math.Round(damage * Crit);
            if (dodged)
            {
                damage = 0;
            }
            
            enemyParty.party[Victim].takeDamage(damage);
            if (enemyParty.party[Victim].HP < 0)
            {
                enemyParty.party[Victim].killCharacter();
            }
        }

        //Backup code for old method of calculation. No longer used.
        public void AIAttackCalculator(int Attacker, int Index, int Victim, MoveList movelist)
        {
            Move attack = movelist.Moves[Index];
            double Crit = CritRoll();
            double damage;
            if(party.party[Victim].HP <= 0)
            {
                return;
            }
            int dodge = random.Next(1, 101);
            if (dodge <= 10)
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
            damage = Math.Round(damage * Crit);

            party.party[Victim].takeDamage(damage);
            if (party.party[Victim].HP < 0)
            {
                party.party[Victim].killCharacter();
            }
        }
    }
}
