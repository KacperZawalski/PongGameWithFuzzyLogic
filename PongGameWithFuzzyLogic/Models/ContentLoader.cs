using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models
{
    public sealed class ContentLoader
    {
        public List<Sprite> sprites = new List<Sprite>();
        private readonly PongGame _pongGame;
        private SpriteBatch _spriteBatch;

        public ContentLoader()
        {
        }

        public ContentLoader(PongGame pongGame, SpriteBatch spriteBatch)
        {
            _pongGame = pongGame;
            _spriteBatch = spriteBatch;
        }

        public void LoadContent()
        {
            LoadBall();
        }

        private void LoadBall()
        {
            var ballTexture = _pongGame.Content.Load<Texture2D>("ball");

            Ball ball = new Ball(_spriteBatch, ballTexture);
            ball.Scale = 0.5f;
            sprites.Add(ball);
        }

        public List<Sprite> GetSprites()
        {
            return sprites;
        }
    }
}
