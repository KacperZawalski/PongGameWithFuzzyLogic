using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public class BottomRacket : Racket
    {
        public BottomRacket(SpriteBatch spriteBatch, Texture2D texture) : base(spriteBatch, texture)
        {
        }

        public override void SetDefaultPosition()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
