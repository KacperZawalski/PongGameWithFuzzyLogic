using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiModels;

namespace PongGameWithFuzzyLogic
{
    public class PongGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private ContentLoader contentLoader;
        private ViewManager viewManager;
        private SpritesManager spritesManager;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Components.Add(contentLoader = new ContentLoader(this));
            Components.Add(viewManager = new ViewManager(this));
            Components.Add(spritesManager = new SpritesManager(this));

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spritesManager.Sprites = contentLoader.GetSprites();
        }

        protected override void Update(GameTime gameTime)
        {
            viewManager.UpdateComponents(gameTime);
            spritesManager.UpdateSprites(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin();

            viewManager.DrawComponents(gameTime, spriteBatch);
            spritesManager.DrawSprites(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}