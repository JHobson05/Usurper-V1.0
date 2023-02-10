using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Usurper_V1._0
{
    public class Game1 : Game
    {
        //Graphics
        public GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public SpriteFont Font,sFont;
        public FrostWizard character1;
        public LightningKnight character2;
        public int Height = 360;
        public int width = 640;
        public EnemyList enemyList = new EnemyList();
        public MoveList moveList = new MoveList();
        public Party party;
        public Texture2D MoveBarSprite,Back,MenuBar;

        //States
        public StateManager stateMgr = new StateManager();
        BattleState battleState;
        MenuState menuState;
        SelectState selectState;

        //Variables
        private int BattleID;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public  void SetAct(int id)
        {
            BattleID = id;
        }

        protected override void Initialize()
        {
            Window.Title = "Usurper";
            _graphics.PreferredBackBufferHeight = Height;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.ApplyChanges();
            character1 = new FrostWizard();
            character2 = new LightningKnight();
            party = new Party(character1,character2);
            battleState = new BattleState(enemyList, this,moveList);
            menuState = new MenuState(this);
            selectState = new SelectState(this);
            stateMgr.Add(battleState,this);
            stateMgr.Add(menuState, this);
            stateMgr.Add(selectState, this);
            stateMgr.Set(menuState);
            base.Initialize();
        }

        public void setMenu()
        {
            stateMgr.Set(menuState);
        }

        public void setBattle()
        {
            stateMgr.Set(battleState);
        }

        public void setSelect()
        {
            stateMgr.Set(selectState);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("gameFont");
            sFont = Content.Load<SpriteFont>("SmallGameFont");
            character1.Sprite = Content.Load<Texture2D>(character1.getSpriteString);
            character2.Sprite = Content.Load<Texture2D>(character2.getSpriteString);
            moveList.Moves[0].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[0].SpriteString);
            moveList.Moves[1].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[1].SpriteString);
            moveList.Moves[5].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[5].SpriteString);
            moveList.Moves[6].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[6].SpriteString);
            moveList.Moves[8].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[8].SpriteString);
            moveList.Moves[9].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[9].SpriteString);
            moveList.Moves[13].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[13].SpriteString);
            enemyList.enemyList[1].Sprite = Content.Load<Texture2D>(enemyList.enemyList[1].getSpriteString);
            enemyList.enemyList[0].Sprite = Content.Load<Texture2D>(enemyList.enemyList[1].getSpriteString);
            enemyList.enemyList[3].Sprite = Content.Load<Texture2D>(enemyList.enemyList[3].getSpriteString);
            enemyList.enemyList[4].Sprite = Content.Load<Texture2D>(enemyList.enemyList[4].getSpriteString);
            Back = Content.Load<Texture2D>("ExitIcon");
            MenuBar = Content.Load<Texture2D>("MenuBar");
            MoveBarSprite = Content.Load<Texture2D>("MoveBar");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            stateMgr.Update(gameTime,this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            stateMgr.Draw(this);

            base.Draw(gameTime);
        }

        public void Quit()
        {
            this.Exit();
        }
    }
}
