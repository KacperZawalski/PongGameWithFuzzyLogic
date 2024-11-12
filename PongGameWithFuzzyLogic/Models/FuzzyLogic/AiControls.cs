using Microsoft.Xna.Framework;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public class AiControls
    {
        public FuzzyLogic FuzzyLogic { get; internal set; }
        private readonly Racket _racket;
        private readonly PongGame _pongGame;

        public AiControls(Racket racket, PongGame pongGame)
        {
            _racket = racket;
            _pongGame = pongGame;
            FuzzyLogic = new FuzzyLogic();
        }

        public void HandleControls()
        {
            Vector2 ballPos = _pongGame.Ball.Position;
            Vector2 racketPos = _racket.Rectangle.Center.ToVector2();
            float movement = FuzzyLogic.Blurr(ballPos, racketPos).Inference(_pongGame.AIRules).Sharpen().GetMovement(ballPos, racketPos);
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
