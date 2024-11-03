using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;

namespace PongGameWithFuzzyLogicTests
{

    public class TermHelperTests
    {
        [Fact]
        public void AscendingSlope_WithValidInput_ReturnsOutputInRange()
        {
            //Arrange
            int minValue = 1;
            int maxValue = 300;
            double value = 150d;

            //Act
            var result = TermHelper.CalculateAscendingSlope(minValue, maxValue, value);

            //Assert
            Assert.InRange(result, 0, 1);
        }
        [Fact]
        public void DescendingSlope_WithValidInput_ReturnsOutputInRange()
        {
            //Arrange
            int minValue = 1;
            int maxValue = 300;
            double value = 150d;

            //Act
            var result = TermHelper.CalculateDescendingSlope(minValue, maxValue, value);

            //Assert
            Assert.InRange(result, 0, 1);
        }

        [Fact]
        public void DescendingSlope_WithValidInput_ReturnsDescendingOutput()
        {
            //Arrange
            int minValue = 1;
            int maxValue = 10;
            double[] results = new double[10];
            bool isDescending = true;
            
            //Act
            results[0] = TermHelper.CalculateDescendingSlope(minValue, maxValue, 1);

            for (int i = 1; i < results.Length; i++)
            {
                results[i] = TermHelper.CalculateDescendingSlope(minValue, maxValue, i + 1);
                if (results[i - 1] < results[i])
                {
                    isDescending = false;
                }
            }
            //Assert
            Assert.True(isDescending);
        }
        [Fact]
        public void AscendingSlope_WithValidInput_ReturnsAscendingOutput()
        {
            //Arrange
            int minValue = 1;
            int maxValue = 10;
            double[] results = new double[10];
            bool isAscending = true;

            //Act
            results[0] = TermHelper.CalculateAscendingSlope(minValue, maxValue, 1);

            for (int i = 1; i < results.Length; i++)
            {
                results[i] = TermHelper.CalculateAscendingSlope(minValue, maxValue, i + 1);
                if (results[i - 1] > results[i])
                {
                    isAscending = false;
                }
            }
            //Assert
            Assert.True(isAscending);
        }
    }
}