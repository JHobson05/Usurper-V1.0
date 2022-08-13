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
        bool Attack;
        Vector2 B1, B2, B3,B4;
        int cCharacter, cEnemy,moveIndex;
        public BattleState (EnemyList list,Game1 g,MoveList moveList) : base(StateID.battle)
        {
            this.moveList = moveList;
            //Party enemies = new Party(list.getEnemy(), list.getEnemy(), list.getEnemy());
            Party enemies = new Party(list.enemyList[1]);
            bMgr = new BattleManager(g.party,enemies);
        }

        public override void Initialize(Game1 g)
        {
            B1 = new Vector2(10, 200);
            Move1 = new Button(B1, 32, 32,0);
            B2 = new Vector2(42, 200);
            Move2 = new Button(B2, 32, 32,1);
            B3 = new Vector2(600, 50);
            Enemy = new Button(B3, 32, 32, 1);
            B4 = new Vector2(10, 50);
            g.party.party[0].setPosition(B4);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mState = Mouse.GetState();
            if (mState.LeftButton == ButtonState.Pressed)
            {
                Attack = Move1.checkPressed(mState);
                if (!Attack)
                {
                    Attack = Move2.checkPressed(mState);
                }
               
            }
        }

        public override void Draw(Game1 g)
        {
            g.GraphicsDevice.Clear(Color.Khaki);
            g._spriteBatch.Begin();
            g._spriteBatch.DrawString(g.Font, g.party.party[0].Name, new Vector2(10, 0), Color.White);
            g._spriteBatch.DrawString(g.Font, ("HP: " + g.party.party[0].HP.ToString()), new Vector2(10, 20), Color.White);
            g._spriteBatch.Draw(g.party.party[0].Sprite, g.party.party[0].getPosition, Color.White);
            g._spriteBatch.Draw(g.MoveBarSprite, new Vector2(9,199),Color.White);
            g._spriteBatch.Draw(moveList.Moves[0].GetIconSprite, B1, Color.White );
            g._spriteBatch.Draw(moveList.Moves[1].GetIconSprite,B2,Color.White);
            g._spriteBatch.Draw(g.enemyList.enemyList[1].Sprite,B3,Color.White);
            if (Attack)
            {
                g._spriteBatch.DrawString(g.Font, "Success", new Vector2(100, 0), Color.White);
            }
            g._spriteBatch.End();
        }
    }
}
