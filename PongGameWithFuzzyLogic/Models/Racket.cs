using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Racket : Sprite
    {
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Position.ToPoint(), new Point(Texture.Width * (int)Scale, Texture.Height * (int)Scale));
            }
        }
        protected readonly PongGame _pongGame;
        public int MovementSensitivity { get; set; }
        public Racket(Texture2D texture, PongGame pongGame) : base(texture)
        {
            MovementSensitivity = 6;
            Rotation = MathHelper.ToRadians(90);
            Scale = 0.2f;
            _pongGame = pongGame;
        }
        public abstract Racket SetDefaultPosition();
    }
}
