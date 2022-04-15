//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System.Drawing;

namespace Model
{
    /// <summary>
    /// ImageManipulator Class: Contains methods to manipulate Images.  Called from model.
    /// </summary>
    public class ImageManipulator
    {
        /// <summary>
        /// Contructor for ImageManipulator Class.
        /// </summary>
        public ImageManipulator()
        {

        }

        /// <summary>
        /// Resize Method: Returns an Image resized to a specified size.
        /// </summary>
        /// <param name="pImageToResize">The input image to be resized</param>
        /// <param name="pSize">The new size that the output image should be</param>
        /// <returns>The newly resized image</returns>
        public Image Resize(Image pImageToResize, Size pSize)
        {
            // DECLARE & INSTANTIATE a new Bitmap with the size specified in pSize.
            Bitmap bitmap = new Bitmap(pSize.Width, pSize.Height);

            // DECLARE & INSTANTIATE a new Graphics object, pass in the empty bitmap object made prior.
            Graphics graphic = Graphics.FromImage(bitmap);

            // CALL DrawImage on the Graphics Object to redraw pImageToResize onto the bitmap with the specified size
            graphic.DrawImage(pImageToResize, 0, 0, pSize.Width, pSize.Height);

            // RETURN the bitmap of the now rescaled pImageToResize
            return bitmap;
        }
    }
}
