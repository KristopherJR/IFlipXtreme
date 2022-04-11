using Library;
using System.Collections.Generic;

namespace Model
{
    public class Model
    {
        #region Fields
        private ImageManipulator _ImageManipulator;
        private ImageStorage _ImageStorage;
        private IList<ISubscriber> _subscribers;
        #endregion

        #region Properties
        public ImageStorage ImageStorage
        {
            get { return _ImageStorage; }
        }

        public IList<ISubscriber> Subscribers
        {
            get { return _subscribers; }
        }
        #endregion

        #region Methods
        public Model()
        {
            _ImageManipulator = new ImageManipulator();
            _ImageStorage = new ImageStorage();
            _subscribers = new List<ISubscriber>();
        }

        public void LoadImage(string pImagePath)
        {
            if (_ImageStorage.LoadImage(pImagePath))
            {
                UpdateSubscribers();
            }
        }

        public List<Image> GetThumbnails()
        {
            List<Image> thumbList = new List<Image>();

            foreach (Image i in _ImageStorage.ImageStore)
            {

                thumbList.Add(_ImageManipulator.Resize(i, new Size(128, 128)));
            }

            return thumbList;
        }

        private void UpdateSubscribers()
        {
            foreach (ISubscriber subscriber in _subscribers)
            {
                if (subscriber is GalleryView)
                {
                    subscriber.Update(new ImportImageEventArgs(GetThumbnails()));
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

        #endregion

    }
}
