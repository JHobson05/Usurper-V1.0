using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public abstract class Move
    {
        //This is the superclass for the move class type. 
        protected string atkType;
        protected string type;
        protected int basePower,ID;
        protected bool spEffect;

        public Move(int ID)
        {

        }

        public int BasePower { get { return basePower; } }
        public string AtkType { get { return atkType; } }
        public string Type { get { return type; } }
        public bool SpEffect { get { return spEffect; } }
    }
}
