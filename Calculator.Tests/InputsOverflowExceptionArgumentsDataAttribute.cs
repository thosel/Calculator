using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Calculator.Tests
{
    /// <summary>
    /// The data attribute used when testing that an overflow exception
    /// is being thrown when using inputs. This version returns non array arguments.
    /// </summary>
    public class InputsOverflowExceptionArgumentsDataAttribute : DataAttribute
    {
        /// <summary>
        /// Returns the data to be used for the test.
        /// </summary>
        /// <param name="testMethod">The method that is being tested.</param>
        /// <returns>The data.</returns>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { Double.PositiveInfinity, 1 };
            yield return new object[] { 1, Double.PositiveInfinity };
            yield return new object[] { Double.NegativeInfinity, 1 };
            yield return new object[] { 1, Double.NegativeInfinity };
            yield return new object[] { Double.NaN, 1 };
            yield return new object[] { 1, Double.NaN };
        }
    }
}
