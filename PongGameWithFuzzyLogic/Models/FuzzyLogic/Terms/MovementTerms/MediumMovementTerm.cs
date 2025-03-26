namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class MediumMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            switch (movement) 
            {
                case >= 3 and < 4: return TermHelper.CalculateAscendingSlope(3, 4, movement);
                case >= 4 and < 6: return 1d;
                case >= 6 and < 7: return TermHelper.CalculateDescendingSlope(6, 7, movement);
                default: return 0d;
            }
        }
    }
}
