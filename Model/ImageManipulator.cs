//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System.Drawing;
using System.Drawing.Imaging;

//using Aspose.Imaging;

namespace Model
{
    /// <summary>
    /// ImageManipulator Class: Contains methods to manipulate Images.  Called from model.
    /// </summary>
    public class ImageManipulator : IImageManipulator
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
        /// <returns>The adjusted Image.</returns>
        public Image AdjustBrightness(Image pImageToAdjust, int pNewBrightness)
        {
            // DECLARE a new float and assign the value call it "newBrightness"
            float newBrightness = ((float)pNewBrightness) / 50f;

            // DECLARE & INSTANTIATE a new ColorMatrix, set relevant elements to newBrightness
            ColorMatrix colourMatrix = new ColorMatrix(new float[][]
                {
                    new float[] { newBrightness, 0, 0, 0, 0},
                    new float[] {0, newBrightness, 0, 0, 0},
                    new float[] {0, 0, newBrightness, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1},
                });

            // DECLARE a new ImageAttributes object, INSTANTIATE it as a new ImageAttributes
            ImageAttributes attributes = new ImageAttributes();

            // CALL SetColorMatrix on the Image attributes and pass in the colour matrix
            attributes.SetColorMatrix(colourMatrix);

            // DECLARE a new Array of points, instantiate it with points which hold co ordinates to top right corner, top left corner, and bottom left corner.  Neccesary for overload DrawImage method, documentation available at: https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=dotnet-plat-ext-6.0#system-drawing-graphics-drawimage(system-drawing-image-system-drawing-point()-system-drawing-rectangle-system-drawing-graphicsunit-system-drawing-imaging-imageattributes)
            Point[] points =
            {
                new Point(0, 0),
                new Point(pImageToAdjust.Width, 0),
                new Point(0, pImageToAdjust.Height),
            };

            //DECLARE a new Rectangle and INSTANTIATE it with width and height equal to the input image
            Rectangle rect = new Rectangle(0, 0, pImageToAdjust.Width, pImageToAdjust.Height);

            // INSTANTIATE a new empty bitmap object, with height and width equal to our image
            Bitmap adjustedImage = new Bitmap(pImageToAdjust.Width, pImageToAdjust.Height);

            // INSTANTIATE a new Graphics.FromImage object, used for drawing the new image.  Pass it the empty adjustedImage bitmap
            Graphics gr = Graphics.FromImage(adjustedImage);

            // CALL DrawImage method on the Graphics object and pass in needed params.  This redraws the image with our specified Image Attributes (Which includes the brightness change)
            gr.DrawImage(pImageToAdjust, points, rect, GraphicsUnit.Pixel, attributes);

            // RETURN the newly drawn adjusted image
            return adjustedImage;
        }

