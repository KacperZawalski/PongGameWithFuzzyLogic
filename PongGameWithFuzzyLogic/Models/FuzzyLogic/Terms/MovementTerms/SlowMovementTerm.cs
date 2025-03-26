namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms.MovementTerms
{
    public class SlowMovementTerm : ITerm
    {
        public double GetMembership(double movement)
        {
            switch (movement) 
            {
                case >= 1 and < 2: return TermHelper.CalculateAscendingSlope(1, 2, movement);
                case >= 2 and < 3: return 1d;
                case >= 3 and < 4: return TermHelper.CalculateDescendingSlope(3, 4, movement);
                default: return 0d;
            }
        }
    }
}
