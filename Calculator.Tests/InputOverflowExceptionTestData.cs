using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Calculator.Tests
{
    /// <summary>
    /// Contains test data when verifying if an overflow exception is 
    /// thrown when using inputs.
    /// </summary>
    public class InputOverflowExceptionTestData
    {
        /// <summary>
        /// Returns the data.
        /// </summary>
        /// <returns>The data.</returns>
        public static IEnumerable<object[]> GetData
        {
            get
            {
                yield return new object[] { Double.PositiveInfinity, 1.0 };
                yield return new object[] { 1.0, Double.PositiveInfinity };
                yield return new object[] { Double.NegativeInfinity, 1.0 };
                yield return new object[] { 1.0, Double.NegativeInfinity };
                yield return new object[] { Double.NaN, 1.0 };
                yield return new object[] { 1.0, Double.NaN };
            }
        }

        /// <summary>
        /// Returns the data in arrays.
        /// </summary>
        /// <returns>The array data.</returns>
        public static IEnumerable<object[]> GetArrayData
        {
            get
            {
                yield return new object[] { new double[] { Double.PositiveInfinity, 1.0 } };
                yield return new object[] { new double[] { 1.0, Double.PositiveInfinity } };
                yield return new object[] { new double[] { Double.NegativeInfinity, 1.0 } };
                yield return new object[] { new double[] { 1.0, Double.NegativeInfinity } };
                yield return new object[] { new double[] { Double.NaN, 1.0 } };
                yield return new object[] { new double[] { 1.0, Double.NaN } };
            }
        }
    }
}
