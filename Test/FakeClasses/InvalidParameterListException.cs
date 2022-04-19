//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Test
{
    public class InvalidParameterListException : Exception
    {
        public InvalidParameterListException(string pMessage) : base(pMessage)
        {
        }
    }
}