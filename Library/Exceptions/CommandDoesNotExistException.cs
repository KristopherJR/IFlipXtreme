//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Library
{
    /// <summary>
    /// CommandDoesNotExistException Class. Thrown when a user tries pass an invalid Parameter to a method.
    /// </summary>
    public class CommandDoesNotExistException : Exception
    {
        /// <summary>
        /// Constructor for CommandDoesNotExistException. Passes message to base.
        /// </summary>
        /// <param name="pMessage">The Exception error message.</param>
        public CommandDoesNotExistException(string pMessage) : base(pMessage)
        {
        }
    }
}