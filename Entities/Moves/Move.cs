using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Usurper_V1._0
{
    public abstract class Move
    {
        //This is the superclass for the move class type. 
        protected string atkType, spriteString, type, name;
        protected int basePower,ID;
        protected bool spEffect;
        protected Texture2D IconSprite;

        public Move(int ID)
        {
            this.ID = ID;
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
    }
}
