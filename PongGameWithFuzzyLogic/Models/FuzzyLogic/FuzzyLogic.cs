using Microsoft.Xna.Framework;
using System;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class FuzzyLogic
    {
        private readonly Vector2 _ballPos;
        private readonly Vector2 _racketPos;

        public FuzzyLogic(Vector2 ballPos, Vector2 rackerPos)
        {
            _ballPos = ballPos;
            _racketPos = rackerPos;
        }

        public FuzzyLogic Blurr()
        {
            var diff = _ballPos - _racketPos;
            var distance = Math.Sqrt(Math.Pow(diff.X, 2) + Math.Pow(diff.Y, 2));

            new Blurring().BlurrInput(distance);
            return this;
        }
        public FuzzyLogic Inference()
        {
            return this;
        }
        public FuzzyLogic Sharpen()
        {
            return this;
        }
        public float GetMovement()
        {
            return 0f;
        }
    }
}
