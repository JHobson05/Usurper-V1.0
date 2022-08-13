using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Usurper_V1._0
{
    public class Character
    {
        //The character superclass contains all the properties and methods that will be inherited by individual characters. All enemies are instances of this class.
        //properties
        protected int atk,spAtk,def,spDef,rank, ID;
        protected double hp, maxHp;
        protected bool Alive;
        protected string type, name, spriteString;
        protected Vector2 cPosition;
        //public Move move1;
        //public Move move2;
        public Texture2D Sprite{get; set;}
        //Constructor
        public Character(int ID)
        {
            this.ID = ID;
        }

        public double HP{ get { return hp; }}
        public double MaxHp { get { return maxHp; } }
        public void takeDamage(double value)
        {
            hp = hp - value;
        }

        //public Move UseMove(int Index)
        //{
        //    Move move;
        //    move = Moves[Index];
        //    return move;
        //}
        public string getSpriteString{get { return spriteString; } }
        public Vector2 getPosition{ get { return cPosition; } }
        public void setPosition(Vector2 V)
        {
            cPosition = V;
        }

        public string Name{ get { return name; } }
        public string Type { get { return type; } }

        public int Atk { get { return atk; } }
        public int SpAtk { get { return spAtk; } }
        public int Def { get { return def; } }
        public int SpDef { get { return spDef; } }

    }
}
