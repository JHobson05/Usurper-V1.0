using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Usurper_V1._0
{
    public class BattleState : State
    {
        BattleManager bMgr;
        MoveList moveList;
        MouseState mState;
        Button Move1,Move2,Move3,Move4,Enemy;
        bool Attack,enemySelect,enemyChosen,moveChosen, mReleased,enemyturn,gPause;
        Vector2 B1, B2, B3,B4,B5,B6;
        int cCharacter, cEnemy,moveIndex,eMove;
        float timer;
        public BattleState (EnemyList list,Game1 g,MoveList moveList) : base(StateID.battle)
        {
            this.moveList = moveList;
            //Party enemies = new Party(list.getEnemy(), list.getEnemy(), list.getEnemy());
            Party enemies = new Party(list.enemyList[0],list.enemyList[1]);
            bMgr = new BattleManager(g.party,enemies);
        }

        public override void Initialize(Game1 g)
        {
            Attack = false;
            enemyturn = false;
            cCharacter = 0;
            mReleased = true;
            eMove = 0;
            B1 = new Vector2(1, 327);
            Move1 = new Button(B1, 32, 32,0);
            B2 = new Vector2(34, 327);
            Move2 = new Button(B2, 32, 32,1);
            B3 = new Vector2(600, 50);
            Enemy = new Button(B3, 32, 32, 1);
            B4 = new Vector2(10, 50);
            B5 = new Vector2(67, 327);
            B6 = new Vector2(100, 327);
            Move3 = new Button(B5, 32, 32, 2);
            Move4 = new Button(B6, 32, 32, 3);
            g.party.party[0].setPosition(B4);
            g.enemyList.enemyList[1].setPosition(B3);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            if (!gPause)
            {
                mState = Mouse.GetState();
                // This if statement is used to ensure that things are only registered as one click when the mouse is held down.
                if (mState.LeftButton == ButtonState.Released)
                {
                    mReleased = true;
                }
                if (enemyturn)
                {
                    eMove = bMgr.EasyAIMove(1, moveList);
                    enemyturn = false;
                    moveChosen = false;
                }
                if ((mState.LeftButton == ButtonState.Pressed) && mReleased)
                {
                    mReleased = false;
                    PlayerMove(g);
                    if (enemySelect)
                    {
                        if (Enemy.checkPressed(mState))
                        {
                            enemyChosen = true;
                            if (enemyChosen) cEnemy = 1;
                        }
                    }

                    if (enemyChosen && Attack && moveChosen)
                    {
                        bMgr.playerAttackCalculator(0, moveIndex, cEnemy, moveList);
                        enemyturn = true;
                        gPause = true;
                        timer = 0;
                        //eMove = bMgr.EasyAIMove(1, moveList);
                        //enemyturn = false;
                    }
                }
            }
            else
            {
                timer += (float)gt.ElapsedGameTime.TotalMilliseconds;
                if(timer > 2500)
                {
                    gPause = false;
                }
            }
        }

        public override void Draw(Game1 g)
        {
            g.GraphicsDevice.Clear(Color.Khaki);
            g._spriteBatch.Begin();
            DrawStart(g);
            if (enemySelect && !enemyChosen)
            {
                g._spriteBatch.DrawString(g.Font, "Select a target!", new Vector2(100, 0), Color.White);
            }
            if (!moveChosen)
            {
                g._spriteBatch.DrawString(g.Font, "Select a move!", new Vector2(100, 100), Color.White);
            }
            if (enemyturn)
            {
                g._spriteBatch.DrawString(g.Font, "The enemy is about to attack", new Vector2(0, 200), Color.White);
            }
            g._spriteBatch.End();
        }

        public void DrawStart(Game1 g)
        {
            //This method draws everything that is constant on the screen.
            g._spriteBatch.DrawString(g.Font, g.party.party[cCharacter].Name, new Vector2(10, 0), Color.White);
            g._spriteBatch.DrawString(g.Font, ("HP: " + g.party.party[cCharacter].HP.ToString()), new Vector2(10, 20), Color.White);
            g._spriteBatch.Draw(g.party.party[cCharacter].Sprite, g.party.party[0].getPosition, Color.White);
            g._spriteBatch.Draw(g.MoveBarSprite, new Vector2(0, 326), Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[0]].GetIconSprite, B1, Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[1]].GetIconSprite, B2, Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[2]].GetIconSprite, B5, Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[3]].GetIconSprite, B6, Color.White);
            g._spriteBatch.Draw(g.enemyList.enemyList[1].Sprite, g.enemyList.enemyList[1].getPosition, Color.White);
            g._spriteBatch.DrawString(g.Font, g.enemyList.enemyList[1].Name, new Vector2(500, 0), Color.White);
            g._spriteBatch.DrawString(g.Font, ("HP: " + g.enemyList.enemyList[1].HP.ToString()), new Vector2(500, 20), Color.White);
        }

        public void PlayerMove(Game1 g)
        {
            //This method is used to find out which move was selected by the player.
            if (Move1.checkPressed(mState))
            {
                Attack = true;
                enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move1.returnID()];
                moveChosen = true;
            }
            if (Move2.checkPressed(mState))
            {
                Attack = true;
                enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move2.returnID()];
                moveChosen = true;
            }
            if (Move3.checkPressed(mState))
            {
                Attack = true;
                enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move3.returnID()];
                moveChosen = true;
            }
            if (Move4.checkPressed(mState))
            {
                Attack = true;
                enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move4.returnID()];
                moveChosen = true;
            }
        }
    }
}
