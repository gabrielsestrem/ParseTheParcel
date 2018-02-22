using System;

namespace ParseTheParcel.Exceptions
{
    public class InvalidArgumentTypeException : ArgumentException
    {
        public InvalidArgumentTypeException(string message = "") : base(message)
        {
        }
    }
}