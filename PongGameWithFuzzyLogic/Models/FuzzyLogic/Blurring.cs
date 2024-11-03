using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class Blurring
    {
        public double[] BlurrInput(double distance, List<ITerm> terms)
        {
            double[] results = new double[terms.Count];
            for (int i = 0; i < terms.Count; i++)
            {
                results[i] = terms[i].GetMembership(distance);
            }
            return results;
        }
    }
}
