using Microsoft.Xna.Framework;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class FuzzyLogic
    {
        private const float _movementMultiplier = 2f;
        private List<ITerm> _terms = new List<ITerm>
        {
            new VeryShortDistanceTerm(),
            new ShortDistanceTerm(),
            new MediumDistanceTerm(),
            new LongDistanceTerm(),
            new VeryLongDistanceTerm(),
        };
        private double[] _blurredInput;
        private double[] _inferencedInput;
        private float _output;
        public FuzzyLogic()
        {
        }

        public FuzzyLogic Blurr(Vector2 ballPos, Vector2 racketPos)
        {
            var distance = ballPos.X - racketPos.X;

            _blurredInput = new Blurring().BlurrInput(distance, _terms);
            return this;
        }
        public FuzzyLogic Inference(List<Rule> rules)
        {
            if (_blurredInput != null)
            {
                _inferencedInput = new Inferencing().InferenceInput(_blurredInput, rules, _terms);
            }
            return this;
        }
        public FuzzyLogic Sharpen()
        {
            if (_inferencedInput != null)
            {
                _output = new Sharpening().SharpenInput(_inferencedInput);
            }
            return this;
        }
        public float GetMovement(Vector2 ballPos, Vector2 racketPos)
        {
            _output *= _movementMultiplier;
            var difference = Math.Abs(ballPos.Y - racketPos.Y);
            if (difference - Math.Abs(_output) < 0)
            {
                _output = difference;
            }
            if (ballPos.Y < racketPos.Y)
            {
                _output *= -1;
            }
            return _output;
        }
    }
}
