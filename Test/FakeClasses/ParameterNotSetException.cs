//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Test
{
    public class ParameterNotSetException : Exception
    {
        public ParameterNotSetException(string pMessage) : base(pMessage)
        {
        }
    }
}