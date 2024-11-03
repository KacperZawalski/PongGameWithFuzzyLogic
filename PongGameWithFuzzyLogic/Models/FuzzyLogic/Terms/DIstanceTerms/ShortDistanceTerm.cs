namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //80-100-200-220
    public sealed class ShortDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case >= 80 and < 100:
                    return TermHelper.CalculateAscendingSlope(80, 100, distance);
                case >= 100 and < 200:
                    return 1d;
                case >= 200 and < 220:
                    return TermHelper.CalculateDescendingSlope(200, 220, distance);
                default:
                    return 0d;
            }
        }
    }
}
