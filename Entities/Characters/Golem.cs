using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Golem : Character
    {
        public Golem() : base(CharacterID.Golem)
        {
            atk = 12;
            spAtk = 4;
            def = 9;
            spDef =3;
            maxHp = 1200; hp = maxHp;
            type = "Normal";
            spriteString = "Golem";
            name = "The Golem";
            Moves[0] =18;
            Moves[1] =19;
            Moves[2] =20;
            Moves[3] =21;
        }
    }
}
