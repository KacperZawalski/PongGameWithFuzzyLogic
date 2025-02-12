namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //80-100-200-220
    public sealed class ShortDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case >= 50 and < 70:
                    return TermHelper.CalculateAscendingSlope(80, 100, distance);
                case >= 70 and < 170:
                    return 1d;
                case >= 170 and < 200:
                    return TermHelper.CalculateDescendingSlope(200, 220, distance);
                default:
                    return 0d;
            }
        }
    }
}
