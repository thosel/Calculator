using System;
using static System.Console;

namespace Calculator
{
    /// <summary>
    /// This class describes the controller of the calculator.
    /// </summary>
    class Controller
    {
        private bool _isCalculatorRunning;
        private View _view;
        private Operations _operations;

        /// <summary>
        /// Initializes the controller with a view instance, an operations instance and sets the calculator to be running.
        /// </summary>
        public Controller()
        {
            _isCalculatorRunning = true;
            _view = new View();
            _operations = new Operations();
        }

        /// <summary>
        /// Runs the calculator controller.
        /// </summary>
        public void Run()
        {
            while (_isCalculatorRunning)
            {
                GetMainMenuSelection();
            }
        }

        /// <summary>
        /// Takes the appropriate action based on user input for the main menu.
        /// </summary>
        private void GetMainMenuSelection()
        {
            _view.ShowMainMenu();

            // Sets the menuSelection to the user input or -1 if the input was invalid to trigger the default case in the switch below.
            int menuSelection = int.TryParse(ReadLine(), out int userInput) ? userInput : -1;

            switch (menuSelection)
            {
                case 1:
                    PerformAddition();
                    break;
                case 2:
                    PerformSubtraction();
                    break;
                case 3:
                    PerformMultiplication();
                    break;
                case 4:
                    PerformDivision();
                    break;
                case 5:
                    PerformExponentiation();
                    break;
                case 6:
                    PerformSquareRootExtraction();
                    break;
                case 0:
                    _isCalculatorRunning = false;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// This method collects two terms from the user, adds them together and presents the sum.
        /// </summary>
        private void PerformAddition()
        {
            double firstTerm = GetUserDoubleInput("Addition", "Enter the first term and press enter!");
            double secondTerm = GetUserDoubleInput("Addition", "Enter the second term and press enter!");

            _view.DisplayResult("Addition", $"The sum of the addition is {_operations.Add(firstTerm, secondTerm)}.");

            ReadLine();
        }

        /// <summary>
        /// This method collects a minuend and a subtrahend from the user, subtracts the subtrahend from the minuend 
        /// and presents the difference.
        /// </summary>
        private void PerformSubtraction()
        {
            double minuend = GetUserDoubleInput("Subtraction", "Enter the minuend and press enter!");
            double subtrahend = GetUserDoubleInput("Subtraction", "Enter the subtrahend and press enter!");

            _view.DisplayResult("Subtraction", $"The difference of the subtraction is {_operations.Subtract(minuend, subtrahend)}.");

            ReadLine();
        }

        /// <summary>
        /// This method collects a multiplicand and a multiplier from the user, multiplies the multiplicand with the multiplier 
        /// and presents the product.
        /// </summary>
        private void PerformMultiplication()
        {
            double multiplicand = GetUserDoubleInput("Multiplication", "Enter the multiplicand and press enter!");
            double multiplier = GetUserDoubleInput("Multiplication", "Enter the multiplier and press enter!");

            _view.DisplayResult("Multiplication", $"The product of the multiplication is {_operations.Multiply(multiplicand, multiplier)}.");

            ReadLine();
        }

        /// <summary>
        /// This method collects a dividend and a divisor from the user, divides the dividend with the divisor 
        /// and presents the quotient.
        /// </summary>
        private void PerformDivision()
        {
            double dividend = GetUserDoubleInput("Division", "Enter the dividend and press enter!");
            double divisor = GetUserDoubleInput("Division", "Enter the divisor and press enter!");

            try
            {
                _view.DisplayResult("Division", $"The quotient of the division is {_operations.Divide(dividend, divisor)}.");
            }
            catch (DivideByZeroException divideByZeroException)
            {
                _view.DisplayResult("Division", divideByZeroException.Message);
            }

            ReadLine();
        }

        /// <summary>
        /// This method collects a base and an exponent from the user, raises the base to the power of the exponent 
        /// and presents the result.
        /// </summary>
        private void PerformExponentiation()
        {
            double baseNumber = GetUserDoubleInput("Exponentiation", "Enter the base and press enter!");
            double exponent = GetUserDoubleInput("Exponentiation", "Enter the exponent and press enter!");
            double result = Math.Pow(baseNumber, exponent);

            if (!Double.IsNaN(result))
            {
                _view.DisplayResult("Exponentiation", $"{baseNumber} raised to the power of {exponent} is equal to {result}.");
            }
            else
            {
                _view.DisplayResult("Exponentiation", "The exponentiation could not be computed.");
            }

            ReadLine();
        }

        /// <summary>
        /// This method collects a radicand from the user, extracts the square root of it and presents it to the user.
        /// </summary>
        private void PerformSquareRootExtraction()
        {
            double radicand = GetUserDoubleInput("Square root extraction", "Enter the radicand and press enter!");
            double result = Math.Sqrt(radicand);

            if (!Double.IsNaN(result))
            {
                _view.DisplayResult("Square root extraction", $"The root extracted is {result}.");
            }
            else
            {
                _view.DisplayResult("Square root extraction", $"The square root extraction could not be computed.");
            }

            ReadLine();
        }

        /// <summary>
        /// Gets input from the user in the form of a double.
        /// </summary>
        /// <param name="heading">A heading for the input dialog</param>
        /// <param name="message">A message for the input dialog</param>
        /// <returns>The double input.</returns>
        private double GetUserDoubleInput(string heading, string message)
        {
            double input;

            do
            {
                _view.ShowDialog(heading, message);
            } while (!double.TryParse(ReadLine(), out input));

            return input;
        }
    }
}
