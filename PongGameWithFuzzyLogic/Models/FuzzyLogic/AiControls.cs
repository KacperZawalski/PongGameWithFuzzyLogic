using Microsoft.Xna.Framework;
using System;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public class AiControls
    {
        private readonly Racket _racket;
        private readonly Ball _ball;

        public AiControls(Racket racket, Ball ball)
        {
            _racket = racket;
            _ball = ball;
        }

        public void HandleControls()
        {
            float movement = new FuzzyLogic(_ball.Position, _racket.Position).Blurr().Inference().Sharpen().GetMovement();
            
            _racket.Position += new Vector2(0, movement);
        }
    }
}
