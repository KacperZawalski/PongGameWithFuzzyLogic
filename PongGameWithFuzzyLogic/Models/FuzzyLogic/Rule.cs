using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;

namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class Rule
    {
        public ITerm MovementTerm { get; }
        public ITerm DistanceTerm { get; }
        public bool Enabled { get; set; }
        public Rule(ITerm distance, ITerm movement, bool enabled)
        {
            MovementTerm = movement;
            DistanceTerm = distance;
            Enabled = enabled;
        }
    }
}
