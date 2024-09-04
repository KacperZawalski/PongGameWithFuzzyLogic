using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiModels;
using System;

namespace PongGameWithFuzzyLogic
{
    public class PongGame : Game
    {
        public ViewManager ViewManager;
        public const int GameWindowWidth = 1000;
        public const int GameWindowHeight = 800;
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
        private GameState gameState = GameState.WaitingForServe;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GameWindowWidth;
            _graphics.PreferredBackBufferHeight = GameWindowHeight;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Components.Add(ViewManager = new ViewManager(this));
            Components.Add(contentLoader = new ContentLoader(this));
            Components.Add(spritesManager = new SpritesManager(this));

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spritesManager.Sprites = contentLoader.GetSprites();
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
            gameState = new GameStateFactory().GetGameState(this);
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