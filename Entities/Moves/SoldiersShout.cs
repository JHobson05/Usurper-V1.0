using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class SoldiersShout : Move
    {
        public SoldiersShout() : base(MoveID.soldiersShout)
        {
            basePower = 0;
            spEffect = true;
            atkType = "spAtk";
            name = "Soldier's Shout";
            type = "Normal";
        }
    }
}
