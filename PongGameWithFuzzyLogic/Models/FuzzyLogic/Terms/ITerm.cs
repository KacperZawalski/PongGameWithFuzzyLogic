using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    public interface ITerm
    {
        public double GetMembership(int distance);
    }
}
