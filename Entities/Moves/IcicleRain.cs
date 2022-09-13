﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Usurper_V1._0
{
    public class IcicleRain : Move
    {
        public IcicleRain(): base(MoveID.icicleRain)
        {
            atkType = "atk";
            type = "Frost";
            spEffect = false;
            basePower = 30;
            spriteString = "IcicleRainIcon";
            name = "Icicle Rain";
        }
    }
}
