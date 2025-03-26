namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class VerySlowMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            switch (movement) 
            {
                case > 0 and <= 1: return TermHelper.CalculateAscendingSlope(0, 1, movement);
                case > 1 and <= 2: return TermHelper.CalculateDescendingSlope(1, 2, movement);
                default: return 0d;
            }
        }
    }
}
