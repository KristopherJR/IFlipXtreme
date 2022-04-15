//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
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
