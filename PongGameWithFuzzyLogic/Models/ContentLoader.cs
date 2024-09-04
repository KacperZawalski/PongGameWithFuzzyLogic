using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models
{
    public sealed class ContentLoader : IGameComponent
    {
        public List<Sprite> Sprites = new List<Sprite>();
        private readonly PongGame _pongGame;
        public ContentLoader(PongGame pongGame)
        {
            _pongGame = pongGame;
        }

        public void LoadContent()
        {
            LoadBall();
            LoadRackets();
        }

        public List<Sprite> GetSprites()
        {
            return Sprites;
        }
        private void LoadBall()
        {
            var ballTexture = _pongGame.Content.Load<Texture2D>("ball");

            Sprites.Add(new Ball(ballTexture, _pongGame));
        }
        private void LoadRackets()
        {
            var racketTexture = _pongGame.Content.Load<Texture2D>("racket");

            Racket topRacket = new LeftRacket(racketTexture, _pongGame);
            Racket bottomRacket = new RightRacket(racketTexture, _pongGame);

            Sprites.Add(topRacket);
            Sprites.Add(bottomRacket);
        }

        public void Initialize()
        {
            LoadContent();
        }
    }
}
