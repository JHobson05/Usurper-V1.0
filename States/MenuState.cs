using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    class MenuState : State
    {

        Vector2 B1, B2,B3;
        Button play, instructions,Exit;
        Texture2D MenuBar;
        MouseState mstate;
        bool HTP;

        public MenuState (Game1 g) : base(StateID.menu)
        {

        }
        public override void Initialize(Game1 g)
        {
            B1 = new Vector2(270,90);
            B2 = new Vector2(270, 140);
            B3 = new Vector2(0, 0);
            Exit = new Button(B3, 20, 20,2);
            play = new Button(B1,100,40,0);
            instructions = new Button(B2, 100, 40, 1);
            MenuBar = g.Content.Load<Texture2D>("MenuBar");

        }

        public override void Draw(Game1 g)
        {
            g._spriteBatch.Begin();
            BaseDraw(g);
            g._spriteBatch.End();
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mstate = Mouse.GetState();
            play.CheckHover(mstate);
            if (play.checkPressed(mstate))
            {
                g.setBattle();
            }
            instructions.CheckHover(mstate);
            if (instructions.checkPressed(mstate))
            {
                HTP = true;
            }

        }

        public void BaseDraw(Game1 g)
        {
            g._spriteBatch.Draw(MenuBar, B1, play.Dynamic);
            g._spriteBatch.Draw(MenuBar, B2, instructions.Dynamic);
            //Vector for string should always be +20X and + 5Y of vector of button
            g._spriteBatch.DrawString(g.Font, "Play", new Vector2(290, 95), play.Dynamic);
            //Word instructions is very big so i had to use a smaller font and take up more space on the box as i made it very small.
            g._spriteBatch.DrawString(g.sFont, "Instructions", new Vector2(274, 150), instructions.Dynamic);
        }
    }
}
