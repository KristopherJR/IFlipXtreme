using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class FakeModel : IPublisher
    {
        #region Fields
        private FakeImageStorage _fakeImageStorage;
        private IList<ISubscriber> _subscribers;
        #endregion

        #region Properties
        public FakeImageStorage FakeImageStorage
        {
            get { return _fakeImageStorage; }
        }

        public IList<ISubscriber> Subscribers
        {
            get { return _subscribers; }
        }
        #endregion

        #region Methods
        public FakeModel()
        {
            _fakeImageStorage = new FakeImageStorage();
            _subscribers = new List<ISubscriber>();
        }

        public void Subscribe(ISubscriber pSubscriber)
        {
            _subscribers.Add(pSubscriber);
        }

        public void Unsubscribe(ISubscriber pSubscriber)
        {
            _subscribers.Remove(pSubscriber);
        }

        #endregion
    }
}
