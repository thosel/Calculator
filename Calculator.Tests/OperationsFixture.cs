using System;

namespace Calculator.Tests
{
    /// <summary>
    /// Makes it possible for tests to share an operations instance.
    /// </summary>
    public class OperationsFixture : IDisposable
    {
        /// <summary>
        /// Initializes and sets an operations instance property.
        /// </summary>
        public OperationsFixture()
        {
            OperationsInstance = new Operations();
        }

        /// <summary>
        /// The operations instance property.
        /// </summary>
        public Operations OperationsInstance { get; private set; }

        /// <summary>
        /// The purpose of this method is to free unmanaged resources but in this case the method
        /// is only here because the interface IDisposable requires it to be.
        /// </summary>
        public void Dispose() { }
    }
}
