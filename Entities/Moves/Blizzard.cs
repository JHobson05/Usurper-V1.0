using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Blizzard : Move
    {
        public Blizzard() : base(MoveID.blizzard)
        {
            this.ID = MoveID.blizzard;
            atkType = "spAtk";
            type = "Frost";
            spEffect = true;
            basePower = 20;
            spriteString = "BlizzardIcon";
        }
    }
}
