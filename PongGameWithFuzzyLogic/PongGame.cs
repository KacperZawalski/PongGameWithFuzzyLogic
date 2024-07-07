using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongGameWithFuzzyLogic.Models;
using PongGameWithFuzzyLogic.UiComponents;

namespace PongGameWithFuzzyLogic
{
    public class PongGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentLoader _contentLoader;
        private ViewManager _viewManager;
        private SpritesManager _spritesManager;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Components.Add(_contentLoader = new ContentLoader(this));
            Components.Add(_viewManager = new ViewManager(this));
            Components.Add(_spritesManager = new SpritesManager(this));

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spritesManager.Sprites = _contentLoader.GetSprites();
        }

        protected override void Update(GameTime gameTime)
        {
            _viewManager.UpdateComponents(gameTime);
            _spritesManager.UpdateSprites(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            _spriteBatch.Begin();

            _viewManager.DrawComponents(gameTime, _spriteBatch);
            _spritesManager.DrawSprites(gameTime, _spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}