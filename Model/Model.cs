//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    /// <summary>
    /// Model Class: Holds references to both the Image Storage and Image Manipulator.  These classes are accesses through this class (via a command object.).
    /// </summary>
    public class Model : IModel
    {
        #region Fields

        // DECLARE a reference to IImageManipulator.  Call it "_imageManipulator".
        private IImageManipulator _imageManipulator;

        // DECLARE a reference to ImageStorage. Call it _imageStorage".
        private IImageStorage _imageStorage;

        // DECLARE a List of type ISubscriber to hold the list of subscribed objects.  Call it "_subscribers".
        private IList<ISubscriber> _subscribers;

        // DECLARE an int to hold the index of the currently open image
        private int _currentImageIndex;

        // DECLARE an int to hold the list index of the image currently being edited.
        private Image _currentImage;

        // DECLARE an int to hold the list index of the image currently being edited, with changes shows.
        private Image _currentAdjustedImage;

        // DECLARE a random to randomize the values for the RandomFilter, call it _random;
        private Random _random;

        #endregion Fields

        #region Properties

        // DECLARE a get property to access ImageStorage, call it "ImageStorage".
        public IImageStorage ImageStorage
        {
            get { return _imageStorage; }
        }

        // DECLARE a get propert to access _subscribers, call it "Subscribers".
        public IList<ISubscriber> Subscribers
        {
            get { return _subscribers; }
        }

        #endregion Properties

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

            // INSTANTIATE _random as a new Random
            _random = new Random();
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
                // UPDATE View of any changes that have been made
                UpdateView();
            }
        }

        /// <summary>
        /// AdjustBrightness Method: Adjusts the Brightness of an image by a specified amount.
        /// </summary>
        /// <param name="pBrightnessVal">The amount to increase brightness by.</param>
        public void AdjustBrightness(int pBrightnessVal)
        {
            //CALL AdjustBrightness in the Image Manipulator and pass in the current image and the brightness adjustment value, store result in _currentImage
            _currentImage = _imageManipulator.AdjustBrightness(_currentImage, pBrightnessVal);

            // UPDATE View of any changes that have been made
            UpdateView();
        }

        /// <summary>
        /// AdjustContrast Method: Adjusts the Contrast of an image by a specified amount.
        /// </summary>
        /// <param name="pContrastVal">The amount to increase Contrast by.</param>
        public void AdjustContrast(int pContrastVal)
        {
            //CALL AdjustContrast in the Image Manipulator and pass in the current image and the Contrast adjustment value, store result in _currentImage
            _currentImage = _imageManipulator.AdjustContrast(_currentImage, pContrastVal);

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// AdjustSaturation Method: Adjusts the Saturation of an image by a specified amount.
        /// </summary>
        /// <param name="pSaturationVal">The amount to increase Saturation by.</param>
        public void AdjustSaturation(int pSaturationVal)
        {
            // CALL AdjustSaturation in the image manipulator and pass the current image, store the result in _currentImage
            _imageManipulator.AdjustSaturation(_currentImage, pSaturationVal);

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// AdjustScale Method: Adjusts the Scale of an image by a specified amount.
        /// </summary>
        /// <param name="pScaleVal">The amount to change Scale by.</param>
        public void AdjustScale(int pScaleVal)
        {
            // DECLARE a new float "scaler" to hold the multiplier for scaling, converts percentage into multiplier (50 turns to 1)
            float scaler = (float)pScaleVal / 50;

            // DECLARE 2 new floats "newHeight" & "newWidth".  Calculate the new width and new height of the image and store them
            float newHeight = _currentImage.Height * scaler;
            float newWidth = _currentImage.Width * scaler;

            // CALL Resize in the image manipulator and pass the current image and new size, store the result in _currentImage
            _currentImage = _imageManipulator.Resize(_currentImage, new Size((int)newWidth, (int)newHeight));

            // UPDATE View of changed information
            UpdateView();
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
            // CALL Crop in the image manipulator and pass the current image, X & Y offset of crop box, and Height and Width of the crop box, store the result in _currentImage
            _currentImage = _imageManipulator.Crop(_currentImage, pOriginX, pOriginY, pNewWidth, pNewHeight);

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// ApplyFilter Method: Apply a certain pre-made filter to the current image.
        /// </summary>
        /// <param name="pFilterIndex">Number to specify which filter to be applied</param>
        public void ApplyFilter(int pFilterIndex)
        {
            // IF GreyScaleFliter was pressed command param = 0
            if (pFilterIndex == 0)
            {
                // CALL GreyScaleFilter
                GreyScaleFilter();
            }

            // IF GreyScaleFliter was pressed command param = 1
            else if (pFilterIndex == 1)
            {
                // CALL SunburnFilter
                SunburnFilter();
            }

            // IF BlurFilter was pressed command param = 2
            else if (pFilterIndex == 2)
            {
                // CALL BlurFilter
                BlurFilter();
            }

            // IF RandomFiler was pressed command param = 3
            else if (pFilterIndex == 3)
            {
                // CALL RandomFilter
                RandomFilter();
            }
            // UPDATE View of any changes that have been made
            UpdateView();
        }

        /// <summary>
        /// RotateImage Method: Rotate the image by a specified amount of 90 degree steps.
        /// </summary>
        /// <param name="pRotateVal">The amount to rotate the image by in 90 degree steps. (Total rotation = 90*pRotateVal degrees)</param>
        public void RotateImage(int pRotateVal)
        {
            // CALL rotate method in Image Manipulator and pass in the current image and the rotate value, and store its value in _currentAdjustedImage
            _currentImage = _imageManipulator.Rotate(_currentImage, pRotateVal);

            // UPDATE View of any changes that have been made
            UpdateView();
        }

        /// <summary>
        /// FlipImage Method: Flips the current image in either the X or the Y axis.
        /// </summary>
        /// <param name="pFlipVal">The axis to flip in, 0=X, 1=Y</param>
        public void FlipImage(int pFlipVal)
        {
            // CALL flip method in Image Manipulator and pass in the current image and the flip, and store its value in _currentAdjustedImage
            _currentImage = _imageManipulator.Flip(_currentImage, pFlipVal);

            // UPDATE View of any changes that have been made
            UpdateView();
        }

        /// <summary>
        /// OpenImage Method: Opens a image selected in the gallery in the editor.
        /// </summary>
        /// <param name="pPos">The position in the image list of the image to open</param>
        public void OpenImage(int pPos)
        {
            // IF the Image Storage's image list is not empty
            if (_imageStorage.ImageStore.Count > 0)
            {
                _currentImage = new Bitmap(_imageStorage.ImageStore[pPos]);

                // SET the tag of the current image to its position in the ImageList, this is used to save back to the list
                _currentImageIndex = pPos;

                // UPDATE View of any changes that have been made
                UpdateView();
            }
            else
            {
                // THROW HERE
            }
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
            // RETURN the adjusted current image
            return (_currentImage);
        }

        /// <summary>
        /// RevertChanges Method:  Reloads the current image from the unedited version in Image Storage
        /// </summary>
        public void RevertChanges()
        {
            // CALL OpenImage to Open the unedited copy of the current image
            OpenImage(_currentImageIndex);

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// UpdateView Method: Fires an event to subscribers which has the list of Thumbnails and the Current Image in the eventArgs
        /// </summary>
        private void UpdateView()
        {
            // FOREACH object that is subscribed
            foreach (ISubscriber subscriber in _subscribers)
            {
                // CALL Update on that subscriber and pass eventargs holding the thumnail list and full size current image
                subscriber.Update(new UpdateViewEventArgs(GetThumbnails(), GetCurrentImage()));
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
        /// GreyScaleFilter Method: Applies a grey scale filter by heavily undersaturating the image
        /// </summary>
        public void GreyScaleFilter()
        {
            // CALL AdjustSaturation in the Image Manipulator and pass the current image and -50 as a saturation value
            _currentImage = _imageManipulator.AdjustSaturation(_currentImage, -50);

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// SunburnFilter Method:  Applies a sunburn filter by increasing the contrast, saturation, and brightness of an image
        /// </summary>
        public void SunburnFilter()
        {
            // CALL the 3 relevant methods in Image Storage and pass them each the current image and adjustment values, store the result in _currentImage each time
            _currentImage = _imageManipulator.AdjustContrast(_currentImage, 300);
            _currentImage = _imageManipulator.AdjustSaturation(_currentImage, 300);
            _currentImage = _imageManipulator.AdjustBrightness(_currentImage, 55);

            // PRINT useful progress message to the user
            System.Console.WriteLine("Ouch! That's hot!");

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// BlurFilter Method: Applies a blur filter by shrinking the image and stretching the remaining pixels from the 32*32 image
        /// </summary>
        public void BlurFilter()
        {
            // DECLARE a new Size object to hold the original size of the image, call it "originalSize"
            Size originalSize = _currentImage.Size;

            // CALL Resize in Image Manipulator and pass it the current image and the Size 32*32
            _currentImage = _imageManipulator.Resize(_currentImage, new Size(32, 32));

            // CALL Resize in Image Manipulator and pass it the current image and the original image size
            _currentImage = _imageManipulator.Resize(_currentImage, originalSize);

            // UPDATE View of changed information
            UpdateView();
        }

        /// <summary>
        /// RandomFilter Method: Applies a random filter by randomly modifying all the values
        /// </summary>
        public void RandomFilter()
        {
            // DECLARE a new Size object to hold the original size of the image, call it "originalSize"
            Size originalSize = _currentImage.Size;

            // DECLARE two lists to store the random numbers for scale and adjustments, call them "randomScale" and "randomEdits"
            List<int> randomScale = new List<int>();
            List<int> randomEdits = new List<int>();

            // FOR LOOP repeat 3 times to add the random numbers to the lists:
            for (int i = 0; i <= 2; i++)
            {
                randomEdits.Add(_random.Next(1, 100));
                randomScale.Add(_random.Next(1, 2000));
            }

            // CALL the 4 relevant methods in Image Storage and pass them each the current image and random adjustment values, store the result in _currentImage each time
            _currentImage = _imageManipulator.Resize(_currentImage, new Size(randomScale[0], randomScale[1]));
            _currentImage = _imageManipulator.AdjustContrast(_currentImage, randomEdits[0]);
            _currentImage = _imageManipulator.AdjustSaturation(_currentImage, randomEdits[1]);
            _currentImage = _imageManipulator.AdjustBrightness(_currentImage, randomEdits[2]);

            randomEdits.Clear();
            randomScale.Clear();

            // CALL Resize in Image Manipulator and pass it the current image and the original image size
            _currentImage = _imageManipulator.Resize(_currentImage, originalSize);


            // UPDATE View of changed information
            UpdateView();
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

        /// <summary>
        /// SaveImage Method: Saves the currently opened image.
        /// </summary>
        public void SaveImage()
        {
            // CALL SaveImage in image storage
            _imageStorage.SaveImage(_currentImage, _currentImageIndex);

            // UPDATE View of any changes that have been made
            UpdateView();
        }

        /// <summary>
        /// SaveImage Method: Saves the currently opened image to a user provided path.
        /// </summary>
        /// <param name="path">The path to save the Image at.</param>
        public void SaveImageToPath(string path)
        {
            // CALL SaveImage in image storage
            _imageStorage.SaveImage(_currentImage, _currentImageIndex, path);

            // UPDATE View of any changes that have been made
            UpdateView();
        }

        #endregion Methods
    }
}