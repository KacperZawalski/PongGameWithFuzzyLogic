using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGameWithFuzzyLogic.Models;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic
{
    public class PongGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentLoader _contentLoader;
        private List<Sprite> _sprites;

        public PongGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _contentLoader = new ContentLoader(this, _spriteBatch);

            base.Initialize();
        }


        protected override void LoadContent()
        { 
            _contentLoader.LoadContent();
            _sprites = _contentLoader.GetSprites();
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            _spriteBatch.Begin();

            foreach (var sprite in _sprites)
            {
                sprite.Draw(gameTime);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}