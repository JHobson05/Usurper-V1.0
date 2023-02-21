using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class TurnInfo
    {
        private string victim, attacker, move;
        private double damage;
        private bool dodged;

        public TurnInfo(double damage, bool dodged, string move, string victim, string attacker)
        {
            this.victim = victim;
            this.attacker = attacker;
            this.dodged = dodged;
            this.move = move;
            this.damage = damage;
        }

        public void updateInfo(double damage, bool dodged, string move, string victim, string attacker)
        {
            this.victim = victim;
            this.attacker = attacker;
            this.dodged = dodged;
            this.move = move;
            this.damage = damage;
        }
        public string Attacker{ get { return attacker; } }
        public string Victim { get { return victim; } }
        public string Move { get { return move; } }
        public double Damage { get { return damage; } }
        public bool Dodged { get { return dodged; } }
    }
}
