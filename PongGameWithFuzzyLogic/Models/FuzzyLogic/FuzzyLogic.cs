using Microsoft.Xna.Framework;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class FuzzyLogic
    {
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
            var diff = ballPos - racketPos;
            var distance = Math.Sqrt(Math.Pow(diff.X, 2) + Math.Pow(diff.Y, 2));

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
            if (ballPos.Y < racketPos.Y)
            {
                _output *= -1;
            }
            return _output;
        }
    }
}
