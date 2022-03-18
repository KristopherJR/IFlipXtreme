using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class FakeModel
    {
        #region Fields
        private FakeImageStorage _fakeImageStorage;
        #endregion

        #region Properties
        public FakeImageStorage FakeImageStorage
        {
            get { return _fakeImageStorage; }
        }
        #endregion

        #region Methods
        public FakeModel()
        {
            _fakeImageStorage = new FakeImageStorage();
        }

        #endregion
    }
}
