using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Usurper_V1._0
{
    public class Move
    {
        //This is the move class. originally each move was a subclass but this has been changed to due to it being redundant. 
        protected string atkType, spriteString, type, name;
        protected int basePower,ID;
        protected bool spEffect;
        protected Texture2D IconSprite;
        protected int ability;

        //Constructor.
        public Move(int ID, string atkType,string type,string spriteString,string name, int basePower, bool spEffect, int ability)
        {
            this.ID = ID;
            this.atkType = atkType;
            this.type = type;
            this.spriteString = spriteString;
            this.name = name;
            this.basePower = basePower;
            this.spEffect = spEffect;
            this.ability = ability;
        }

        public int BasePower { get { return basePower; } }
        public string AtkType { get { return atkType; } }
        public string Type { get { return type; } }
        public bool SpEffect { get { return spEffect; } }
        public string SpriteString 
        { 
            get { return spriteString; } 
            set { spriteString = value; }
        }
        public Texture2D GetIconSprite { get { return IconSprite; } }
        public Texture2D SetIconSprite { set { IconSprite = value; } }
        public string Name { get { return name; } }
        public int Ability { get { return ability; } }
    }
}
