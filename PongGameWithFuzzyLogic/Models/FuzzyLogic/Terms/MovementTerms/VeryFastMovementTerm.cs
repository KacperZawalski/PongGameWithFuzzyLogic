namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class VeryFastMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            switch (movement) 
            {
                case >= 8 and < 9: return TermHelper.CalculateAscendingSlope(8, 9, movement);
                case >= 9: return 1d;
                default: return 0d;
            }
        }
    }
}
