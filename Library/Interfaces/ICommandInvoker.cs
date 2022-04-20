//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

namespace Library
{
    /// <summary>
    /// ICommandInvoker Interface
    /// </summary>
    public interface ICommandInvoker
    {
        void Execute(ICommand pCommand);
    }
}