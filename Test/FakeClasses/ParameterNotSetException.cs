using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class ParameterNotSetException : Exception
    {
        public ParameterNotSetException(string pMessage) : base(pMessage)
        {

        }
    }
}
