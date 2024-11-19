using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;
using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms;

namespace PongGameWithFuzzyLogic.Models
{
    public class MovementTermFactory : ITermFactory
    {
        public ITerm GetTerm(string termName)
        {
            switch (termName)
            {
                case "NoneMovementTerm": return new NoneMovementTerm();
                case "VerySlowMovementTerm": return new VerySlowMovementTerm();
                case "SlowMovementTerm": return new SlowMovementTerm();
                case "MediumMovementTerm": return new MediumMovementTerm();
                case "FastMovementTerm": return new MediumMovementTerm();
                case "VeryFastMovementTerm": return new VeryFastMovementTerm();
                default: return new VeryFastMovementTerm();
            }    
        }
    }
}
