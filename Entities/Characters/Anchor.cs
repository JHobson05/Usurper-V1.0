using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Anchor : Character
    {
        public Anchor() : base(CharacterID.Anchor)
        {
            atk = 4;
            spAtk =2;
            def = 9;
            spDef = 5;
            maxHp = 120; hp = maxHp;
            spriteString = "";
            type = "Normal";
            name = "Anchor";
        }
    }
}
