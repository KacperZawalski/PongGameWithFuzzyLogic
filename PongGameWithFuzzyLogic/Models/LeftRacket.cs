using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGameWithFuzzyLogic.Models
{
    public class LeftRacket : Racket
    {
        public LeftRacket(Texture2D texture, PongGame pongGame) : base(texture, pongGame)
        {
            SetDefaultPosition();
        }

        public override Racket SetDefaultPosition()
        {
            var verticalCenter = _pongGame.ViewManager.GamePanel.Dimensions.Y / 2 + _pongGame.ViewManager.GamePanel.Position.Y;

            Position = new Vector2(10, verticalCenter);

            return this;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
