//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Drawing;
using System.Drawing.Imaging;

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
        /// Adjusts the brightness of an Image to the brightness value provided and returns it.
        /// 
        /// Code adapted from: https://ukacademe.com/TutorialExamples/CSharp/Image_Brightness_in_CSharp#:~:text=Image%20Brightness%20In%20C%23&text=The%20idea%20is%20easy%3A%20move,to%2064%2C%2016%2C%20127.
        /// </summary>
        /// <param name="pImageToAdjust">The Image to adjust.</param>
        /// <param name="pNewBrightness">The new brightness value for the Image.</param>
        /// <returns></returns>
        public Image AdjustBrightness(Image pImageToAdjust, int pNewBrightness)
        {
            // DECLARE a new float and assign the value call it "newBrightness"
            float newBrightness = ((float)pNewBrightness) / 50f;

            Console.WriteLine(newBrightness);

            // DECLARE & INSTANTIATE
            ColorMatrix colourMatrix = new ColorMatrix(new float[][]
                {
                    new float[] { newBrightness, 0, 0, 0, 0},
                    new float[] {0, newBrightness, 0, 0, 0},
                    new float[] {0, 0, newBrightness, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1},
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(pImageToAdjust.Width, 0),
                new Point(0, pImageToAdjust.Height),
            };

            Rectangle rect = new Rectangle(0, 0, pImageToAdjust.Width, pImageToAdjust.Height);

            // Make the result bitmap.
            Bitmap adjustedImage = new Bitmap(pImageToAdjust.Width, pImageToAdjust.Height);
            using (Graphics gr = Graphics.FromImage(adjustedImage))
            {
                gr.DrawImage(pImageToAdjust, points, rect, GraphicsUnit.Pixel, attributes);
            }


            return adjustedImage;
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

        /// <summary>
        /// Rotate Method:  Rotates the supplied image by a selected amount od 90 degree steps
        /// </summary>
        /// <param name="pImage">The image to be rotated</param>
        /// <param name="pRotateVal">The amount to roate by (in 90 degree steps)</param>
        /// <returns></returns>
        public Image Rotate(Image pImage, int pRotateVal)
        {
            Image adjustedImage = pImage;
            // IF image should be rotated by 90 degrees
            if (pRotateVal == 1)
            {
                adjustedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return adjustedImage;
            }

            // IF image should be rotated by 270 degrees
            else if (pRotateVal == -1)
            {
                adjustedImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return adjustedImage;
            }

            // IF image should be rotated by 0 degrees / invalid rotateVal
            else
            {
                // RETURN the image
                return pImage;
            }

        }

        /// <summary>
        /// Flip Method: Flips a supplied image in the specified axis
        /// </summary>
        /// <param name="pImage">The image to be flipped</param>
        /// <param name="pAxis">The axis to be flipped</param>
        /// <returns></returns>
        public Image Flip(Image pImage, int pAxis)
        {
            if (pAxis == 1)
            {
                // ROTATE the image
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // RETURN the image
                return pImage;
            }

            else
            {
                // ROTATE the image
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // RETURN the image
                return pImage;
            }

        }
    }
}
