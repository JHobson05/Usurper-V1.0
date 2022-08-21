using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class MightyShot : Move
    {
        public MightyShot() : base(MoveID.mightyShot)
        {
            this.ID = MoveID.mightyShot;
            basePower = 40;
            atkType = "spAtk";
            type = "normal";
            spEffect = false;
            name = "Mighty Shot";
        }
    }
}
