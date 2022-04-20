//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using Library;

namespace Application
{
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