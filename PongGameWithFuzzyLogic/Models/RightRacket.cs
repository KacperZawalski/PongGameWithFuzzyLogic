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
            var verticalCenter = _pongGame.ViewManager.GamePanel.Dimensions.Y / 2 + _pongGame.ViewManager.GamePanel.Position.Y;
            var horizontalRight = _pongGame.ViewManager.GamePanel.Dimensions.X + _pongGame.ViewManager.GamePanel.BorderWidth * 2 - 20;
            Position = new Vector2(horizontalRight, verticalCenter);

            return this;
        }

        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
