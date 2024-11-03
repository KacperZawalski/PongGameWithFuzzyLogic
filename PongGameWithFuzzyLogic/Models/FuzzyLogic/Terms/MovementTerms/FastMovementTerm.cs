namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class FastMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            return TermHelper.CalculateMovementTermMembership(movement, 6, 7, 8);
        }
    }
}
