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
            maxHp = 100; hp = maxHp;
            spriteString = "";
            name = "Foot Soldier";
        }
    }
}
