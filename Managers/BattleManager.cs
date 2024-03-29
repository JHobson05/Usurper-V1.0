﻿using System;
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

        public void partyUpdate(Party p,Party e)
        {
            party = p;
            AI = e;
        }

        //This subroutine acts as a simple AI for the game to allow the enemy to randomly select attacks and targets.
        public TurnInfo EasyAIMove(int Attacker, MoveList movelist)
        {
            TurnInfo turn;
            int temp = random.Next(0, 4),target;
            if (!party.party[0].alive)
            {
                target = 1;
            }
            else if (!party.party[1].alive)
            {
                target = 0;
            }
            else
            { 
                target = random.Next(0, 2);
            }
            int MoveID = AI.party[Attacker].Moves[temp];
            turn =AttackCalculator(Attacker, MoveID, target, movelist,AI,party);
            return turn;
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

        //This subroutine returns an integer determining whether the fight has ended and if it has, which team won.
        public int checkWin()
        {
            int Num = 0, p=0, e=0;
            //Players party.
            for(int i = 0; i < 2; i++)
            {
                if (party.party[i].alive)
                {
                    p++;
                }
            }
            if (p <= 0)
            {
                Num = 1;
            }
            //AIs party.
            for (int i = 0; i < 1; i++)
            {
                if (AI.party[i].alive)
                {
                    e++;
                }
            }
            if (e <= 0)
            {
                Num = 2;
            }
            return Num;
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
                else if(element == 7)
                {
                    atkParty.party[Attacker].activeAbility = 0;
                    atkParty.party[Attacker].Colour = Color.White;
                }
            }
            else return;
        }

        /*This is the player attack calculator.The calculator is only used to damage targets, things like AI are seperate subroutines.
        The calculator determines whether abilities are applied a move is dodged and
        whether the attack is a high or low roll. */
        public TurnInfo AttackCalculator(int Attacker,int Index,int Victim,MoveList movelist,Party atkParty,Party enemyParty)
        {
            Move attack = movelist.Moves[Index];
            double Crit = CritRoll();
            double damage=0, abilityDamage=0;
            bool ability, dodged = false;
            TurnInfo Turn = new TurnInfo(damage, dodged, attack.Name, enemyParty.party[Victim].Name, atkParty.party[Attacker].Name);
            if (enemyParty.party[Victim].HP <= 0)
            {
                Turn.updateInfo(damage, dodged, attack.Name, enemyParty.party[Victim].Name, atkParty.party[Attacker].Name);
                return Turn;
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
                for (int i = 0; i < 1; i++)
                {
                    atkParty.party[i].takeDamage(abilityDamage);
                    if (atkParty.party[i].HP < 0)
                    {
                        atkParty.party[i].killCharacter();
                    }
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
                    Turn.updateInfo(damage, dodged, attack.Name, enemyParty.party[Victim].Name, atkParty.party[Attacker].Name);
                    return Turn;
                }
            }
            //Regular dodge chance
            else if(dodge <= 10)
            {
                dodged = true;
                Turn.updateInfo(damage, dodged, attack.Name, enemyParty.party[Victim].Name, atkParty.party[Attacker].Name);
                return Turn;
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
                //Code runs if move is special attack
                damage = attack.BasePower * atkParty.party[Attacker].SpAtk;
                damage = damage / enemyParty.party[Victim].SpDef;
            }
            if(attack.Type == atkParty.party[Attacker].Type)
            {
                //Same type attack bonus.
                damage = Math.Round(damage * 1.2);
            }
            damage = Math.Round(damage * Crit);
            if (dodged)
            {
                //This code is kind of like exception handling to try and make sure no damage is done .
                damage = 0;
            }
            
            enemyParty.party[Victim].takeDamage(damage);
            if (enemyParty.party[Victim].HP < 0)
            {
                enemyParty.party[Victim].killCharacter();
            }
            //updateInfo provides the battlestate with all the turn info. This is used to display text to the screen.
            Turn.updateInfo(damage, dodged, attack.Name, enemyParty.party[Victim].Name, atkParty.party[Attacker].Name);
            return Turn;
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
                party.party[Victim].Colour = Color.Black;
            }
        }
    }
}
