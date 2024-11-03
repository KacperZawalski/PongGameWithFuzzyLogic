namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class VeryFastMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            return TermHelper.CalculateMovementTermMembership(movement, startOfAscending: 8);
        }
    }
}
