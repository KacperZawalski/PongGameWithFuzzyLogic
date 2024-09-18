using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PongGameWithFuzzyLogic.Models
{
    public class Racket : Sprite
    {
        public Keys MoveUp { get; set; } = Keys.W;
        public Keys MoveDown { get; set; } = Keys.S;
        protected readonly PongGame _pongGame;
        public int MovementSensitivity { get; set; }
        public Racket(Texture2D texture, PongGame pongGame) : base(texture)
        {
            MovementSensitivity = 6;
            Scale = 0.2f;
            _pongGame = pongGame;
        }
        public override void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var keyboardState = Keyboard.GetState();

            HandleMovement(keyboardState, MoveUp, -MovementSensitivity, IsWithinUpperBound);
            HandleMovement(keyboardState, MoveDown, MovementSensitivity, IsWithinLowerBound);
        }
        private void HandleMovement(KeyboardState keyboardState, Keys key, float movement, Func<bool> boundaryCheck)
        {
            if (keyboardState.IsKeyDown(key) && boundaryCheck())
            {
                Position = new Vector2(Position.X, Position.Y + movement);
            }
        }

        private bool IsWithinUpperBound()
        {
            return Position.Y > _pongGame.ViewManager.GamePanel.Position.Y + _pongGame.ViewManager.GamePanel.BorderWidth / 2;
        }
        private bool IsWithinLowerBound()
        {
            return Position.Y + Rectangle.Height < _pongGame.ViewManager.GamePanel.Position.Y + _pongGame.ViewManager.GamePanel.Dimensions.Y;
        }
    }
}
