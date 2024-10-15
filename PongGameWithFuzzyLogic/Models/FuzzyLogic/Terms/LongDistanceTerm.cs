namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //280-300-400-420
    public sealed class LongDistanceTerm : Term
    {
        public override double GetMembership(int distance)
        {
            switch (distance)
            {
                case >= 280 and < 300:
                    return TermHelper.CalculateAscendingSlope(280, 300, distance);
                case >= 300 and < 400:
                    return 1d;
                case >= 400 and <= 420:
                    return TermHelper.CalculateDescendingSlope(400, 420, distance);
                default:
                    return 0d;
            }
        }

        protected override void InitializeValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
