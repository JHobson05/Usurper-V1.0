using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class VoltVolley : Move
    {
        public VoltVolley() : base(MoveID.voltVolley)
        {
            basePower = 45;
            atkType = "spAtk";
            type = "Electric";
            spEffect = true;
            name = "Volt Volley";
        }
    }
}
