namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    //80-100-200-220
    public sealed class ShortDistanceTerm : Term
    {
        public override double GetMembership(int distance)
        {
            return 2d;
        }

        protected override void InitializeValues()
        {
        }
    }
}
