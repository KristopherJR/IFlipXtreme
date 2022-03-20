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
        private Action<Type> _action;
        private Type _parameter;
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for FakeCommand
        /// </summary>
        /// <param name="pAction">An Action Delegate that points to the Method the Command should Execute.</param>
        public FakeCommandOneParameter(Action<Type> pAction)
        {
            // ASSIGN _action:
            _action = pAction;
        }

        /// <summary>
        /// Executes the Action in this Command and passes in the stored Parameter.
        /// </summary>
        public void Execute()
        {
            if(!(_parameter == null))
            {
                _action(_parameter);
            }
            else
            {
                throw new ParameterNotSetException("You can not Execute the Command without setting its parameter.");
            }
        }

        /// <summary>
        /// Injects parameters for the Command object.
        /// </summary>
        public void InjectParameters(List<Type> pParameters)
        {
            if (pParameters.Count == 1)
            {
                _parameter = pParameters[0];
            }
            else
            {
                // THROW InvalidParameterListException:
                throw new InvalidParameterListException("You must provide only one parameter for a Command One Parameter object.");
            }
        }
        #endregion
    }
}
