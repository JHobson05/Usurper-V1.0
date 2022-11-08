using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class Ability
    {
        protected bool active;
        protected bool defense;
        protected bool offense;
        public int ID;

        protected Ability(int id)
        {
            ID = id;
            active = false;
        }
    }
}
