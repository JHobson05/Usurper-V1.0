using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class LightningKnight : Character
    {
        //The constructor for this class sets all the properties inherited by the character class
        public LightningKnight() : base(CharacterID.LightningKnight)
        {
            atk = 7;
            spAtk = 5;
            def = 6;
            spDef = 5;
            maxHp = 300; hp = maxHp;
            type = "Electric";
            name = "Lightning Knight";
            spriteString = "LightningKnight";
            Moves[0] = 8;
            Moves[1] = 9;
            Moves[2] = 13;
            Moves[3] = 14;
        }
    }
}
