using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    interface FakeICommand
    {
        #region METHODS
        /// <summary>
        /// Executes the Action contained in Command.
        /// </summary>
        void Execute();
        #endregion METHODS
    }
}
