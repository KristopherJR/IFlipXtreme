using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class CommandInvoker
    {
        public CommandInvoker()
        {

        }

        public void Execute(ICommand pFakeCommand)
        {
            pFakeCommand.Execute();
        }
    }
}
