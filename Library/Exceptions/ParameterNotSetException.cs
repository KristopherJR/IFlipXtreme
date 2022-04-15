//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// 
    /// </summary>
    public class ParameterNotSetException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        public ParameterNotSetException(string pMessage) : base(pMessage)
        {

        }
    }
}
