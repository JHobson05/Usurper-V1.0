using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Gut : Move
    {
        public Gut() : base(MoveID.gut)
        {
            this.ID = MoveID.gut;
            basePower = 50;
            atkType = "atk";
            type = "normal";
            spEffect = false;
        }
    }
}
