using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiModels;
using System;
using System.Diagnostics;

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
        private ContentLoader contentLoader;
        private SpritesManager spritesManager;
        private readonly GraphicsDeviceManager _graphics;

        public GameState GameState 
        { 
            get
            {
                return gameState;
            }
        }
        private GameState gameState = GameState.FirstServe;

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
            gameState = GameState.FirstServe;
            RightScore = 0;
            LeftScore = 0;
        }

        protected override void Initialize()
        {
            ViewManager = new ViewManager(this);
            contentLoader = new ContentLoader(this);
            spritesManager = new SpritesManager(this);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Components.Add(ViewManager);
            Components.Add(contentLoader);
            Components.Add(spritesManager);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spritesManager.Sprites.AddRange(contentLoader.GetSprites());
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
            gameState = GameStateFactory.GetGameState(this);
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