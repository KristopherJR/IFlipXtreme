//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Library
{
    /// <summary>
    /// InvalidParameterException Class. Thrown when a user tries pass an invalid Parameter to a method.
    /// </summary>
    public class InvalidParameterException : Exception
    {
        /// <summary>
        /// Constructor for InvalidParameterException. Passes message to base.
        /// </summary>
        /// <param name="pMessage">The Exception error message.</param>
        public InvalidParameterException(string pMessage) : base(pMessage)
        {
        }
    }
}