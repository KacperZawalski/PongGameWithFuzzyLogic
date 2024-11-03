namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //180-200-300-320
    public sealed class MediumDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case >= 180 and < 200:
                    return TermHelper.CalculateAscendingSlope(180, 200, distance);
                case >= 200 and < 300:
                    return 1d;
                case >= 300 and < 320:
                    return TermHelper.CalculateDescendingSlope(300, 320, distance);
                default:
                    return 0;
            }
        }
    }
}
