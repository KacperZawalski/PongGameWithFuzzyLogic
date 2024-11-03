namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class VerySlowMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            return TermHelper.CalculateMovementTermMembership(movement, 1, 2, 3);
        }
    }
}
