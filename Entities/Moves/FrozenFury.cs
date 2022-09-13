using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class FrozenFury : Move
    {
        public FrozenFury() : base(MoveID.frozenFury)
        {
            basePower = 80;
            atkType = "spAtk";
            type = "Frost";
            name = "Frozen Fury";
            spEffect = false;
            spriteString = "FrozenFuryIcon";
        }
    }
}
