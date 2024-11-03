namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //0-100-120
    public sealed class VeryShortDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case <= 100:
                    return 1d;
                case > 100 and <= 120:
                    return TermHelper.CalculateDescendingSlope(100, 120, distance);
                default:
                    return 0d;
            }
        }
    }
}