        /// <summary>
        ///
        /// CODE ADAPTED FROM: https://stackoverflow.com/questions/14364716/faster-algorithm-to-change-hue-saturation-lightness-in-a-bitmap
        /// </summary>
        /// <param name="pImageToAdjust">The image to be altered</param>
        /// <param name="pNewSaturation">The saturation adjustment value</param>
        /// <returns>The adjusted Image.</returns>
        public Image AdjustSaturation(Image pImageToAdjust, int pNewSaturation)
        {
            // DECLARE values for the luminance vectors of each colour channel for linear RGB.  Needed for calculations
            float rwgt = 0.3086f;
            float gwgt = 0.6094f;
            float bwgt = 0.0820f;

            // DECLARE a float "s" that holds the saturation value to be added to the colour matrix.  Convert percantage to a multiplier, 50(middle) turns to 1 (Unchanged)
            float s = ((float)pNewSaturation / 100f) + 0.5f;

            // CALCULATE the 9 values needed for the colour matrix, 3 for each channel Red, Green, Blue
            float a = (1.0f - s) * rwgt + s;
            float b = (1.0f - s) * rwgt;
            float c = (1.0f - s) * rwgt;
            float d = (1.0f - s) * gwgt;
            float e = (1.0f - s) * gwgt + s;
            float f = (1.0f - s) * gwgt;
            float g = (1.0f - s) * bwgt;
            float h = (1.0f - s) * bwgt;
            float i = (1.0f - s) * bwgt + s;

            // DECLARE & INSTANTIATE a new colour matrix, set relevant values
            ColorMatrix colourMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {a,     b,      c,      0,      0},
                    new float[] {d,     e,      f,      0,      0},
                    new float[] {g,     h,      i,      0,      0},
                    new float[] {0,     0,      0,      1,      0},
                    new float[] {0,     0,      0,      0,      1},
                });

            // DECLARE a new ImageAttributes object, INSTANTIATE it as a new ImageAttributes
            ImageAttributes imageAttributes = new ImageAttributes();

            // CALL SetColorMatrix on the Image attributes and pass in the colour matrix
            imageAttributes.SetColorMatrix(colourMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            // INSTANTIATE a new Graphics.FromImage object, used for drawing the new image.  Pass it the empty adjustedImage bitmap
            Graphics graphics = Graphics.FromImage(pImageToAdjust);

            // CALL DrawImage method on the Graphics object and pass in needed params.  This redraws the image with our specified Image Attributes (Which includes the saturation change)
            graphics.DrawImage(
                pImageToAdjust,
                new Rectangle(0, 0, pImageToAdjust.Width, pImageToAdjust.Height),
                0, 0,
                pImageToAdjust.Width,
                pImageToAdjust.Height,
                GraphicsUnit.Pixel,
                imageAttributes);

            // RETURN the newly drawn adjusted image
            return pImageToAdjust;
        }

        /// <summary>
        /// Adjusts the contrast of an Image to the contrast value provided and returns it.
        ///
        /// Code adapted from: https://www.c-sharpcorner.com/uploadfile/75a48f/control-image-contrast-using-asp-net/
        /// </summary>
        /// <param name="pImageToAdjust">The Image to adjust.</param>
        /// <param name="pNewContrast">The new contrast value for the Image.</param>
        /// <returns>The contrast adjusted image</returns>
        public Image AdjustContrast(Image pImageToAdjust, int pNewContrast)
        {
            // DECLARE a new bitmap "temp" to hold the input image cast to a Bitmap
            Bitmap temp = (Bitmap)pImageToAdjust;

            // DECLARE a new bitmap "bmap" to hold a cloned copy of "temp".  This line and the line above prevents pImageToAdjust being passed by reference in error
            Bitmap bmap = (Bitmap)temp.Clone();

            // DECLARE a new float and CALCULATE the contrast multiplier from the bar percentage.  50 turns to 1
            float newContrast = (pNewContrast / 100f) + 0.5f;

            // SQUARE the value of newContrast to increase the max intesnsity, while keeping 1 as 1
            newContrast *= newContrast;

            // DECLARE a Color object to hold the colour of the current pixel being adjusted
            Color col;

            // FOR each column of the images pixels
            for (int i = 0; i < bmap.Width; i++)
            {
                // FOR each row of the images pixels
                for (int j = 0; j < bmap.Height; j++)
                {
                    //RED CHANNEL

                    // SET col to the colour of pixel i, j of the orginial image
                    col = bmap.GetPixel(i, j);

                    // GET the double red value (Value 0-1)
                    double pRed = col.R / 255.0;

                    // SUBSTRACT 0.5 from the red value to enable negative multiplication to work correctly
                    pRed -= 0.5;

                    // MULTIPLY the red value by newContrast
                    pRed *= newContrast;

                    // ADD 0.5 back to the red value to "recalibrate" the adjustment
                    pRed += 0.5;

                    // CONVERT the red value from (0-1) to (0-255)
                    pRed *= 255;

                    // IF the red value is less than 0, set it to zero
                    if (pRed < 0) pRed = 0;

                    // IF the red value is more than 255, set it to 255
                    if (pRed > 255) pRed = 255;

                    // GREEN CHANNEL

                    // GET the double green value (Value 0-1)
                    double pGreen = col.G / 255.0;

                    // SUBSTRACT 0.5 from the green value to enable negative multiplication to work correctly
                    pGreen -= 0.5;

                    // MULTIPLY the green value by newContrast
                    pGreen *= newContrast;

                    // ADD 0.5 back to the green value to "recalibrate" the adjustment
                    pGreen += 0.5;

                    // CONVERT the green value from (0-1) to (0-255)
                    pGreen *= 255;

                    // IF the green value is less than 0, set it to zero
                    if (pGreen < 0) pGreen = 0;

                    // IF the red value is more than 255, set it to 255
                    if (pGreen > 255) pGreen = 255;

                    // BLUE CHANNEL

                    // GET the double blue value (Value 0-1)
                    double pBlue = col.B / 255.0;

                    // SUBSTRACT 0.5 from the blue value to enable negative multiplication to work correctly
                    pBlue -= 0.5;

                    // MULTIPLY the blue value by newContrast
                    pBlue *= newContrast;

                    // ADD 0.5 back to the blue value to "recalibrate" the adjustment
                    pBlue += 0.5;

                    // CONVERT the blue value from (0-1) to (0-255)
                    pBlue *= 255;

                    // IF the blue value is less than 0, set it to zero
                    if (pBlue < 0) pBlue = 0;

                    // IF the blue value is more than 255, set it to 255
                    if (pBlue > 255) pBlue = 255;

                    // CALL SetPixel on bmap to set the pixel i, j to a pixel with the newly calculated RGB values
                    bmap.SetPixel(i, j,
                        Color.FromArgb((byte)pRed, (byte)pGreen, (byte)pBlue));
                }
            }
            // CLONE the adjusted image into pImageToAdjust
            pImageToAdjust = (Bitmap)bmap.Clone();

            // RETURN the adjusted image
            return pImageToAdjust;
        }

        /// <summary>
        /// Resize Method: Returns an Image resized to a specified size.
        /// </summary>
        /// <param name="pImageToResize">The input Image to be resized</param>
        /// <param name="pSize">The new size that the output Image should be</param>
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
        /// Rotate Method:  Rotates the supplied Image by a selected amount od 90 degree steps
        /// </summary>
        /// <param name="pImage">The Image to be rotated</param>
        /// <param name="pRotateVal">The amount to roate by (in 90 degree steps)</param>
        /// <returns>The adjusted Image</returns>
        public Image Rotate(Image pImage, int pRotateVal)
        {
            Image adjustedImage = pImage;
            // IF Image should be rotated by 90 degrees
            if (pRotateVal == -1)
            {
                adjustedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                return adjustedImage;
            }

            // IF Image should be rotated by 270 degrees
            else if (pRotateVal == 1)
            {
                adjustedImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return adjustedImage;
            }

            // IF Image should be rotated by 0 degrees / invalid rotateVal
            else
            {
                // RETURN the image
                return pImage;
            }
        }

        /// <summary>
        /// Flip Method: Flips a supplied Image in the specified axis
        /// </summary>
        /// <param name="pImage">The Image to be flipped</param>
        /// <param name="pAxis">The axis to be flipped</param>
        /// <returns>The adjusted Image</returns>
        public Image Flip(Image pImage, int pAxis)
        {
            // IF X axis was specified (1) (Vertical flip)
            if (pAxis == 1)
            {
                // ROTATE the image
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // RETURN the image
                return pImage;
            }
            // IF Y axis was specified (0) (Horizontal flip)
            else
            {
                // ROTATE the image
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // RETURN the image
                return pImage;
            }
        }

        /// <summary>
        ///
        /// Code adapted from: https://www.youtube.com/watch?v=7IR6J8Kw8cE&ab_channel=SundayNotice
        /// </summary>
        /// <param name="pImageToCrop">The image to be cropped</param>
        /// <param name="pCropBoxX">The X offset of the crop box (X position of top left corner, relative to the Image)</param>
        /// <param name="pCropBoxY">The Y offset of the crop box (Y position of top left corner, relative to the Image)</param>
        /// <param name="pCropWidth">The width of the crop box</param>
        /// <param name="pCropHeight">The height of the crop box</param>
        /// <returns>The adjusted Image</returns>
        public Image Crop(Image pImageToCrop, int pCropBoxX, int pCropBoxY, int pCropWidth, int pCropHeight)
        {
            // DECLARE a new Bitmap to hold a copy of the original image
            Bitmap bmp2 = new Bitmap(pImageToCrop.Width, pImageToCrop.Height);

            // DECLARE & INSTANTIATE a new Graphics object, pass in the empty bitmap object made prior.
            Graphics graphic = Graphics.FromImage(bmp2);

            // CALL DrawImage on the Graphics Object to redraw pImageToResize onto the bitmap with the specified size
            graphic.DrawImage(pImageToCrop, 0, 0, pImageToCrop.Width, pImageToCrop.Height);

            // INSTANTIATE a new empty bitmap with size equal to the crop box
            Bitmap crpImg = new Bitmap(pCropWidth, pCropHeight);

            // FOR each row of the new (empty) images pixels
            for (int i = 0; i < pCropWidth; i++)
            {
                // FOR each column of the new (empty) images pixels
                for (int j = 0; j < pCropHeight; j++)
                {
                    // DECLARE a new Color object, and set it to the colour of the pixel i,j of the original image
                    Color pixelColor = bmp2.GetPixel(pCropBoxX + i, pCropBoxY + j);

                    // SET the pixel in the new image to the colour of the equivilent pixel in the original image
                    crpImg.SetPixel(i, j, pixelColor);
                }
            }

            // RETURN the cropped image
            return crpImg;
        }
    }
}