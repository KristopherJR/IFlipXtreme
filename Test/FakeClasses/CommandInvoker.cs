//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

namespace Test
{
    internal class CommandInvoker
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