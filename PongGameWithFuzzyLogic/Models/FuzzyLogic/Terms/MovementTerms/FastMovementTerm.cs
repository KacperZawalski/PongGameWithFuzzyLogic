namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class FastMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            switch (movement) 
            {
                case >= 6 and < 7: return TermHelper.CalculateAscendingSlope(6, 7, movement);
                case >= 7 and < 8: return 1d;
                case >= 8 and < 9: return TermHelper.CalculateDescendingSlope(8, 9, movement);
                default: return 0d;
            }
        }
    }
}
