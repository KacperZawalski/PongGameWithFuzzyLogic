using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public class TopRacket : Racket
    {
        public TopRacket(SpriteBatch spriteBatch, Texture2D texture) : base(spriteBatch, texture)
        {
        }

        public override void SetDefaultPosition()
        {
            Position = new Vector2();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
