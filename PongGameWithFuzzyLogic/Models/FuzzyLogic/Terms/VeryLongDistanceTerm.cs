namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //380-400-oo
    public class VeryLongDistanceTerm : Term
    {
        public override double GetMembership(int distance)
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

        protected override void InitializeValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
