namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class NoneMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            return movement < 0.1 ? 1d : 0d;
        }
    }
}
