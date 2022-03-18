using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    class CommandInvoker
    {
        public CommandInvoker()
        {

        }

        public void Execute(FakeICommand pFakeCommand)
        {
            pFakeCommand.Execute();
        }
    }
}
