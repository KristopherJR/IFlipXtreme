//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Test
{
    public interface IUpdatable
    {
        #region Methods

        /// <summary>
        /// Default Update method for an IUpdatable.
        /// </summary>
        /// <param name="e">Event information</param>
        void Update(EventArgs e);

        #endregion Methods
    }
}