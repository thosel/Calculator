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
        /// <param name="operationsFixture">The fixture to retrieve the operations instance from</param>
        public OperationsShould(OperationsFixture operationsFixture)
        {
            _sut = operationsFixture.OperationsInstance;
        }

        #region Calculations        

        /// <summary>
        /// Asserts the sum to be correct when adding.
        /// </summary>
        /// <param name="firstTerm">The first term</param>
        /// <param name="secondTerm">The second term</param>
        /// <param name="expectedSum">The expected sum</param>
        [Theory]
        [Trait("Category", "Calculations")]
        [InlineData(5, 5, 10)]
        [InlineData(-5,-5, -10)]
        [InlineData(5, -5, 0)]
        [InlineData(5.001, 5, 10.001)]
        public void AddCorrectly(double firstTerm, double secondTerm, double expectedSum)
        {
            Assert.Equal(expectedSum, _sut.Add(firstTerm, secondTerm), 3);
        }

        /// <summary>
        /// Asserts the sum to be correct when adding using an array as an argument.
        /// </summary>
        /// <param name="terms">Array containing the terms</param>
        /// <param name="expectedSum">The expected sum</param>
        [Theory]
        [Trait("Category", "Calculations")]
        [InlineData(new double[] { 5, 5 }, 10)]
        [InlineData(new double[] { -5, -5 }, -10)]
        [InlineData(new double[] { 5, -5 }, 0)]
        [InlineData(new double[] { 5.001, 5 }, 10.001)]
        [InlineData(new double[] { 5.001, 5, -24.752, 0.14, -3174.225 }, -3188.836)]
        public void AddCorrectlyPassingArrayArgument(double[] terms, double expectedSum)
        {
            Assert.Equal(expectedSum, _sut.Add(terms), 3);
        }

        /// <summary>
        /// Asserts the difference to be correct when subtracting.
        /// </summary>
        /// <param name="minuend">The minuend</param>
        /// <param name="subtrahend">The subtrahend</param>
        /// <param name="expectedDifference">The expected difference</param>
        [Theory]
        [Trait("Category", "Calculations")]
        [InlineData(5, 5, 0)]
        [InlineData(-5, -5, 0)]
        [InlineData(5, -5, 10)]
        [InlineData(5.001, 5, 0.001)]
        public void SubtractCorrectly(double minuend, double subtrahend, double expectedDifference)
        {
            Assert.Equal(expectedDifference, _sut.Subtract(minuend, subtrahend), 3);
        }

        /// <summary>
        /// Asserts the difference to be correct when subtracting using an array as an argument.
        /// </summary>
        /// <param name="terms">Array containing the terms where index 0 contains the first 
        /// minuend and the following indexes contains the subtrahends</param>
        /// <param name="expectedDifference">The expected difference</param>
        [Theory]
        [Trait("Category", "Calculations")]
        [InlineData(new double[] { 5, 5 }, 0)]
        [InlineData(new double[] { -5, -5 }, 0)]
        [InlineData(new double[] { 5, -5 }, 10)]
        [InlineData(new double[] { 5.001, 5 }, 0.001)]
        [InlineData(new double[] { 5.001, 5, -24.752, 0.14, -3174.225 }, 3198.838)]
        public void SubtractCorrectlyPassingArrayArgument(double[] terms, double expectedDifference)
        {
            Assert.Equal(expectedDifference, _sut.Subtract(terms), 3);
        }

        /// <summary>
        /// Asserts the product to be correct when multiplying.
        /// </summary>
        /// <param name="multiplicand">The multiplicand</param>
        /// <param name="multiplier">The multiplier</param>
        /// <param name="expectedProduct">The expected product</param>
        [Theory]
        [Trait("Category", "Calculations")]
        [InlineData(5, 5, 25)]
        [InlineData(-5, -5, 25)]
        [InlineData(5, -5, -25)]
        [InlineData(5.001, 5, 25.005)]
        public void MultiplyCorrectly(double multiplicand, double multiplier, double expectedProduct)
        {
            Assert.Equal(expectedProduct, _sut.Multiply(multiplicand, multiplier), 3);
        }

        /// <summary>
        /// Asserts the quotient to be correct when dividing.
        /// </summary>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        /// <param name="expectedQuotient">The expected quotient</param>
        [Theory]
        [Trait("Category", "Calculations")]
        [InlineData(5, 5, 1)]
        [InlineData(-5, -5, 1)]
        [InlineData(5, -5, -1)]
        [InlineData(5.001, 5, 1.000)]
        public void DivideCorrectly(double dividend, double divisor, double expectedQuotient)
        {
            Assert.Equal(expectedQuotient, _sut.Divide(dividend, divisor), 3);
        }

        #endregion

        #region Exceptions

        /// <summary>
        /// Asserts that an overflow exception is thrown when the 
        /// inputs and or output do overflow when adding numbers.
        /// </summary>
        /// <param name="terms">Array containing the terms</param>
        [Theory]
        [Trait("Category", "Exceptions")]
        [InlineData(new double[] { Double.MaxValue, Double.MaxValue })]
        [InlineData(new double[] { Double.MinValue, Double.MinValue })]
        [InlineData(new double[] { Double.PositiveInfinity, 0 })]
        [InlineData(new double[] { 0, Double.PositiveInfinity })]
        [InlineData(new double[] { Double.NegativeInfinity, 0 })]
        [InlineData(new double[] { 0, Double.NegativeInfinity })]
        [InlineData(new double[] { Double.NaN, 0 })]
        [InlineData(new double[] { 0, Double.NaN })]
        public void ThrowOverflowExceptionWhenAdding(double[] terms)
        {
            Assert.Throws<OverflowException>(() => _sut.Add(terms[0], terms[1]));
            Assert.Throws<OverflowException>(() => _sut.Add(terms));
        }

        /// <summary>
        /// Asserts that an overflow exception is thrown when the 
        /// inputs and or output do overflow when subtracting numbers.
        /// </summary>
        /// <param name="terms">Array containing the terms</param>
        [Theory]
        [Trait("Category", "Exceptions")]
        [InlineData(new double[] { Double.MaxValue, Double.MinValue })]
        [InlineData(new double[] { Double.MinValue, Double.MaxValue })]
        [InlineData(new double[] { Double.PositiveInfinity, 0 })]
        [InlineData(new double[] { 0, Double.PositiveInfinity })]
        [InlineData(new double[] { Double.NegativeInfinity, 0 })]
        [InlineData(new double[] { 0, Double.NegativeInfinity })]
        [InlineData(new double[] { Double.NaN, 0 })]
        [InlineData(new double[] { 0, Double.NaN })]
        public void ThrowOverflowExceptionWhenSubtracting(double[] terms)
        {
            Assert.Throws<OverflowException>(() => _sut.Subtract(terms[0], terms[1]));
            Assert.Throws<OverflowException>(() => _sut.Subtract(terms));
        }

        /// <summary>
        /// Asserts that an overflow exception is thrown when the 
        /// inputs and or output do overflow when multiplying numbers.
        /// </summary>
        /// <param name="multiplicand">The multiplicand</param>
        /// <param name="multiplier">The multiplier</param>
        [Theory]
        [Trait("Category", "Exceptions")]
        [InlineData(Double.MaxValue, Double.MaxValue)]
        [InlineData(Double.MaxValue, Double.MinValue)]
        [InlineData(Double.PositiveInfinity, 1)]
        [InlineData(1, Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity, 1)]
        [InlineData(1, Double.NegativeInfinity)]
        [InlineData(Double.NaN, 1)]
        [InlineData(1, Double.NaN)]
        public void ThrowOverflowExceptionWhenMultiplying(double multiplicand, double multiplier)
        {
            Assert.Throws<OverflowException>(() => _sut.Multiply(multiplicand, multiplier));
        }

        /// <summary>
        /// Asserts that an overflow exception is thrown when the 
        /// inputs and or output do overflow when dividing numbers.
        /// </summary>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        [Theory]
        [Trait("Category", "Exceptions")]
        [InlineData(Double.MaxValue, 1 / Double.MaxValue)]
        [InlineData(Double.MinValue, 1 / Double.MaxValue)]
        [InlineData(Double.PositiveInfinity, 1)]
        [InlineData(1, Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity, 1)]
        [InlineData(1, Double.NegativeInfinity)]
        [InlineData(Double.NaN, 1)]
        [InlineData(1, Double.NaN)]
        public void ThrowOverflowExceptionWhenDividing(double dividend, double divisor)
        {
            Assert.Throws<OverflowException>(() => _sut.Divide(dividend, divisor));
        }

        /// <summary>
        /// Asserts a divide by zero exception is thrown when dividing by zero.
        /// </summary>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        [Theory]
        [Trait("Category", "Exceptions")]
        [InlineData(0)]
        [InlineData(null)]
        public void ThrowExceptionWhenDividingByZero(double divisor)
        {
            Assert.Throws<DivideByZeroException>(() => _sut.Divide(100, divisor));
        }

        #endregion
    }
}
