﻿//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Library
{
    /// <summary>
    /// CurrentImageNotSetException Class. Thrown when a user tries pass an invalid Parameter to a method.
    /// </summary>
    public class CurrentImageNotSetException : Exception
    {
        /// <summary>
        /// Constructor for CurrentImageNotSetException. Passes message to base.
        /// </summary>
        /// <param name="pMessage">The Exception error message.</param>
        public CurrentImageNotSetException(string pMessage) : base(pMessage)
        {
        }
    }
}