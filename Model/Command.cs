// Authors: Alfie Baker-James, Teodor - Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Class Command. Takes no parameters for the Action delegate.
    /// </summary>
    public class Command : ICommand
    {
        #region FIELDS
        // DECLARE an Action, call it _action:
        private Action _action;
        #endregion FIELDS
        /// <summary>
        /// Constructor for Command.
        /// </summary>
        /// <param name="pAction">The embedded Action that the Command points to.</param>
        public Command(Action pAction)
        {
            // ASSIGN _action:
            _action = pAction;
        }

        /// <summary>
        /// Executes the Command by calling the method pointed to in _action.
        /// </summary>
        public void Execute()
        {
            // CALL the method that _action points to:
            _action();
        }
    }

    /// <summary>
    /// Class Command<T>. Takes one parameter for the Action delegate.
    /// </summary>
    public class Command<T> : ICommand<T>
    {
        #region FIELDS
        // DECLARE an Action<T>, call it _action:
        private Action<T> _action;
        // DECLARE an object of type T, call it _parameterOne:
        private T _parameterOne;
        #endregion FIELDS

        #region PROPERTIES
        public T ParameterOne
        {
            set { _parameterOne = value; }
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Constructor for Command<T>. Assigns local Action.
        /// </summary>
        /// <param name="pAction">The Action to embed in the Command.</param>
        public Command(Action<T> pAction)
        {
            // ASSIGN _action:
            _action = pAction;
        }

        /// <summary>
        /// Executes the Command by calling the method pointed to in _action.
        /// </summary>
        public void Execute()
        {
            // CHECK all parameters have been assigned:
            if (!(_parameterOne == null))
            {
                // INVOKE _action and pass in _parameterOne:
                _action(_parameterOne);
            }
            else
            {
                // THROW a ParameterNotSetException if all parameters have not been assigned:
                throw new ParameterNotSetException("You can not Execute the Command without setting its parameter.");
            }
        }
        #endregion METHODS
    }

    /// <summary>
    /// Class Command<T1,T2>. Takes two parameters for the Action delegate.
    /// </summary>
    public class Command<T1, T2> : ICommand<T1, T2>
    {
        #region FIELDS
        // DECLARE an Action<T1,T2>, call it _action:
        private Action<T1, T2> _action;
        // DECLARE an object of type T1, call it _parameterOne:
        private T1 _parameterOne;
        // DECLARE an object of type T2, call it _parameterTwo:
        private T2 _parameterTwo;
        #endregion FIELDS

        #region PROPERTIES
        public T1 ParameterOne
        {
            set { _parameterOne = value; }
        }

        public T2 ParameterTwo
        {
            set { _parameterTwo = value; }
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Constructor for Command<T1,T2>. Assigns local Action.
        /// </summary>
        /// <param name="pAction">The Action to embed in the Command.</param>
        public Command(Action<T1, T2> pAction)
        {
            // assign the parameter to _action:
            _action = pAction;
        }

        /// <summary>
        /// Executes the Command by calling the method pointed to in _action.
        /// </summary>
        public void Execute()
        {
            // CHECK all parameters have been assigned:
            if (!(_parameterOne == null && _parameterTwo == null))
            {
                // INVOKE _action and pass in its parameters:
                _action(_parameterOne, _parameterTwo);
            }
            else
            {
                // THROW a ParameterNotSetException if all parameters have not been assigned:
                throw new ParameterNotSetException("You can not Execute the Command without setting its parameters.");
            }
        }
        #endregion METHODS
    }

    /// <summary>
    /// Class Command<T1,T2,T3,T4>. Takes four parameters for the Action delegate.
    /// </summary>
    public class Command<T1, T2, T3, T4> : ICommand
    {
        #region FIELDS
        // DECLARE an Action<T1,T2,T3,T4>, call it _action:
        private Action<T1, T2, T3, T4> _action;
        // DECLARE an object of type T1, call it _parameterOne:
        private T1 _parameterOne;
        // DECLARE an object of type T2, call it _parameterTwo:
        private T2 _parameterTwo;
        // DECLARE an object of type T3, call it _parameterThree:
        private T3 _parameterThree;
        // DECLARE an object of type T3, call it _parameterThree:
        private T4 _parameterFour;
        #endregion FIELDS

        #region PROPERTIES
        public T1 ParameterOne
        {
            set { _parameterOne = value; }
        }

        public T2 ParameterTwo
        {
            set { _parameterTwo = value; }
        }

        public T3 ParameterThree
        {
            set { _parameterThree = value; }
        }

        public T4 ParameterFour
        {
            set { _parameterFour = value; }
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Constructor for Command<T1,T2>. Assigns local Action.
        /// </summary>
        /// <param name="pAction">The Action to embed in the Command.</param>
        public Command(Action<T1, T2, T3, T4> pAction)
        {
            // assign the parameter to _action:
            _action = pAction;
        }

        /// <summary>
        /// Executes the Command by calling the method pointed to in _action.
        /// </summary>
        public void Execute()
        {
            // CHECK all parameters have been assigned:
            if (!(_parameterOne == null && _parameterTwo == null && _parameterThree == null && _parameterFour == null))
            {
                // INVOKE _action and pass in its parameters:
                _action(_parameterOne, _parameterTwo, _parameterThree, _parameterFour);
            }
            else
            {
                // THROW a ParameterNotSetException if all parameters have not been assigned:
                throw new ParameterNotSetException("You can not Execute the Command without setting its parameters.");
            }
        }
        #endregion METHODS
    }
}
