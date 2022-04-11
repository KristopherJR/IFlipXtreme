using System;


namespace Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Controller.Controller controller = new Controller.Controller();
        }
    }
}
