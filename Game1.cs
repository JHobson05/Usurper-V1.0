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
        public SpriteFont Font;
        public FrostWizard character1;
        public LightningKnight character2;
        public int Height = 360;
        public int width = 640;
        public EnemyList enemyList = new EnemyList();
        public MoveList moveList = new MoveList();
        public Party party;
        public Texture2D MoveBarSprite;

        //States
        public StateManager stateMgr = new StateManager();
        BattleState battleState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Usurper";
            _graphics.PreferredBackBufferHeight = Height;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.ApplyChanges();
            character1 = new FrostWizard();
            character2 = new LightningKnight();
            party = new Party(character1,character2);
            battleState = new BattleState(enemyList, this,moveList);
            stateMgr.Add(battleState,this);
            stateMgr.Set(battleState);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("gameFont");
            character1.Sprite = Content.Load<Texture2D>(character1.getSpriteString);
            character2.Sprite = Content.Load<Texture2D>(character1.getSpriteString);
            moveList.Moves[0].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[0].SpriteString);
            moveList.Moves[1].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[1].SpriteString);
            moveList.Moves[5].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[5].SpriteString);
            moveList.Moves[6].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[6].SpriteString);
            moveList.Moves[8].SetIconSprite = Content.Load<Texture2D>(moveList.Moves[8].SpriteString);
            enemyList.enemyList[1].Sprite = Content.Load<Texture2D>(enemyList.enemyList[1].getSpriteString);
            MoveBarSprite = Content.Load<Texture2D>("MoveBar");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            stateMgr.Update(gameTime,this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            stateMgr.Draw(this);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
