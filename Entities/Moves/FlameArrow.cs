using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class FlameArrow : Move
    {
        public FlameArrow() : base(MoveID.flameArrow)
        {
            basePower = 25;
            spEffect = true;
            type = "Fire";
            atkType = "atk";
            name = "Flame Arrow";
        }
    }
}
