namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    public class VeryLongDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case >= 400 and < 600:
                    return TermHelper.CalculateAscendingSlope(380, 400, distance);
                case >= 600:
                    return 1d;
                default:
                    return 0d;
            }
        }
    }
}
