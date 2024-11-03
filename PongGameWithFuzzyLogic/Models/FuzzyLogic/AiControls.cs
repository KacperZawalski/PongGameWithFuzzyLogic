using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public class AiControls
    {
        private readonly Racket _racket;
        private readonly PongGame _pongGame;

        public AiControls(Racket racket, PongGame pongGame)
        {
            _racket = racket;
            _pongGame = pongGame;
        }

        public void HandleControls()
        {
            float movement = new FuzzyLogic(_pongGame.Ball.Position, _racket.Rectangle.Center.ToVector2()).Blurr().Inference().Sharpen().GetMovement();
            if (_pongGame.GameState.Equals(GameState.WaitingForLeft))
            {
                
            }
            if ((_racket.IsWithinLowerBound() && movement > 0) || (_racket.IsWithinUpperBound() && movement < 0))
            {
                _racket.Position += new Vector2(0, movement);
            }
        }
    }
}
