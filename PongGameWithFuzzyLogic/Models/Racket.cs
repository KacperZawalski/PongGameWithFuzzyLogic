using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Racket : Sprite
    {
        protected readonly PongGame _pongGame;
        public int Sensitivity { get; set; }
        public Racket(Texture2D texture, PongGame pongGame) : base(texture)
        {
            Sensitivity = 4;
            Rotation = MathHelper.ToRadians(90);
            Scale = 0.2f;
            _pongGame = pongGame;
        }
        public abstract Racket SetDefaultPosition();
    }
}
