using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public abstract class Racket : Sprite
    {
        public Racket(SpriteBatch spriteBatch, Texture2D texture) : base(spriteBatch, texture)
        {
            Scale = 0.2f;
        }
        public abstract void SetDefaultPosition();
    }
}
