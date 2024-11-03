namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class SlowMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            return TermHelper.CalculateMovementTermMembership(movement, 3, 4, 5);
        }
    }
}
