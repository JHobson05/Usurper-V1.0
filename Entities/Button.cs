using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Usurper_V1._0
{
    public class Button
    {
        Vector2 position,sPosition;
        MouseState mstate;
        private int length, height;
        public Button(Vector2 Position, int length, int height)
        {
            position = Position;
            this.length = length;
            this.height = height;
            sPosition.X = Position.X + length;
            sPosition.Y = Position.Y + height;
        }

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
    }
}
