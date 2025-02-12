namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    public sealed class LongDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case >= 300 and < 350:
                    return TermHelper.CalculateAscendingSlope(280, 300, distance);
                case >= 350 and < 450:
                    return 1d;
                case >= 450 and <= 550:
                    return TermHelper.CalculateDescendingSlope(400, 420, distance);
                default:
                    return 0d;
            }
        }
    }
}
