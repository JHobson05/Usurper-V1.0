using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class FootSoldier : Character
    {
        
        public FootSoldier() : base(CharacterID.FootSoldier)
        {
            atk = 5;
            spAtk = 3;
            def = 6;
            spDef = 4;
            maxHp = 350; hp = maxHp;
            spriteString = "";
            name = "Foot Soldier";
            Moves[0] = 4;
            Moves[1] = 10;
            Moves[2] = 11;
            Moves[3] = 12;
        }
    }
}
