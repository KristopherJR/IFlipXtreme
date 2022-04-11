using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Controller
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
