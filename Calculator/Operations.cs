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
            return firstTerm + secondTerm;
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
                sum += terms[i];
            }

            return sum;
        }

        /// <summary>
        /// Subtracts the subtrahend from the minuend and returns the difference.
        /// </summary>
        /// <param name="minuend">The minuend</param>
        /// <param name="subtrahend">The subtrahend</param>
        /// <returns>The difference</returns>
        public double Subtract(double minuend, double subtrahend)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// Subtracts subtrahends from the minuends and returns the difference.
        /// </summary>
        /// <param name="terms">Array containing the terms where index 0 contains the first 
        /// minuend and the following indexes contains the subtrahends</param>
        /// <returns>The difference</returns>
        public double Subtract(params double[] terms)
        {
            double difference = terms[0];

            for (int i = 1; i < terms.Length; i++)
            {
                difference -= terms[i];
            }

            return difference;
        }

        /// <summary>
        /// Multiplies the multiplicand with the multiplier and returns the product.
        /// </summary>
        /// <param name="multiplicand">The multiplicand</param>
        /// <param name="multiplier">The multiplier</param>
        /// <returns>The product</returns>
        public double Multiply(double multiplicand, double multiplier)
        {
            return multiplicand * multiplier;
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

            return dividend / divisor;
        }
    }
}
