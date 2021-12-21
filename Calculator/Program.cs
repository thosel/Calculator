namespace Calculator
{
    /// <summary>
    /// Describes the entrypoint of the calculator.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Instantiates the controller of the calculator and runs it.
        /// </summary>
        /// <param name="args">Potential arguments to be sent to the calculator when it is executed, not implemented yet though</param>
        static void Main(string[] args)
        {
            new Controller().Run();
        }
    }
}
