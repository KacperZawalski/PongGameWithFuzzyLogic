using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models
{
    public sealed class ContentLoader : IGameComponent
    {
        public List<Sprite> Sprites { get; } = new List<Sprite>();
        private readonly PongGame _pongGame;
        public ContentLoader(PongGame pongGame)
        {
            _pongGame = pongGame;
        }
        public void AddSprite(Sprite sprite)
        {
            Sprites.Add(sprite);
        }
        public void LoadContent()
        {
            LoadRackets();
            LoadBall();
        }

        private void LoadBall()
        {
            var ballTexture = _pongGame.Content.Load<Texture2D>("ball");

            _pongGame.Ball = new Ball(ballTexture, _pongGame);

            Sprites.Add(_pongGame.Ball);
        }

        public List<Sprite> GetSprites()
        {
            return Sprites;
        }
        private void LoadRackets()
        {
            var racketTexture = _pongGame.Content.Load<Texture2D>("racket");

            _pongGame.LeftRacket = new LeftRacket(racketTexture, _pongGame);
            _pongGame.RightRacket = new RightRacket(racketTexture, _pongGame);

            Sprites.Add(_pongGame.LeftRacket);
            Sprites.Add(_pongGame.RightRacket);
        }

        public void Initialize()
        {
            LoadContent();
        }
    }
}
