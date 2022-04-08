﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }
}