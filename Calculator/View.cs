using static System.Console;

namespace Calculator
{
    /// <summary>
    /// This class describes the view of the calculator.
    /// </summary>
    class View
    {
        /// <summary>
        /// Displays the main menu.
        /// </summary>
        public void ShowMainMenu()
        {
            Clear();
            WriteLine("*** Calculator ***");
            WriteLine("---------------------");
            WriteLine();
            WriteLine("1 - Addition");
            WriteLine("2 - Subtraction");
            WriteLine("3 - Multiplication");
            WriteLine("4 - Division");
            WriteLine("5 - Exponentiation");
            WriteLine("6 - Square root extraction");
            WriteLine();
            WriteLine("0 - Exit application");
            WriteLine();
            WriteLine("---------------------");
            WriteLine("Enter a numeric choice from the menu above and press enter!");
            WriteLine();
        }

        /// <summary>
        /// Displays a dialog to the user.
        /// </summary>
        /// <param name="heading">The dialog heading</param>
        /// <param name="message">The dialog message</param>
        public void ShowDialog(string heading, string message)
        {
            Clear();
            WriteLine($"*** {heading} ***");
            WriteLine("---------------------");
            WriteLine(message);
            WriteLine();
        }

        /// <summary>
        /// Displays a result to the user.
        /// </summary>
        /// <param name="heading">The result heading</param>
        /// <param name="message">The result message</param>
        public void DisplayResult(string heading, string message)
        {
            Clear();
            WriteLine($"*** {heading} ***");
            WriteLine("---------------------");
            WriteLine();
            WriteLine(message);
            WriteLine();
            WriteLine("---------------------");
            WriteLine("Press enter to continue ...");
            WriteLine();
        }
    }
}
