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
            atk = 5;
            spAtk = 8;
            def = 5;
            spDef = 5;
            hp = 100;
        }
    }
}
