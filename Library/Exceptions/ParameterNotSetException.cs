//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// ParameterNotSetException Class. Thrown when a user tries to execute a Command object without setting its Parameter(s) first.
    /// </summary>
    public class ParameterNotSetException : Exception
    {
        /// <summary>
        /// Constructor for ParameterNotSetException. Passes message to base.
        /// </summary>
        /// <param name="pMessage"></param>
        public ParameterNotSetException(string pMessage) : base(pMessage)
        {

        }
    }
}
