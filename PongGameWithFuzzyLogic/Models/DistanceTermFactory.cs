using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms;

namespace PongGameWithFuzzyLogic.Models
{
    public sealed class DistanceTermFactory : ITermFactory
    {
        public ITerm GetTerm(string termName)
        {
            switch (termName)
            {
                case "VeryShortDistanceTerm": return new VeryShortDistanceTerm();
                case "ShortDistanceTerm": return new ShortDistanceTerm();
                case "MediumDistanceTerm": return new MediumDistanceTerm();
                case "LongDistanceTerm": return new LongDistanceTerm();
                case "VeryLongDistanceTerm": return new VeryLongDistanceTerm();
                default: return new VeryLongDistanceTerm();
            }
        }
    }
}
