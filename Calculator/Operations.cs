using System;

namespace Calculator
{
    /// <summary>
    /// This class contains all the mathematical operations that the calculator can perform.
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Adds two terms together and returns the sum.
        /// </summary>
        /// <param name="firstTerm">The first term</param>
        /// <param name="secondTerm">The second term</param>
        /// <returns>The sum</returns>
        public double Add(double firstTerm, double secondTerm)
        {
            return ValidateOutput(ValidateInput(firstTerm) + ValidateInput(secondTerm));
        }

        /// <summary>
        /// Adds all the terms together in an array and returns the sum.
        /// </summary>
        /// <param name="terms">Array containing the terms</param>
        /// <returns>The sum</returns>
        public double Add(params double[] terms)
        {
            double sum = 0;

            for (int i = 0; i < terms.Length; i++)
            {
                sum += ValidateInput(terms[i]);
            }

            return ValidateOutput(sum);
        }

        /// <summary>
        /// Subtracts the subtrahend from the minuend and returns the difference.
        /// </summary>
        /// <param name="minuend">The minuend</param>
        /// <param name="subtrahend">The subtrahend</param>
        /// <returns>The difference</returns>
        public double Subtract(double minuend, double subtrahend)
        {
            return ValidateOutput(ValidateInput(minuend) - ValidateInput(subtrahend));
        }

        /// <summary>
        /// Subtracts subtrahends from the minuends and returns the difference.
        /// </summary>
        /// <param name="terms">Array containing the terms where index 0 contains the first 
        /// minuend and the following indexes contains the subtrahends</param>
        /// <returns>The difference</returns>
        public double Subtract(params double[] terms)
        {
            double difference = ValidateInput(terms[0]);

            for (int i = 1; i < terms.Length; i++)
            {
                difference -= ValidateInput(terms[i]);
            }

            return ValidateOutput(difference);
        }

        /// <summary>
        /// Multiplies the multiplicand with the multiplier and returns the product.
        /// </summary>
        /// <param name="multiplicand">The multiplicand</param>
        /// <param name="multiplier">The multiplier</param>
        /// <returns>The product</returns>
        public double Multiply(double multiplicand, double multiplier)
        {
            return ValidateOutput(ValidateInput(multiplicand) * ValidateInput(multiplier));
        }

        /// <summary>
        /// Divides the dividend with the divisor and returns the quotient.
        /// </summary>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        /// <returns>The quotient</returns>
        public double Divide(double dividend, double divisor)
        {
            if (divisor  == 0)
            {
                throw new DivideByZeroException("You can not divide by zero, please try again.");
            }

            return ValidateOutput(ValidateInput(dividend)/ValidateInput(divisor));
        }

        /// <summary>
        /// Validates the outputs not to be overflowed. If it do overflow an overflow 
        /// exception will be thrown.
        /// </summary>
        /// <param name="output">The output to validate</param>
        /// <returns>The validated output</returns>
        private double ValidateOutput(double output)
        {
            if (Double.IsInfinity(output))
            {
                throw new OverflowException("The number calculated was either too large or too small, please try again.");
            }

            return output;
        }

        /// <summary>
        /// Validates the inputs not to be overflowed. If they do overflow an overflow 
        /// exception will be thrown.
        /// </summary>
        /// <param name="input">The input to validate</param>
        /// <returns>The validated input</returns>
        private double ValidateInput(double input)
        {
            if (Double.IsInfinity(input) || Double.IsNaN(input))
            {
                throw new OverflowException("One or more number inputs was either too large or too small, please try again.");
            }

            return input;
        }
    }
}
