//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

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
            // INSTANTIATE a new controller, entry point to Image Flipper program
            Controller.Controller controller = new Controller.Controller();
        }
    }
}