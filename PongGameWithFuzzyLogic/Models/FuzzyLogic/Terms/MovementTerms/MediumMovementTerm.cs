namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class MediumMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            return TermHelper.CalculateMovementTermMembership(movement, 4, 5, 6);
        }
    }
}
