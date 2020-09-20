using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Service
{
    public class IOServiceException : ApplicationException
    {
        public IOServiceException(string message, Exception inner): base(message, inner)
        {

        }
    }
}
