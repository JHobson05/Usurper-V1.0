using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Usurper_V1._0
{
    public class BattleState : State
    {
        BattleManager bMgr;
        MoveList moveList;
        Queue PlayerOrder, AIOrder;
        MouseState mState;
        EnemyList list;
        Party enemies;
        Stack Turns, Turns2;
        Button Move1,Move2,Move3,Move4,Enemy,Enemy2,PTurn;
        bool Attack,enemySelect,enemyChosen,moveChosen, mReleased,enemyturn,gPause,PlayerWin,EnemyWin;
        Vector2 B1, B2, B3,B4,B5,B6,B7,B8,B9;
        int cCharacter,aCharacter, cEnemy,moveIndex,eMove,aEnemy,enemyTemp,QueueSize =2;
        float timer;
        public BattleState (EnemyList list,Game1 g,MoveList moveList) : base(StateID.battle)
        {
            this.moveList = moveList;
            //enemies = new Party(list.enemyList[0],list.enemyList[1]);
            this.list = list;
            bMgr = new BattleManager(g.party,enemies);
        }

        public override void Set(Game1 g)
        {
            if (battleID == 1)
            {
                enemies = new Party(list.enemyList[3]);
                characterReset(g);
                bMgr.partyUpdate(g.party, enemies);
            }
            else if (battleID == 2)
            {
                enemies = new Party(list.enemyList[4]);
                characterReset(g);
                bMgr.partyUpdate(g.party, enemies);
            }
            g.party.party[0].setPosition(B4);
            g.party.party[1].setPosition(B7);
            EnemyWin = false;
            PlayerWin = false;

        }
        public void characterReset(Game1 g)
        {
            for (int i = 0; i < 2; i++)
            {
                g.party.party[i].ResetCharacter();
            }
            enemies.party[0].ResetCharacter();
        }

        public override void Initialize(Game1 g)
        {
            PlayerOrder = new Queue(QueueSize);
            AIOrder = new Queue(QueueSize);
            QueueSetup(PlayerOrder);
            QueueSetup(AIOrder);
            Turns = new Stack(20);
            Turns2 = new Stack(20);
            Attack = false;
            enemyturn = false;
            //cCharacter = PlayerOrder.Dequeue();
            cCharacter = 0;
            aCharacter = cCharacter;
            mReleased = true;
            eMove = 0;
            aEnemy = 0;
            B1 = new Vector2(1, 327);
            Move1 = new Button(B1, 32, 32,0);
            B2 = new Vector2(34, 327);
            Move2 = new Button(B2, 32, 32,1);
            //B3 = new Vector2(600, 50);
            Enemy = new Button(B8, 32, 32, 1);
            B4 = new Vector2(10, 50);
            B5 = new Vector2(67, 327);
            B6 = new Vector2(100, 327);
            B7 = new Vector2(50, 50);
            B8 = new Vector2(550, 50);
            B9 = new Vector2(180,326);
            Move3 = new Button(B5, 32, 32, 2);
            Move4 = new Button(B6, 32, 32, 3);
            //Enemy2 = new Button(B8, 32, 32, 0);
            PTurn = new Button(B9, 32, 32, 0);
            //g.party.party[0].setPosition(B4);
            //g.party.party[1].setPosition(B7);
            //g.enemyList.enemyList[1].setPosition(B3);
            //g.enemyList.enemyList[0].setPosition(B8);
            g.enemyList.enemyList[3].setPosition(B8);
            g.enemyList.enemyList[4].setPosition(B8);
        }

        public override void Update(GameTime gt, Game1 g)
        {
            if (!gPause)
            {
                if (PlayerWin)
                {
                    g.stateMgr.SetWin(1, g);
                    g.setSelect();
                }
                else if (EnemyWin)
                {
                    g.stateMgr.SetWin(2, g);
                    g.setSelect();
                }
                mState = Mouse.GetState();
                // This if statement is used to ensure that things are only registered as one click when the mouse is held down.
                if (mState.LeftButton == ButtonState.Released)
                {
                    mReleased = true;
                }
                //if (Moveorder.Pointer() >= (QueueSize / 2))
                //{
                //    enemyturn = true;
                //}
                //else
                //{
                //    enemyturn = false;
                //}
                if (enemyturn)
                {
                    //aEnemy = 0;
                    //if (!enemies.party[aEnemy].alive)
                    //{
                    //    aEnemy = (aEnemy + 1) % 2;
                    //}
                    eMove = bMgr.EasyAIMove(0, moveList);
                    checkEnd();
                    enemyturn = false;
                    moveChosen = false;
                }
                if ((mState.LeftButton == ButtonState.Pressed) && mReleased)
                {
                    mReleased = false;
                    PlayerMove(g);
                    //if (enemySelect)
                    //{
                        //if (Enemy.checkPressed(mState))
                        //{
                        //    enemyChosen = true;
                        //    if (enemyChosen) cEnemy = 1;
                        //}
                        //else if (Enemy2.checkPressed(mState))
                        //{
                        //    enemyChosen = true;
                        //    if (enemyChosen) cEnemy = 0;
                        //}
                    //}

                    if (Attack && moveChosen)
                    {
                        bMgr.AttackCalculator(aCharacter, moveIndex, cEnemy, moveList,g.party,enemies);
                        checkEnd();
                        if (cCharacter == 0)
                        {
                            Turns.push(moveIndex, cCharacter, cEnemy);
                        }
                        else
                        {
                            Turns2.push(moveIndex, cCharacter, cEnemy);
                        }
                        moveChosen = false;
                        //Moveorder.Enqueue(cCharacter);
                        //if(Moveorder.Pointer() >= (QueueSize / 2))
                        //{
                        //    enemyturn = true;
                        //    gPause = true;
                        //    timer = 0;
                        //    moveChosen = true;
                        //}
                        if (cCharacter == 1)
                        {
                            enemyturn = true;
                            gPause = true;
                            timer = 0;
                            moveChosen = true;
                        }
                        cCharacter = (cCharacter + 1) % 2;
                        aCharacter = cCharacter;
                        if (!g.party.party[cCharacter].alive)
                        {
                            cCharacter = (cCharacter + 1) % 2;
                            enemyturn = true;
                            gPause = true;
                            timer = 0;
                            moveChosen = true;
                        }
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
                g._spriteBatch.DrawString(g.Font, "Select a target!", new Vector2(100, 100), Color.White);
            }
            if (!moveChosen)
            {
                g._spriteBatch.DrawString(g.Font, "Select a move!", new Vector2(100, 100), Color.White);
            }
            if (enemyturn)
            {
                g._spriteBatch.DrawString(g.Font, "The enemy is about to attack", new Vector2(0, 200), Color.White);
            }
            if (!Turns.isEmpty() && !Turns2.isEmpty())
            {
                g._spriteBatch.DrawString(g.Font, "<--", B9, PTurn.Dynamic);
            }
            g._spriteBatch.End();
        }

        public void DrawStart(Game1 g)
        {
            //This method draws everything that is constant on the screen.
            g._spriteBatch.DrawString(g.Font, g.party.party[cCharacter].Name, new Vector2(10, 0), Color.White);
            g._spriteBatch.DrawString(g.Font, ("HP: " + g.party.party[cCharacter].HP.ToString()), new Vector2(10, 20), Color.White);
            g._spriteBatch.Draw(g.party.party[0].Sprite, g.party.party[0].getPosition, g.party.party[0].Colour);
            g._spriteBatch.Draw(g.party.party[1].Sprite, g.party.party[1].getPosition, g.party.party[1].Colour);
            g._spriteBatch.Draw(g.MoveBarSprite, new Vector2(0, 326), Color.White);
            g._spriteBatch.DrawString(g.Font, "Moves", new Vector2(15, 305), Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[0]].GetIconSprite, B1, Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[1]].GetIconSprite, B2, Color.White);
            g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[2]].GetIconSprite, B5, Color.White);
            //g._spriteBatch.Draw(moveList.Moves[g.party.party[cCharacter].Moves[3]].GetIconSprite, B6, Color.White);
            //g._spriteBatch.Draw(enemies.party[1].Sprite, enemies.party[1].getPosition, enemies.party[1].Colour);
            //g._spriteBatch.Draw(g.enemyList.enemyList[1].Sprite, g.enemyList.enemyList[1].getPosition, Color.White);
            //g._spriteBatch.DrawString(g.Font, g.enemyList.enemyList[cCharacter].Name, new Vector2(450, 0), Color.White);
            //g._spriteBatch.Draw(g.enemyList.enemyList[0].Sprite, g.enemyList.enemyList[0].getPosition, Color.White);
            g._spriteBatch.DrawString(g.Font, enemies.party[0].Name, new Vector2(450, 0), Color.White);
            g._spriteBatch.Draw(enemies.party[0].Sprite, enemies.party[0].getPosition, enemies.party[0].Colour);
            g._spriteBatch.DrawString(g.Font, ("HP: " + enemies.party[0].HP.ToString()), new Vector2(500, 20), Color.White);
        }

        //No longer used. The order of moves is determined through this queue. Each value is the index of a character and when its a characters turn they are dequeued then enqueued again.
        public void QueueSetup(Queue queue)
        {
            queue.Enqueue(0);
            queue.Enqueue(1);
        }

        public void checkEnd()
        {
            int Num = bMgr.checkWin();
            if (Num == 0)
            {
                return;
            }
            else if (Num == 1)
            {
                PlayerWin = true;
            }
            else
            {
                EnemyWin = true;
            }
        }

        public void PlayerMove(Game1 g)
        {
            //This method is used to find out which move was selected by the player.
            PTurn.CheckHover(mState);
            if (Move1.checkPressed(mState))
            {
                Attack = true;
                //enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move1.returnID()];
                moveChosen = true;
            }
            if (Move2.checkPressed(mState))
            {
                Attack = true;
                //enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move2.returnID()];
                moveChosen = true;
            }
            if (Move3.checkPressed(mState))
            {
                Attack = true;
                //enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move3.returnID()];
                moveChosen = true;
            }
            if (Move4.checkPressed(mState))
            {
                Attack = true;
                //enemySelect = true;
                moveIndex = g.party.party[cCharacter].Moves[Move4.returnID()];
                moveChosen = true;
            }
            if (PTurn.checkPressed(mState) && !Turns.isEmpty())
            {
                Attack = true;
                //enemySelect = true;
                moveChosen = true;
                Turn turn = Turns.Pop();
                moveIndex = turn.Index;
                aCharacter = turn.Attacker;
                cEnemy = turn.Victim;
            }
        }
    }
}
