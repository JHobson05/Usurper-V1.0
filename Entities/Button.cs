using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Usurper_V1._0
{
    public class Button
    {
        //Custom button class made using monogames mouse information variable. Can create buttons of any rectangular dimensions.
        Vector2 position,sPosition;
        private int length, height,ID;
        public Color Dynamic;
        public bool active;
        //Constructor
        public Button(Vector2 Position, int length, int height, int ID)
        {
            position = Position;
            this.length = length;
            this.height = height;
            sPosition.X = Position.X + length;
            sPosition.Y = Position.Y + height;
            this.ID = ID;
            Dynamic = Color.White;
            active = true;
        }

        //This subroutine returns a bool when the button is successfully clicked.
        public Boolean checkPressed (MouseState mState)
        {
            if(mState.LeftButton == ButtonState.Pressed)
            {
                if (mState.LeftButton == ButtonState.Pressed)
                {
                    if ((mState.Position.ToVector2().X > position.X && mState.Position.ToVector2().X < sPosition.X) && (mState.Position.ToVector2().Y > position.Y && mState.Position.ToVector2().Y < sPosition.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //This subroutine changes the internal button colour from white (no filter) to silver (a grayed out filter) to indicate that clicking will trigger the button.
        public Boolean CheckHover (MouseState mState)
        {
            if ((mState.Position.ToVector2().X > position.X && mState.Position.ToVector2().X < sPosition.X) && (mState.Position.ToVector2().Y > position.Y && mState.Position.ToVector2().Y < sPosition.Y))
            {
                Dynamic = Color.Silver;
                return true;
            }
            Dynamic = Color.White;
            return false;
        }

        public int returnID()
        {
            return ID;
        }
    }
}
