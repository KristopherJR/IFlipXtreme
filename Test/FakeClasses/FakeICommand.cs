using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public interface FakeICommand
    {
        #region METHODS
        /// <summary>
        /// Executes the Action contained in Command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Injects parameters for the Command object.
        /// </summary>
        void InjectParameters(List<Type> pParameters);
        #endregion METHODS
    }
}
