using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace PongGameWithFuzzyLogic.Models
{
    public sealed class RacketControls
    {
        private Racket _racket;
        private PongGame _pongGame;

        public RacketControls(Racket racket, PongGame pongGame) 
        {
            _racket = racket;
            _pongGame = pongGame;
        }
        public void HandleControls()
        {
            var keyboardState = Keyboard.GetState();
            HandleMovement(keyboardState, _racket.MoveUp, -_racket.MovementSensitivity, _racket.IsWithinUpperBound);
            HandleMovement(keyboardState, _racket.MoveDown, _racket.MovementSensitivity, _racket.IsWithinLowerBound);
        }
        private void HandleMovement(KeyboardState keyboardState, Keys key, float movement, Func<bool> boundaryCheck)
        {
            if (keyboardState.IsKeyDown(key) && boundaryCheck())
            {
                _racket.Position = new Vector2(_racket.Position.X, _racket.Position.Y + movement);
            }
        }
    }
}
