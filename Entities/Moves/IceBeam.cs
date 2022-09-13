using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class IceBeam : Move
    {
        public IceBeam() : base(MoveID.iceBeam)
        {
            basePower = 60;
            type = "Frost";
            atkType = "spAtk";
            spEffect = false;
            name = "IceBeam";
            spriteString = "IceBeamIcon";
        }
    }
}
