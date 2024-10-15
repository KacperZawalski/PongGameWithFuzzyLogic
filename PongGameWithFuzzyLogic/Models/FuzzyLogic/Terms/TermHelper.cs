namespace PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms
{
    public static class TermHelper
    {
        public static double CalculateAscendingSlope(int minValue, int maxValue, double value)
        {
            return (value - minValue) / (maxValue - minValue);
        }
        public static double CalculateDescendingSlope(int minValue, int maxValue, double value)
        {
            return (maxValue - value) / (maxValue - minValue);
        }
    }
}
