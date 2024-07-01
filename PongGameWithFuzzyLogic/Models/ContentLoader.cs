using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models
{
    public sealed class ContentLoader : IGameComponent
    {
        public List<Sprite> Sprites = new List<Sprite>();
        private readonly List<string> _fontNames = new List<string>();
        private readonly PongGame _pongGame;
        public ContentLoader(PongGame pongGame)
        {
            _pongGame = pongGame;
            _fontNames.Add("defaultFont");
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

            Sprites.Add(new Ball(ballTexture));
        }
        private void LoadRackets()
        {
            var racketTexture = _pongGame.Content.Load<Texture2D>("racket");

            Racket topRacket = new TopRacket(racketTexture);
            Racket bottomRacket = new BottomRacket(racketTexture);

            Sprites.Add(topRacket);
            Sprites.Add(bottomRacket);
        }

        public void Initialize()
        {
            LoadContent();
        }
    }
}
