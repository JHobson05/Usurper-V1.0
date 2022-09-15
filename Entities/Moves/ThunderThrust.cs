using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class ThunderThrust : Move
    {
        public ThunderThrust() : base(MoveID.thunderThrust)
        {
            atkType = "atk";
            type = "Electric";
            basePower = 55;
            spEffect = false;
            name = "Thunder Thrust";
            //Temp for testing.
            spriteString = "IceBeamIcon";
        }
    }
}
