﻿//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;

namespace Controller
{
    /// <summary>
    /// CommandInvoker Class: Executes code via commands sent from the client
    /// </summary>
    public class CommandInvoker : ICommandInvoker
    {
        /// <summary>
        /// Constructor for CommandInvoker Class
        /// </summary>
        public CommandInvoker()
        {
        }

        /// <summary>
        /// Execute Method: Executes code specified in the passed command object's "Execute" method.
        /// </summary>
        /// <param name="pCommand">The command object to be executed</param>
        public void Execute(ICommand pCommand)
        {
            pCommand.Execute();
        }
    }
}