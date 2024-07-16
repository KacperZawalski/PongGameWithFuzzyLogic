using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Racket : Sprite
    {
        protected readonly PongGame _pongGame;
        public Racket(Texture2D texture, PongGame pongGame) : base(texture)
        {
            Scale = 0.2f;
            _pongGame = pongGame;
        }
        public abstract Racket SetDefaultPosition();
    }
}
