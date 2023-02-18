using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class Pyromancer : Character
    {
        public Pyromancer() : base(CharacterID.Pyromancer)
        {
            atk = 11;
            spAtk = 10;
            def = 3;
            spDef = 4;
            maxHp = 275; hp = maxHp;
            spriteString = "Pyromancer";
            name = "Pyromancer";
            type = "Fire";
            Moves[0] = 15;
            Moves[1] = 16;
            Moves[2] = 17;
            Moves[3] = 4;
        }
    }
}
