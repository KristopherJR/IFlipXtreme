//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System.Collections.Generic;
using System.Drawing;

namespace Test
{
    public class FakeModel : IPublisher
    {
        #region Fields

        private FakeImageManipulator _fakeImageManipulator;
        private FakeImageStorage _fakeImageStorage;
        private IList<ISubscriber> _subscribers;

        #endregion Fields

        #region Properties

        public FakeImageStorage FakeImageStorage
        {
            get { return _fakeImageStorage; }
        }

        public IList<ISubscriber> Subscribers
        {
            get { return _subscribers; }
        }

        #endregion Properties

        #region Methods

        public FakeModel()
        {
            _fakeImageManipulator = new FakeImageManipulator();
            _fakeImageStorage = new FakeImageStorage();
            _subscribers = new List<ISubscriber>();
        }

        public void LoadImage(string pImagePath)
        {
            if (_fakeImageStorage.LoadImage(pImagePath))
            {
                UpdateSubscribers();
            }
        }

        public List<Image> GetThumbnails()
        {
            List<Image> thumbList = new List<Image>();

            foreach (Image i in _fakeImageStorage.ImageStore)
            {
                thumbList.Add(_fakeImageManipulator.Resize(i, new Size(128, 128)));
            }

            return thumbList;
        }

        private void UpdateSubscribers()
        {
            foreach (ISubscriber subscriber in _subscribers)
            {
                if (subscriber is FakeGalleryView)
                {
                    subscriber.Update(new FakeImportImageEventArgs(GetThumbnails()));
                }
            }
        }

        public void Subscribe(ISubscriber pSubscriber)
        {
            _subscribers.Add(pSubscriber);
        }

        public void Unsubscribe(ISubscriber pSubscriber)
        {
            _subscribers.Remove(pSubscriber);
        }

        #endregion Methods
    }
}