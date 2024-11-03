using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class Rule
    {
        public ITerm MovementTerm { get; }
        public ITerm DistanceTerm { get; }
        public Rule(ITerm distance, ITerm movement)
        {
            MovementTerm = movement;
            DistanceTerm = distance;
        }
    }
}
