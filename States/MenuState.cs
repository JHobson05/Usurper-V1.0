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
        string Instructions1 = "Thank you for playing Usurper. Usurper is a turn based rpg game \nwhere the player builds a team to take into fights\n" +
            "A basic way to play the game is you have 2 characters on your team which both \nhave unique movesets ,stats and more.\n" +
            "The objective of the player in each fight is to defeat the enemy team by using \nyour own teams move strategically to lower the enemies health to 0\n" +
            " Killing them. In Usurper characters and enemies can be one of 4 types. \n Frost , Fire, Electric and Normal. Frost, Fire and Electric types can trigger \nelemental effects" +
            "that are either offensive or defensive abilities.\n Frost type has the Brittle offensive ability and \nthe Frostbite defensive ability." +
            "Brittle makes the character the ability was \napplied to recieve 1.5X damage multiplier to all Atk damage." +
            "\nFrostbite makes the character that the ability was applied to \ngenerate a blistering cold aura around their general location." +
            "\nThis makes any attempt to attack the character much more likely to miss \n as the attack is slowed down by the cold allowing an easier dodge.";
        Vector2 B1, B2,B3;
        Button play, instructions,Exit;
        Texture2D MenuBar,Quit;
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
            Exit = new Button(B3, 18, 31,2);
            play = new Button(B1,100,40,0);
            instructions = new Button(B2, 100, 40, 1);
            MenuBar = g.Content.Load<Texture2D>("MenuBar");
            Quit = g.Content.Load<Texture2D>("ExitIcon");
        }

        public override void Draw(Game1 g)
        {
            g._spriteBatch.Begin();
            if (HTP)
            {
                g._spriteBatch.DrawString(g.sFont,Instructions1,new Vector2(10,80),Color.White);
            }
            else
            {
                BaseDraw(g);
            }
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
            Exit.CheckHover(mstate);
            if (Exit.checkPressed(mstate))
            {
                g.Quit();
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
            g._spriteBatch.Draw(Quit, B3, Exit.Dynamic);
        }
    }
}
