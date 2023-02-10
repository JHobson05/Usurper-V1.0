using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Usurper_V1._0
{
    class SelectState : State
    {
        //This state is for selecting which characters the player will take into the fight as well as selecting which fight they want to do.
        Vector2 B1,B2,B3,B4,B5;
        Button F1, F2, Exit;
        MouseState mState;
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
            Exit = new Button(B1, 18, 31, 4);
            F1 = new Button(B2, 100, 40, 0);
            F2 = new Button(B3, 100, 40, 1);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            mState = Mouse.GetState();
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
        }

        public override void Draw(Game1 g)
        {
            g.GraphicsDevice.Clear(Color.RosyBrown);
            g._spriteBatch.Begin();
            baseDraw(g);
            g._spriteBatch.End();
        }

        public void baseDraw(Game1 g)
        {
            g._spriteBatch.Draw(g.Back,B1,Exit.Dynamic);
            g._spriteBatch.Draw(g.MenuBar, B2, F1.Dynamic);
            g._spriteBatch.DrawString(g.Font, "ACT 1", new Vector2(27,37), F1.Dynamic);
            g._spriteBatch.Draw(g.MenuBar, B3, F2.Dynamic);
            g._spriteBatch.DrawString(g.Font, "ACT 2", new Vector2(27, 87), F2.Dynamic);
        }
    }
}
