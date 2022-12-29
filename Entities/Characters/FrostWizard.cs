using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class FrostWizard : Character
    {
        //The constructor for this class sets all the properties inherited by the character class
        public FrostWizard () : base(CharacterID.FrostWizard)
        {
            atk = 5;
            spAtk = 8;
            def = 5;
            spDef =5;
            maxHp = 250; hp = maxHp;
            spriteString = "pixil-frame-0";
            name = "Frost Wizard";
            type = "Frost";
            Moves[0] = 0;
            Moves[1] = 1;
            Moves[2] = 5;
            Moves[3] = 6;
        }
        
    }
}
