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
        #endregion

        #region Methods
        public FakeModel()
        {
            _fakeImageStorage = new FakeImageStorage();
        }

        public Dictionary<string, Action> GetActions()
        {
            Dictionary<string, Action> _actions = new Dictionary<string, Action>();

            _actions.Add("command_invoker_execute", _fakeCommandInvoker.GetExecuteAction);

        }
        #endregion
    }
}
