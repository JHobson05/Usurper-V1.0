﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Usurper_V1._0
{
    class SelectState : State
    {
        //This state is for selecting which characters the player will take into the fight as well as selecting which fight they want to do.
        Vector2 B1,B2,B3,B4,B5;
        Button F1, F2, Exit,C1,C2;
        MouseState mState;
        bool playerWin, enemyWin;
        int partyID;
        string pWin = "Congratulations! You won the last battle.", eWin = "Unlucky! You lost the last battle.";
        public SelectState (Game1 g) : base(StateID.select)
        {

        }

        public override void Set(Game1 g)
        {
            
        }

        public override void Initialize(Game1 g)
        {
            B1 = new Vector2(621, 0);
            B2 = new Vector2(15, 30);
            B3 = new Vector2(15, 80);
            B4 = new Vector2(500, 250);
            B5 = new Vector2(500, 300);
            Exit = new Button(B1, 18, 31, 4);
            F1 = new Button(B2, 100, 40, 0);
            F2 = new Button(B3, 100, 40, 1);
            C1 = new Button(B4, 100, 40, 0);
            C2 = new Button(B5, 100, 40, 1);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mState = Mouse.GetState();
            if(WinID == 2)
            {
                playerWin = true;
            }
            else if(WinID == 1)
            {
                enemyWin = true;
            }
            Exit.CheckHover(mState);
            if (Exit.checkPressed(mState))
            {
                g.setMenu();
            }
            F1.CheckHover(mState);
            if(F1.checkPressed(mState) && F1.active)
            {
                g.stateMgr.SetAct(1,g);
                g.setBattle();
            }
            F2.CheckHover(mState);
            if(F2.checkPressed(mState)&& F2.active)
            {
                g.stateMgr.SetAct(2,g);
                g.setBattle();
            }
            C1.CheckHover(mState);
            if (C1.checkPressed(mState))
            {
                partyID = C1.returnID();
                g.updateCharacters(partyID);
            }
            C2.CheckHover(mState);
            if (C2.checkPressed(mState))
            {
                partyID = C2.returnID();
                g.updateCharacters(partyID);
            }
        }

        public override void Draw(Game1 g)
        {
            g.GraphicsDevice.Clear(Color.RosyBrown);
            g._spriteBatch.Begin();
            baseDraw(g);
            if (playerWin)
            {
                g._spriteBatch.DrawString(g.sFont, pWin, new Vector2(200, 170), Color.White);
            }
            else if (enemyWin)
            {
                g._spriteBatch.DrawString(g.sFont, eWin, new Vector2(200, 170), Color.White);
            }
            if(partyID == 0)
            {
                g._spriteBatch.DrawString(g.sFont, "Current selected team: 1", new Vector2(450, 220), Color.White);
            }
            else if (partyID == 1)
            {
                g._spriteBatch.DrawString(g.sFont, "Current selected team: 2", new Vector2(450, 220), Color.White);
            }
            g._spriteBatch.End();
        }

        public void baseDraw(Game1 g)
        {
            //Draws all the constant stuff to the screen.
            g._spriteBatch.Draw(g.Back,B1,Exit.Dynamic);
            g._spriteBatch.Draw(g.MenuBar, B2, F1.Dynamic);
            g._spriteBatch.DrawString(g.Font, "ACT 1", new Vector2(27,37), F1.Dynamic);
            g._spriteBatch.Draw(g.MenuBar, B3, F2.Dynamic);
            g._spriteBatch.DrawString(g.Font, "ACT 2", new Vector2(27, 87), F2.Dynamic);
            g._spriteBatch.Draw(g.MenuBar, B4, C1.Dynamic);
            g._spriteBatch.DrawString(g.Font, "TEAM 1", new Vector2(508, 257), C1.Dynamic);
            g._spriteBatch.Draw(g.MenuBar, B5, C2.Dynamic);
            g._spriteBatch.DrawString(g.Font, "TEAM 2", new Vector2(508, 307), C2.Dynamic);
        }
    }
}
