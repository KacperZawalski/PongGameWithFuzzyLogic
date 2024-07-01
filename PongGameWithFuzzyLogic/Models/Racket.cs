using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Racket : Sprite
    {
        public Racket(Texture2D texture) : base(texture)
        {
            Scale = 0.2f;
        }
        public abstract void SetDefaultPosition();
    }
}
