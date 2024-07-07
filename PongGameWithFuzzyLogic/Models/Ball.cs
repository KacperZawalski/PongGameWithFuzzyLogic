using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public class Ball : Sprite
    {
        public Ball(Texture2D texture) : base(texture)
        {
            Scale = 0.3f;

        }
        public override void Update(GameTime gameTime)
        {
        }
    }
}
