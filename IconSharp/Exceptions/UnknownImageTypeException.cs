using System;
using System.Collections.Generic;
using System.Text;

namespace IconSharp.Exceptions
{
    public class UnknownImageTypeException : Exception
    {
        public UnknownImageTypeException() : base()
        {

        }
        public UnknownImageTypeException(string message) : base(message)
        {
            
        }
        public UnknownImageTypeException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
