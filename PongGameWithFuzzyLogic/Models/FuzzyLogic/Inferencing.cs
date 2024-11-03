using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class Inferencing
    {
        public double[] InferenceInput(double[] blurredInput, List<Rule> rules, List<ITerm> terms)
        {
            double[][] slicedGraphs = new double[blurredInput.Length][];
            for (int i = 0; i < slicedGraphs.Length; i++)
            {
                slicedGraphs[i] = new double[90];
            }

            //Applying rules
            for (int i = 0; i < blurredInput.Length; i++)
            {
                if (blurredInput[i] != 0)
                {
                    Rule ruleToApply = rules.Where(x => x.DistanceTerm.GetType().Name == terms[i].GetType().Name).FirstOrDefault();
                    if (ruleToApply != null)
                    {
                        for (int j = 0; j < 90; j++)
                        {
                            slicedGraphs[i][j] = Math.Min(blurredInput[i], ruleToApply.MovementTerm.GetMembership((j + 1) / 10));
                        }
                    }
                }
            }
            double[] maxes = new double[90];

            for (int i = 0; i < 90; i++)
            {
                maxes[i] = slicedGraphs.Select(x => x[i]).Max();
            }
            return maxes;
        }
    }
}
