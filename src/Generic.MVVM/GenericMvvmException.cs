using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.MVVM
{
    public class GenericMvvmException : ApplicationException
    {
        public GenericMvvmException(string message, Exception inner) : base(message, inner)
        {
        }

        public GenericMvvmException(string message) : base(message)
        {

        }
    }
}
