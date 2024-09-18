using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && IsWithinUpperBound())
            {
                Position = new Vector2(Position.X, Position.Y - MovementSensitivity);
            }
            if (keyboardState.IsKeyDown(Keys.Down) && IsWithinLowerBound())
            {
                Position = new Vector2(Position.X, Position.Y + MovementSensitivity);
            }
        }
        private bool IsWithinUpperBound()
        {
            return Position.Y - Texture.Width / 2 * Scale > _pongGame.ViewManager.GamePanel.Position.Y;
        }
        private bool IsWithinLowerBound()
        {
            return Position.Y + Texture.Width / 2 * Scale < _pongGame.ViewManager.GamePanel.Position.Y + _pongGame.ViewManager.GamePanel.Dimensions.Y;
        }
    }
}
