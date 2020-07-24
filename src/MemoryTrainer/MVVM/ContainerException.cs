using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Exception for all runtime errors regarding the IContainer interface
    /// </summary>
    public class ContainerException : ApplicationException
    {
        /// <summary>
        /// Creates a new ContainerException
        /// </summary>
        /// <param name="message">the details</param>
        public ContainerException(string message) : base(message)
        {

        }
    }
}
