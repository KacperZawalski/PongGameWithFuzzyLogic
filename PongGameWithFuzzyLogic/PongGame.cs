using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiModels;

namespace PongGameWithFuzzyLogic
{
    public class PongGame : Game
    {
        public const int GameWindowWidth = 1000;
        public const int GameWindowHeight = 800;
        public int LeftScore { get; set; }
        public int RightScore { get; set; }
        public Ball Ball { get; set; }
        public Racket LeftRacket { get; set; }
        public Racket RightRacket { get; set; }
        public ViewManager ViewManager { get; internal set; }
        private SpriteBatch spriteBatch;
        private SpritesManager spritesManager;
        private readonly GraphicsDeviceManager _graphics;

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
        }
        private GameState _gameState = GameState.FirstServe;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GameWindowWidth;
            _graphics.PreferredBackBufferHeight = GameWindowHeight;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        public void Restart()
        {
            _gameState = GameState.FirstServe;
            RightScore = 0;
            LeftScore = 0;
        }

        protected override void Initialize()
        {
            ViewManager = new ViewManager(this);
            spritesManager = new SpritesManager(this);

            var ballTexture = Content.Load<Texture2D>("ball");

            Ball = new Ball(ballTexture, this);


            var racketTexture = Content.Load<Texture2D>("racket");

            LeftRacket = new Racket(racketTexture, this);
            RightRacket = new Racket(racketTexture, this);


            spriteBatch = new SpriteBatch(GraphicsDevice);

            Components.Add(ViewManager);
            Components.Add(spritesManager);

            spritesManager.Sprites.Add(Ball);
            spritesManager.Sprites.Add(LeftRacket);
            spritesManager.Sprites.Add(RightRacket);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateGameState();
            ViewManager.UpdateComponents(gameTime, spriteBatch);
            spritesManager.UpdateSprites(gameTime, spriteBatch);

            base.Update(gameTime);
        }

        private void UpdateGameState()
        {
            _gameState = GameStateFactory.GetGameState(this);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin();

            ViewManager.DrawComponents(gameTime, spriteBatch);
            spritesManager.DrawSprites(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}