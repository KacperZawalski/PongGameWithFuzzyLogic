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
        public static double CalculateMovementTermMembership(double movement, 
                                                             int startOfAscending = -1,
                                                             int startOfMax = -1,
                                                             int startOfDescending = -1)
        {
            if (startOfAscending != -1 && movement >= startOfAscending && movement <= startOfAscending + 1)
            {
                return CalculateAscendingSlope(startOfAscending, startOfAscending + 1, movement);
            }
            else if (startOfMax != -1 && movement >= startOfMax && movement <= startOfMax + 1)
            {
                return 1d;
            }
            else if (startOfDescending != -1 && movement >= startOfDescending && movement <= startOfDescending + 1)
            {
                return CalculateDescendingSlope(startOfDescending, startOfDescending + 1, movement);
            }
            else
            {
                return 0d;
            }
        }
    }
}
