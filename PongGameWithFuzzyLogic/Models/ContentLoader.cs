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
            LoadRackets();
        }

        private void LoadBall()
        {
            var ballTexture = _pongGame.Content.Load<Texture2D>("ball");

            sprites.Add(new Ball(_spriteBatch, ballTexture));
        }
        private void LoadRackets()
        {
            var racketTexture = _pongGame.Content.Load<Texture2D>("racket");

            Racket topRacket = new TopRacket(_spriteBatch, racketTexture);
            Racket bottomRacket = new BottomRacket(_spriteBatch, racketTexture);

            sprites.Add(topRacket);
            sprites.Add(bottomRacket);
        }
        public List<Sprite> GetSprites()
        {
            return sprites;
        }
    }
}
