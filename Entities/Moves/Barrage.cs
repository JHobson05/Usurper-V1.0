using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Barrage : Move
    {
        public Barrage() : base(MoveID.barrage)
        {
            this.ID = MoveID.barrage;
            basePower = 35;
            type = "normal";
            atkType = "spAtk";
            spEffect = false;
            name = "Barrage";
        }
    }
}
