//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System.Collections.Generic;
using System.Drawing;

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

        public void AdjustBrightness(int pBrightnessVal)
        {

        }

        public void AdjustContrast(int pContrastVal)
        {

        }

        public void AdjustSaturation(int pSaturationVal)
        {

        }

        public void AdjustScale(int pScaleVal)
        {

        }

        public void CropImage(int pOriginX, int pOriginY, int pNewWidth, int pNewHeight)
        {

        }

        public void SaveImage()
        {

        }

        public void ApplyFilter(int pFilterIndex)
        {

        }

        public void RotateImage(int pRotateVal)
        {

        }

        public void FlipImage(int pFlipVal)
        {

        }

        public void OpenImage(int pPos)
        {
            

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

        public Image GetCurrentImage()
        {
            return (new Bitmap(1,1));
        }

        private void UpdateSubscribers()
        {
            foreach (ISubscriber subscriber in _subscribers)
            {
                subscriber.Update(new UpdateViewEventArgs(GetThumbnails(),GetCurrentImage()));
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
