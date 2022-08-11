using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Golem : Character
    {
        public Golem() : base(CharacterID.Golem)
        {
            atk = 7;
            spAtk = 3;
            def = 7;
            spDef =4;
            maxHp = 110; hp = maxHp;
            type = "Organic";
        }
    }
}
