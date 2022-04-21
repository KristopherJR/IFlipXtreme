//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;

namespace Application
{
    /// <summary>
    /// Program class. Default entry point of the program, instantiates the Controller.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            // INSTANTIATE a new Icontroller, entry point to Image Flipper program
            IController controller = new Controller.Controller();
        }
    }
}