//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    /// <summary>
    /// Model Class: Holds references to both the Image Storage and Image Manipulator.  These classes are accesses through this class (via a command object.).
    /// </summary>
    public class Model
    {
        #region Fields
        // DECLARE a reference to ImageManipulator.  Call it "_imageManipulator".
        private ImageManipulator _imageManipulator;

        // DECLARE a reference to ImageStorage. Call it _imageStorage".
        private ImageStorage _imageStorage;

        // DECLARE a List of type ISubscriber to hold the list of subscribed objects.  Call it "_subscribers".
        private IList<ISubscriber> _subscribers;
      
        #endregion

        #region Properties
        // DECLARE a get property to access ImageStorage, call it "ImageStorage".
        public ImageStorage ImageStorage
        {
            get { return _imageStorage; }
        }

        // DECLARE a get propert to access _subscribers, call it "Subscribers".
        public IList<ISubscriber> Subscribers
        {
            get { return _subscribers; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for Model class.
        /// </summary>
        public Model()
        {
            // INSTANTIATE _imageManipulator as a new ImageManipulator
            _imageManipulator = new ImageManipulator();

            // INSTANTIATE _imageStorage as a new ImageStorage
            _imageStorage = new ImageStorage();

            // INSTANTIATE _subscribers as a new List of type ISubscriber
            _subscribers = new List<ISubscriber>();
        }

        /// <summary>
        ///  LoadImage Method: Calls the Image Manipulator to import an image from the specified path
        /// </summary>
        /// <param name="pImagePath">The path to the image to be imported</param>
        public void LoadImage(string pImagePath)
        {
            // IF import was successful
            if (_imageStorage.LoadImage(pImagePath))
            {
                // CALL UpdateSubscibers to pass the updated thumbnail list
                UpdateSubscribers();
            }
        }

        /// <summary>
        /// AdjustBrightness Method: Adjusts the Brightness of an image by a specified amount.
        /// </summary>
        /// <param name="pBrightnessVal">The amount to increase brightness by.</param>
        public void AdjustBrightness(int pBrightnessVal)
        {

        }

        /// <summary>
        /// AdjustContrast Method: Adjusts the Contrast of an image by a specified amount.
        /// </summary>
        /// <param name="pContrastVal">The amount to increase Contrast by.</param>
        public void AdjustContrast(int pContrastVal)
        {

        }

        /// <summary>
        /// AdjustSaturation Method: Adjusts the Saturation of an image by a specified amount.
        /// </summary>
        /// <param name="pSaturationVal">The amount to increase Saturation by.</param>
        public void AdjustSaturation(int pSaturationVal)
        {

        }

        /// <summary>
        /// AdjustScale Method: Adjusts the Scale of an image by a specified amount.
        /// </summary>
        /// <param name="pScaleVal">The amount to change Scale by.</param>
        public void AdjustScale(int pScaleVal)
        {

        }

        /// <summary>
        /// CropImage Method: Crops an image to just a specified area of the original.
        /// </summary>
        /// <param name="pOriginX">X location of the crop box</param>
        /// <param name="pOriginY">Y location of the crop box</param>
        /// <param name="pNewWidth">Width of the crop box</param>
        /// <param name="pNewHeight">Height of the crop box</param>
        public void CropImage(int pOriginX, int pOriginY, int pNewWidth, int pNewHeight)
        {

        }

        /// <summary>
        /// SaveImage Method: Saves the currently opened image.
        /// </summary>
        public void SaveImage()
        {

        }

        /// <summary>
        /// ApplyFilter Method: Apply a certain pre-made filter to the current image.
        /// </summary>
        /// <param name="pFilterIndex">Number to specify which filter to be applied</param>
        public void ApplyFilter(int pFilterIndex)
        {

        }

        /// <summary>
        /// RotateImage Method: Rotate the image by a specified amount of 90 degree steps.
        /// </summary>
        /// <param name="pRotateVal">The amount to rotate the image by in 90 degree steps. (Total rotation = 90*pRotateVal degrees)</param>
        public void RotateImage(int pRotateVal)
        {

        }

        /// <summary>
        /// FlipImage Method: Flips the current image in either the X or the Y axis.
        /// </summary>
        /// <param name="pFlipVal">The axis to flip in, 0=X, 1=Y</param>
        public void FlipImage(int pFlipVal)
        {

        }

        /// <summary>
        /// OpenImage Method: Opens a image selected in the gallery in the editor.
        /// </summary>
        /// <param name="pPos">The position in the image list of the image to open</param>
        public void OpenImage(int pPos)
        {
            

        }

        /// <summary>
        /// GetThumbnails Method: Returns the list of images resized to 128x128 thumbnails
        /// </summary>
        /// <returns>The thumbnail list</returns>
        public List<Image> GetThumbnails()
        {
            // DECLARE & INSTANTIATE a new List of type Image to hold the Thumnail list.  Call it "thumbList".
            List<Image> thumbList = new List<Image>();

            // FOREACH image in the Image Store
            foreach (Image i in _imageStorage.ImageStore)
            {
                // CALL Resize to resize the image to 128x128, and add it to the thumbnail list
                thumbList.Add(_imageManipulator.Resize(i, new Size(128, 128)));
            }

            // Return the Thumbnail list
            return thumbList;
        }

        /// <summary>
        /// GetCurrentImage Method: Returns the current Image open for editing
        /// </summary>
        /// <returns>The current image that's open for editing.</returns>
        public Image GetCurrentImage()
        {
            // RETURN TEMPORARY EMPTY 1x1 BITMAP.........................................LINE NEEDS CHANGING
            return (new Bitmap(1,1));
        }

        /// <summary>
        /// UpdateSubscribers Method: Fires an event to subscribers which has the list of Thumbnails and the Current Image in the eventArgs
        /// </summary>
        private void UpdateSubscribers()
        {
            // FOREACH object that is subscribed
            foreach (ISubscriber subscriber in _subscribers)
            {
                // CALL Update on that subscriber and pass eventargs holding the thumnail list and full size current image
                subscriber.Update(new UpdateViewEventArgs(GetThumbnails(),GetCurrentImage()));
            }
        }

        /// <summary>
        /// Subscribe Method:  Adds an ISubscriber to the list of subscribers.
        /// </summary>
        /// <param name="pSubscriber">The ISubscriber object to be subscribed</param>
        public void Subscribe(ISubscriber pSubscriber)
        {
            // ADD the new subsciber to the subscriber list
            _subscribers.Add(pSubscriber);
        }

        /// <summary>
        /// Unsubscribe Method:  Removes an ISubscriber from the list of subscribers.
        /// </summary>
        /// <param name="pSubscriber">The ISubscriber object to be unsubscribed</param>
        public void Unsubscribe(ISubscriber pSubscriber)
        {
            // REMOVE the specifed subscriber from the subscribers list
            _subscribers.Remove(pSubscriber);
        }

        #endregion

    }
}
