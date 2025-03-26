namespace PongGameWithFuzzyLogic.Models.FuzzyLogic
{
    public sealed class Sharpening
    {
        public float SharpenInput(double[] inferencedInput)
        {
            double sum = 0d;
            double divisor = 0d;
            for (int i = 0; i < inferencedInput.Length; i++)
            {
                sum += inferencedInput[i] * (i + 1);
                divisor += inferencedInput[i];
            }
            return (float)(sum / divisor) / 10;
        }
    }
}
