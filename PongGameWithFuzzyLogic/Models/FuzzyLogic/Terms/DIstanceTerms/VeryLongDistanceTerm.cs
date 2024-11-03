namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //380-400-oo
    public class VeryLongDistanceTerm : ITerm
    {
        public double GetMembership(double distance)
        {
            switch (distance)
            {
                case >= 380 and < 400:
                    return TermHelper.CalculateAscendingSlope(380, 400, distance);
                case >= 400:
                    return 1d;
                default:
                    return 0d;
            }
        }
    }
}
