using System;

namespace Library
{
    public class InvalidEventArgsTypeException : Exception
    {
        public InvalidEventArgsTypeException(string message) : base(message)
        {
        }
    }
}
