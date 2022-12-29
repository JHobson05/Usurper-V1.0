using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class Turn
    {
        public int Index,Attacker,Victim;
        
        public Turn(int Index,int Attacker,int Victim)
        {
            this.Index = Index;
            this.Attacker = Attacker;
            this.Victim = Victim;
        }
    }
}
