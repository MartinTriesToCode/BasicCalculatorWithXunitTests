using System;
using System.Collections.Generic;
using System.Text;
using BasicCalculator;
using Xunit;

namespace BasicCalculatorTest
{
    public class OverloadedOperations
    {

        [Fact]

        public void Add_SimpleNumbersShouldAdd()
        {
            // Arrange
            double[] numbers = new double[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            double expected = 45;

            // Act
            double actual = Calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);

        }

    

        [Fact]
      
        public void Add_HarderNumbersShouldAdd()
        {

            // Arrange
            double[] numbers = new double[] { -100.65, 45.76543, 183421, 0, -0.762};
            double expected = 183365.35343;

            // Act
            double actual = Calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, actual,5);
        }


        [Theory]
        [InlineData(new double[] { -1, -2, -3, -4, -5 }, -15)]
        [InlineData(new double[] { 0.5, -0.5, -3, 3,  }, 0)]
        [InlineData(new double[] { double.PositiveInfinity, double.NegativeInfinity}, double.NaN)]
        [InlineData(new double[] {double.MaxValue, 1}, double.MaxValue)]
        [InlineData(new double[] { double.NegativeInfinity, -1 }, double.NegativeInfinity)]

        public void Add_TestingAdditionalNumbers(double[] numbers, double expected)
        {
            double actual = Calculator.Add(numbers);

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void Subtract_SimpleNumbersShouldSubtract()
        {
            // Arrange
            double[] numbers = new double[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            double expected = -45;

            // Act
            double actual = Calculator.Subtract(numbers);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        
        public void Subtract_HarderNumbersShouldSubtract()
        {
            // Arrange
            double[] numbers = new double[] { -10.1, 20.2, 76.4, -0.7, 0};
            
            double expected = -106;
            
            // Act
            double actual = Calculator.Subtract(numbers);

            // Assert
            Assert.Equal(expected, actual, 4);
        }

        [Theory]
        [InlineData(new double[] { 0, 0, 0, 0, 0 },0)]
        [InlineData(new double[] { double.NaN, -1}, double.NaN)]
        [InlineData(new double[] { double.PositiveInfinity, double.NegativeInfinity }, double.NaN)]
        [InlineData(new double[] { double.MaxValue, 1 }, double.MaxValue)]
        [InlineData(new double[] { double.NegativeInfinity, -1 }, double.NegativeInfinity)]

        public void Subtract_TestingAdditionalNumbers(double[] numbers, double expected)
        {
            double actual = Calculator.Add(numbers);

            Assert.Equal(expected, actual);
        }
    }
}
