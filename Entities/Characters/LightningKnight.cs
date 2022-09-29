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
            maxHp = 250; hp = maxHp;
            type = "Electric";
            name = "Lightning Bloke";
            spriteString = "LightningKnight";
            Moves[0] = 8;
            Moves[1] = 9;
        }
    }
}
