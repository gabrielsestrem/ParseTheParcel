using System;

namespace ParseTheParcel.Exceptions
{
    public class InvalidArgumentValueException : ArgumentException
    {
        public InvalidArgumentValueException(string message = "") : base(message)
        {
        }
    }
}