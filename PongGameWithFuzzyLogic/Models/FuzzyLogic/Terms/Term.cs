using System.Collections.Generic;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    public abstract class Term : ITerm
    {
        public List<double> Values { get; }
        public abstract double GetMembership(int distance);

        protected abstract void InitializeValues();
    }
}
