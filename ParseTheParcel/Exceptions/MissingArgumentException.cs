using System;

namespace ParseTheParcel.Exceptions
{
    public class InvalidNumberOfArgumentsException : ArgumentException
    {
        public InvalidNumberOfArgumentsException(string message = "") : base(message)
        {
        }
    }
}