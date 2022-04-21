//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

using System.Drawing;

namespace Library
{
    /// <summary>
    /// IImageManipulator Interface
    /// </summary>
    public interface IImageManipulator
    {
        /// <summary>
        /// AdjustBrightness Method: Adjusts the brightness of an Image to the brightness value provided and returns it.
        /// </summary>
        /// <param name="pImageToAdjust">The Image to adjust.</param>
        /// <param name="pNewBrightness">The new brightness value for the Image.</param>
        /// <returns>The adjusted Image.</returns>
        Image AdjustBrightness(Image pImageToAdjust, int pNewBrightness);

        /// <summary>
        /// AdjustSaturation method: Adjusts the saturation of an Image to the saturation value provided and returns it.
        /// </summary>
        /// <param name="pImageToAdjust">The image to be altered</param>
        /// <param name="pNewSaturation">The saturation adjustment value</param>
        /// <returns>The saturation adjusted image</returns>
        Image AdjustSaturation(Image pImageToAdjust, int pNewSaturation);

        /// <summary>
        /// Adjusts the contrast of an Image to the contrast value provided and returns it.
        /// </summary>
        /// <param name="pImageToAdjust">The Image to adjust.</param>
        /// <param name="pNewContrast">The new contrast value for the Image.</param>
        /// <returns>The contrast adjusted image</returns>
        Image AdjustContrast(Image pImageToAdjust, int pNewContrast);

        /// <summary>
        /// Resize Method: Returns an Image resized to a specified size.
        /// </summary>
        /// <param name="pImageToResize">The input Image to be resized</param>
        /// <param name="pSize">The new size that the output Image should be</param>
        /// <returns>The newly resized image</returns>
        Image Resize(Image pImageToResize, Size pSize);

        /// <summary>
        /// Rotate Method:  Rotates the supplied Image by a selected amount od 90 degree steps
        /// </summary>
        /// <param name="pImage">The Image to be rotated</param>
        /// <param name="pRotateVal">The amount to roate by (in 90 degree steps)</param>
        /// <returns>The adjusted Image</returns>
        Image Rotate(Image pImage, int pRotateVal);

        /// <summary>
        /// Flip Method: Flips a supplied Image in the specified axis
        /// </summary>
        /// <param name="pImage">The Image to be flipped</param>
        /// <param name="pAxis">The axis to be flipped</param>
        /// <returns>The adjusted Image</returns>
        Image Flip(Image pImage, int pAxis);

        /// </summary>
        /// <param name="pImageToCrop">The image to be cropped</param>
        /// <param name="pCropBoxX">The X offset of the crop box (X position of top left corner, relative to the Image)</param>
        /// <param name="pCropBoxY">The Y offset of the crop box (Y position of top left corner, relative to the Image)</param>
        /// <param name="pCropWidth">The width of the crop box</param>
        /// <param name="pCropHeight">The height of the crop box</param>
        /// <returns>The adjusted Image</returns>
        Image Crop(Image pImageToCrop, int pCropBoxX, int pCropBoxY, int pCropWidth, int pCropHeight);
    }
}