using System;
using Xunit;
using BasicCalculator;

namespace BasicCalculatorTest
{
    public class OriginalOperations
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1.5, 1.5, 3)]
        [InlineData(1.5, 2.25, 3.75)]
        [InlineData(-1, -3, -4)]
        [InlineData(-1, 5, 4)]
        [InlineData(1, -3.11, -2.11)]
        public void Add_SimpleValuesShouldAdd(double x, double y, double expected)
        {
            // Arrange
        

            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(5.5, 1.5, 4)]
        [InlineData(1.5, 2.25, -0.75)]
        [InlineData(-1, -3, 2)]
        [InlineData(-1, 5, -6)]
        [InlineData(1, -7.75, 8.75)]
        public void Subtract_SimpleValuesShouldSubtract(double x, double y, double expected)
        {
            // Arrange


            // Act
            double actual = Calculator.Subtract(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }



        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(5, 5, 25)]
        [InlineData(1.5, 1.5, 2.25)]
        [InlineData(-2, -3, 6)]
        [InlineData(-1, 5, -5)]
        [InlineData(6, -3.43, -20.58)]
        public void Multiply_SimpleValuesShouldMultiply(double x, double y, double expected)
        {
            // Arrange


            // Act
            double actual = Calculator.Multiply(x, y);

            // Assert
            Assert.Equal(expected, actual,2);
        }


        [Theory]
        [InlineData(5, 2, 2.5)]
        [InlineData(-2, 4, -0.5)]
        [InlineData(-6, -2.5, 2.4)]
        [InlineData(3.5, 3.5, 1)]
        [InlineData(100, 5, 20)]
        [InlineData(1, 0.0001, 10000)]
        public void Divide_SimpleValuesShouldDivide(double x, double y, double expected)
        {
            // Arrange


            // Act
            double actual = Calculator.Divide(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

     

        [Fact]

        public void Divide_DivideByZeroShouldThrowException()
        {
            // Arrange
            double a = 10;
            double b = 0;


            // Act


            // Assert
            var mess = Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
            Assert.Equal("Divide by zero error.", mess.Message);
        }


        [Fact]

        public void Divide_DivideZeroByZeroShouldThrowException()
        {
            // Arrange
            double a = 0;
            double b = 0;


            // Act


            // Assert
            var mess = Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
            Assert.Equal("Divide by zero error.", mess.Message);
        }


        [Fact]

        public void Divide_DivideZeroByNumber()
        {
            // Arrange
            double x = 0;
            double y = 1;

            double expected = 0;
            // Act
            double actual = Calculator.Divide(x, y);

            // Assert
            Assert.Equal(expected, actual);

        }
    }
}
