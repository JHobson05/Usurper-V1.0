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
        Button Move1,Move2,Enemy;
        bool Attack,enemySelect,enemyChosen,moveChosen, mReleased;
        Vector2 B1, B2, B3,B4;
        int cCharacter, cEnemy,moveIndex;
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
            cCharacter = 0;
            mReleased = true;
            B1 = new Vector2(1, 327);
            Move1 = new Button(B1, 32, 32,0);
            B2 = new Vector2(33, 327);
            Move2 = new Button(B2, 32, 32,1);
            B3 = new Vector2(600, 50);
            Enemy = new Button(B3, 32, 32, 1);
            B4 = new Vector2(10, 50);
            g.party.party[0].setPosition(B4);
            g.enemyList.enemyList[1].setPosition(B3);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mState = Mouse.GetState();
            // This if statement is used to ensure that things are only registered as one click when the mouse is held down.
            if(mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }
            if ((mState.LeftButton == ButtonState.Pressed) && mReleased)
            {
                mReleased = false;
                PlayerMove();
                if (enemySelect)
                {
                    if (Enemy.checkPressed(mState))
                    {
                        enemyChosen = true;
                        if (enemyChosen) cEnemy = 1;
                    }
                }

                if(enemyChosen && Attack && moveChosen)
                {
                    bMgr.playerAttackCalculator(0, moveIndex, cEnemy, moveList);
                    moveChosen = false;
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
                g._spriteBatch.DrawString(g.Font, "Select a move!", new Vector2(100, 400), Color.White);
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
            g._spriteBatch.Draw(g.enemyList.enemyList[1].Sprite, g.enemyList.enemyList[1].getPosition, Color.White);
            g._spriteBatch.DrawString(g.Font, g.enemyList.enemyList[1].Name, new Vector2(500, 0), Color.White);
            g._spriteBatch.DrawString(g.Font, ("HP: " + g.enemyList.enemyList[1].HP.ToString()), new Vector2(500, 20), Color.White);
        }

        public void PlayerMove()
        {
            //This method is used to find out which move was selected by the player.
            if (Move1.checkPressed(mState))
            {
                Attack = true;
                enemySelect = true;
                moveIndex = Move1.returnID();
                moveChosen = true;
            }
            if (Move2.checkPressed(mState))
            {
                Attack = true;
                enemySelect = true;
                moveIndex = Move2.returnID();
                moveChosen = true;
            }
        }
    }
}
