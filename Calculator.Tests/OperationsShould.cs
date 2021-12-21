using System;
using Xunit;

namespace Calculator.Tests
{
    /// <summary>
    /// The test class for the operations class in the calculator.
    /// </summary>
    public class OperationsShould : IClassFixture<OperationsFixture>
    {
        private readonly Operations _sut;

        /// <summary>
        /// Initializes an operations instance to be the system under test.
        /// </summary>
        /// <param name="operationsFixture">The fixture to retrieve the operations instance from.</param>
        public OperationsShould(OperationsFixture operationsFixture)
        {
            _sut = operationsFixture.OperationsInstance;
        }

        /// <summary>
        /// Asserts the sum to be correct when adding.
        /// </summary>
        /// <param name="firstTerm">The first term.</param>
        /// <param name="secondTerm">The second term.</param>
        /// <param name="expectedSum">The expected sum.</param>
        [Theory]
        [InlineData(5, 5, 10.0)]
        [InlineData(-5,-5, -10.0)]
        [InlineData(5, -5, 0)]
        [InlineData(5.001, 5.0, 10.001)]
        public void AddCorrectly(double firstTerm, double secondTerm, double expectedSum)
        {
            Assert.Equal(expectedSum, _sut.Add(firstTerm, secondTerm), 3);
        }

        /// <summary>
        /// Asserts the difference to be correct when subtracting.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <param name="expectedDifference">The expected difference.</param>
        [Theory]
        [InlineData(5, 5, 0.0)]
        [InlineData(-5, -5, 0.0)]
        [InlineData(5, -5, 10)]
        [InlineData(5.001, 5.0, 0.001)]
        public void SubtractCorrectly(double minuend, double subtrahend, double expectedDifference)
        {
            Assert.Equal(expectedDifference, _sut.Subtract(minuend, subtrahend), 3);
        }

        /// <summary>
        /// Asserts the product to be correct when multiplying.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <param name="expectedProduct">The expected product.</param>
        [Theory]
        [InlineData(5, 5, 25.0)]
        [InlineData(-5, -5, 25.0)]
        [InlineData(5, -5, -25)]
        [InlineData(5.001, 5.0, 25.005)]
        public void MultiplyCorrectly(double multiplicand, double multiplier, double expectedProduct)
        {
            Assert.Equal(expectedProduct, _sut.Multiply(multiplicand, multiplier), 3);
        }

        /// <summary>
        /// Asserts the quotient to be correct when dividing.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <param name="expectedQuotient">The expected quotient.</param>
        [Theory]
        [InlineData(5, 5, 1.0)]
        [InlineData(-5, -5, 1.0)]
        [InlineData(5, -5, -1)]
        [InlineData(5.001, 5.0, 1.000)]
        public void DivideCorrectly(double dividend, double divisor, double expectedQuotient)
        {
            Assert.Equal(expectedQuotient, _sut.Divide(dividend, divisor), 3);
        }

        /// <summary>
        /// Asserts a divide by zero exception is thrown when dividing by zero.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        [Theory]
        [InlineData(0)]
        [InlineData(null)]
        public void ThrowExceptionWhenDividingByZero(double divisor)
        {
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(100, divisor));
        }
    }
}
