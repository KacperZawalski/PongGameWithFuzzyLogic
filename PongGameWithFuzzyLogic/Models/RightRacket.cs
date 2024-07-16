using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public class RightRacket : Racket
    {
        public RightRacket(Texture2D texture, PongGame pongGame) : base(texture, pongGame)
        {
            SetDefaultPosition();
        }

        public override Racket SetDefaultPosition()
        {
            Position = new Vector2(700,400);
            return this;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
