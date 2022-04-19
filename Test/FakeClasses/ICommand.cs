//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

namespace Test
{
    public interface ICommand
    {
        #region Methods

        /// <summary>
        /// Executes the Action contained in Command.
        /// </summary>
        void Execute();

        #endregion Methods
    }

    public interface ICommand<T> : ICommand
    {
        #region Properties

        T ParameterOne { set; }

        #endregion Properties
    }

    public interface ICommand<T1, T2> : ICommand
    {
        #region Properties

        T1 ParameterOne { set; }
        T2 ParameterTwo { set; }

        #endregion Properties
    }

    public interface ICommand<T1, T2, T3, T4> : ICommand
    {
        #region Properties

        T1 ParameterOne { set; }
        T2 ParameterTwo { set; }
        T3 ParameterThree { set; }
        T4 ParameterFour { set; }

        #endregion Properties
    }
}