using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class FakeCommandOneParameter : FakeICommand
    {
        #region Fields
        private Action _action;
        private T _parameter;
        #endregion

        #region Properties
        public T Parameter
        {
            set { _parameter = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for FakeCommandOneParameter
        /// </summary>
        /// <param name="pAction">An Action Delegate that points to the Method the Command should Execute.</param>
        public FakeCommandOneParameter(Action pAction)
        {
            // ASSIGN _action:
            _action = pAction;
        }

        /// <summary>
        /// Executes the Action in this Command and passes in the stored Parameter.
        /// </summary>
        public void Execute()
        {
            _action(_parameter);
        }
        #endregion
    }
}
