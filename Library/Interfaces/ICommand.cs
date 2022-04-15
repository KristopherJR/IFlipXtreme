//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// ICommand Interface
    /// </summary>
    public interface ICommand
    {
        #region Methods
        /// <summary>
        /// Executes the Action contained in Command.
        /// </summary>
        void Execute();
        #endregion Methods
    }

    /// <summary>
    /// ICommand Interface with 1 generic Parameters.
    /// </summary>
    /// <typeparam name="T">The generic parameter for the Command.</typeparam>
    public interface ICommand<T> : ICommand
    {
        #region Properties
        // DECLARE a set Property for ParameterOne:
        T ParameterOne { set; }
        #endregion
    }

    /// <summary>
    /// ICommand Interface with 2 generic Parameters.
    /// </summary>
    /// <typeparam name="T1">The 1st generic parameter for the Command.</typeparam>
    /// <typeparam name="T2">The 2nd generic parameter for the Command.</typeparam>
    public interface ICommand<T1, T2> : ICommand
    {
        #region Properties
        // DECLARE a set Property for ParameterOne:
        T1 ParameterOne { set; }
        // DECLARE a set Property for ParameterTwo:
        T2 ParameterTwo { set; }
        #endregion
    }

    /// <summary>
    /// ICommand Interface with 4 generic Parameters.
    /// </summary>
    /// <typeparam name="T1">The 1st generic parameter for the Command.</typeparam>
    /// <typeparam name="T2">The 2nd generic parameter for the Command.</typeparam>
    /// <typeparam name="T3">The 3rd generic parameter for the Command.</typeparam>
    /// <typeparam name="T4">The 4th generic parameter for the Command.</typeparam>
    public interface ICommand<T1, T2, T3, T4> : ICommand
    {
        #region Properties
        // DECLARE a set Property for ParameterOne:
        T1 ParameterOne { set; }
        // DECLARE a set Property for ParameterTwo:
        T2 ParameterTwo { set; }
        // DECLARE a set Property for ParameterThree:
        T3 ParameterThree { set; }
        // DECLARE a set Property for ParameterFour:
        T4 ParameterFour { set; }
        #endregion
    }
}
