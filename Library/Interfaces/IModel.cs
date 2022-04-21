//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

using System.Collections.Generic;
using System.Drawing;

namespace Library
{
    /// <summary>
    /// IModel Interface
    /// </summary>
    public interface IModel : IPublisher
    {
        /// <summary>
        ///  LoadImage Method: Calls the Image Manipulator to import an image from the specified path
        /// </summary>
        /// <param name="pImagePath">The path to the image to be imported</param>
        void LoadImage(string pImagePath);

        /// <summary>
        /// OpenImage Method: Opens a image selected in the gallery in the editor.
        /// </summary>
        /// <param name="pPos">The position in the image list of the image to open</param>
        void OpenImage(int pPos);

        /// <summary>
        /// AdjustBrightness Method: Adjusts the Brightness of an image by a specified amount.
        /// </summary>
        /// <param name="pBrightnessVal">The amount to increase brightness by.</param>
        void AdjustBrightness(int pBrightnessVal);

        /// <summary>
        /// AdjustContrast Method: Adjusts the Contrast of an image by a specified amount.
        /// </summary>
        /// <param name="pContrastVal">The amount to increase Contrast by.</param>
        void AdjustContrast(int pContrastVal);

        /// <summary>
        /// AdjustSaturation Method: Adjusts the Saturation of an image by a specified amount.
        /// </summary>
        /// <param name="pSaturationVal">The amount to increase Saturation by.</param>
        void AdjustSaturation(int pSaturationVal);

        /// <summary>
        /// AdjustScale Method: Adjusts the Scale of an image by a specified amount.
        /// </summary>
        /// <param name="pScaleVal">The amount to change Scale by.</param>
        void AdjustScale(int pScaleVal);

        /// <summary>
        /// CropImage Method: Crops an image to just a specified area of the original.
        /// </summary>
        /// <param name="pOriginX">X location of the crop box</param>
        /// <param name="pOriginY">Y location of the crop box</param>
        /// <param name="pNewWidth">Width of the crop box</param>
        /// <param name="pNewHeight">Height of the crop box</param>
        void CropImage(int pOriginX, int pOriginY, int pNewWidth, int pNewHeight);

        /// <summary>
        /// SaveImage Method: Saves the currently opened image.
        /// </summary>
        void SaveImage();

        /// <summary>
        /// SaveImage Method: Saves the currently opened image to a user provided path.
        /// </summary>
        /// <param name="path">The path to save the Image at.</param>
        void SaveImageToPath(string path);

        /// <summary>
        /// ApplyFilter Method: Apply a certain pre-made filter to the current image.
        /// </summary>
        /// <param name="pFilterIndex">Number to specify which filter to be applied</param>
        void ApplyFilter(int pFilterIndex);

        /// <summary>
        /// RotateImage Method: Rotate the image by a specified amount of 90 degree steps.
        /// </summary>
        /// <param name="pRotateVal">The amount to rotate the image by in 90 degree steps. (Total rotation = 90*pRotateVal degrees)</param>
        void RotateImage(int pRotateVal);

        /// <summary>
        /// FlipImage Method: Flips the current image in either the X or the Y axis.
        /// </summary>
        /// <param name="pFlipVal">The axis to flip in, 0=X, 1=Y</param>
        void FlipImage(int pFlipVal);

        /// <summary>
        /// RevertChanges Method:  Reloads the current image from the unedited version in Image Storage
        /// </summary>
        void RevertChanges();

        /// <summary>
        /// GetThumbnails Method: Returns the list of images resized to 128x128 thumbnails
        /// </summary>
        /// <returns>The thumbnail list</returns>
        List<Image> GetThumbnails();

        /// <summary>
        /// GetCurrentImage Method: Returns the current Image open for editing
        /// </summary>
        /// <returns>The current image that's open for editing.</returns>
        Image GetCurrentImage();

        /// <summary>
        /// GreyScaleFilter Method: Applies a grey scale filter by heavily undersaturating the image
        /// </summary>
        void GreyScaleFilter();

        /// <summary>
        /// SunburnFilter Method:  Applies a sunburn filter by increasing the contrast, saturation, and brightness of an image
        /// </summary>
        void SunburnFilter();

        /// <summary>
        /// BlurFilter Method: Applies a blur filter by shrinking the image and stretching the remaining pixels from the 32*32 image
        /// </summary>
        void BlurFilter();

        /// <summary>
        /// RandomFilter Method: Applies a random filter by randomly modifying all the values
        /// </summary>
        void RandomFilter();
    }
}