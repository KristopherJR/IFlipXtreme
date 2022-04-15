//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InvalidParameterListException : Exception
    {
        public InvalidParameterListException(string pMessage) : base(pMessage)
        {

        }
    }
}
