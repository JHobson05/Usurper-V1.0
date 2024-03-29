﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class CharacterList
    {
        //This class is used to access characters through an index that is the same throughout the entire program.
        public List<Character> List;
        private FrostWizard frostWizard;
        private LightningKnight lightningKnight;
        private Pyromancer pyromancer;

        public CharacterList()
        {
            List = new List<Character>();
            frostWizard = new FrostWizard();
            lightningKnight = new LightningKnight();
            pyromancer = new Pyromancer();
            List.Add(frostWizard);
            List.Add(lightningKnight);
            List.Add(pyromancer);
        }
    }
}
