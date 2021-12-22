using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Calculator.Tests
{
    /// <summary>
    /// The data attribute used when testing that an overflow exception
    /// is being thrown when using inputs. This version returns array arguments.
    /// </summary>
    public class InputsOverflowExceptionArrayArgumentsDataAttribute : DataAttribute
    {
        /// <summary>
        /// Returns the data to be used for the test.
        /// </summary>
        /// <param name="testMethod">The method that is being tested.</param>
        /// <returns>The data.</returns>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new double[] { Double.PositiveInfinity, 0 } };
            yield return new object[] { new double[] { 0, Double.PositiveInfinity } };
            yield return new object[] { new double[] { Double.NegativeInfinity, 0 } };
            yield return new object[] { new double[] { 0, Double.NegativeInfinity } };
            yield return new object[] { new double[] { Double.NaN, 0 } };
            yield return new object[] { new double[] { 0, Double.NaN } };
        }
    }
}
