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
        MouseState mState;
        bool mReleased;
        public BattleState (EnemyList list,Game1 g) : base(StateID.battle)
        {

            Party enemies = new Party(list.getEnemy(), list.getEnemy(), list.getEnemy());
            bMgr = new BattleManager(g.party,enemies);
        }

        public override void Initialize(Game1 g)
        {
            mReleased = true;
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mState = Mouse.GetState();
            if(mState.LeftButton == ButtonState.Pressed && mReleased)
            {
                //if(mState.Position.ToVector2)
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
            g._spriteBatch.Draw(g.character1.move1.GetIconSprite, new Vector2(10,200), Color.White );
            g._spriteBatch.Draw(g.character1.move2.GetIconSprite, new Vector2(42, 200), Color.White);
            g._spriteBatch.End();
        }
    }
}
