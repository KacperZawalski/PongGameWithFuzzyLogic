using Microsoft.Xna.Framework;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms;
using System;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class FuzzyLogic
    {
        private readonly Vector2 _ballPos;
        private readonly Vector2 _racketPos;
        private List<ITerm> _terms = new List<ITerm>
        {
            new VeryShortDistanceTerm(),
            new ShortDistanceTerm(),
            new MediumDistanceTerm(),
            new LongDistanceTerm(),
            new VeryLongDistanceTerm(),
        };
        private List<Rule> _rules = new List<Rule>
        {
            new Rule(new VeryLongDistanceTerm(), new NoneMovementTerm()),
            new Rule(new LongDistanceTerm(), new SlowMovementTerm()),
            new Rule(new MediumDistanceTerm(), new FastMovementTerm()),
            new Rule(new ShortDistanceTerm(), new VeryFastMovementTerm()),
            new Rule(new VeryShortDistanceTerm(), new MediumMovementTerm()),
        };
        private double[] _blurredInput;
        private double[] _inferencedInput;
        private float _output;
        public FuzzyLogic(Vector2 ballPos, Vector2 rackerPos)
        {
            _ballPos = ballPos;
            _racketPos = rackerPos;
        }

        public FuzzyLogic Blurr()
        {
            var diff = _ballPos - _racketPos;
            var distance = Math.Sqrt(Math.Pow(diff.X, 2) + Math.Pow(diff.Y, 2));

            _blurredInput = new Blurring().BlurrInput(distance, _terms);
            return this;
        }
        public FuzzyLogic Inference()
        {
            if (_blurredInput != null)
            {
                _inferencedInput = new Inferencing().InferenceInput(_blurredInput, _rules, _terms);
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
        public float GetMovement()
        {
            if (_output != null)
            {
                if (_ballPos.Y < _racketPos.Y)
                {
                    _output *= -1;
                }
                return _output;
            }
            return 0f;
        }
    }
}
