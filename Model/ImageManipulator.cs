//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Drawing;
using System.Drawing.Imaging;
//using Aspose.Imaging;


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

            // Draw the Image onto the new bitmap while applying the new ColorMatrix.
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
        /// 
        /// CODE ADAPTED FROM: https://stackoverflow.com/questions/14364716/faster-algorithm-to-change-hue-saturation-lightness-in-a-bitmap
        /// </summary>
        /// <param name="pImageToAdjust"></param>
        /// <param name="pNewSaturation"></param>
        /// <returns></returns>
        public Image AdjustSaturation(Image pImageToAdjust, int pNewSaturation)
        {
            float rwgt = 0.3086f;
            float gwgt = 0.6094f;
            float bwgt = 0.0820f;


            float s = ((float)pNewSaturation  /  100f) + 0.5f;

            ColorMatrix colorMatrix = new ColorMatrix();

            float a = (1.0f - s) * rwgt + s;
            float b = (1.0f - s) * rwgt;
            float c = (1.0f - s) * rwgt;
            float d = (1.0f - s) * gwgt;
            float e = (1.0f - s) * gwgt + s;
            float f = (1.0f - s) * gwgt;
            float g = (1.0f - s) * bwgt;
            float h = (1.0f - s) * bwgt;
            float i = (1.0f - s) * bwgt + s;

            ColorMatrix colourMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {a,     b,      c,      0,      0},
                    new float[] {d,     e,      f,      0,      0},
                    new float[] {g,     h,      i,      0,      0},
                    new float[] {0,     0,      0,      1,      0},
                    new float[] {0,     0,      0,      0,      1},
                });


            ImageAttributes imageAttributes = new ImageAttributes();

            imageAttributes.SetColorMatrix(colourMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Graphics graphics = Graphics.FromImage(pImageToAdjust);

            graphics.DrawImage(
                pImageToAdjust,  
                new Rectangle(0,0, pImageToAdjust.Width, pImageToAdjust.Height),
                0,0,
                pImageToAdjust.Width,
                pImageToAdjust.Height,
                GraphicsUnit.Pixel,
                imageAttributes);

            return pImageToAdjust;
        }


        /// <summary>
        /// Adjusts the contrast of an Image to the contrast value provided and returns it.
        /// 
        /// Code adapted from: https://www.c-sharpcorner.com/uploadfile/75a48f/control-image-contrast-using-asp-net/
        /// </summary>
        /// <param name="pImageToAdjust">The Image to adjust.</param>
        /// <param name="pNewContrast">The new contrast value for the Image.</param>
        /// <returns></returns>
        public Image AdjustContrast(Image pImageToAdjust, int pNewContrast)
        {
            
            Bitmap temp = (Bitmap)pImageToAdjust;
            Bitmap bmap = (Bitmap)temp.Clone();

            float newContrast = (pNewContrast / 100f) + 0.5f;
            newContrast *= newContrast;

            Color col;

            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    col = bmap.GetPixel(i, j);
                    double pRed = col.R / 255.0;
                    pRed -= 0.5;
                    pRed *= newContrast;
                    pRed += 0.5;
                    pRed *= 255;
                    if (pRed < 0) pRed = 0;
                    if (pRed > 255) pRed = 255;

                    double pGreen = col.G / 255.0;
                    pGreen -= 0.5;
                    pGreen *= newContrast;
                    pGreen += 0.5;
                    pGreen *= 255;
                    if (pGreen < 0) pGreen = 0;
                    if (pGreen > 255) pGreen = 255;

                    double pBlue = col.B / 255.0;
                    pBlue -= 0.5;
                    pBlue *= newContrast;
                    pBlue += 0.5;
                    pBlue *= 255;
                    if (pBlue < 0) pBlue = 0;
                    if (pBlue > 255) pBlue = 255;

                    bmap.SetPixel(i, j,
            Color.FromArgb((byte)pRed, (byte)pGreen, (byte)pBlue));
                }
            }
            pImageToAdjust = (Bitmap)bmap.Clone();

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
        /// <returns></returns>
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
        /// <returns></returns>
        public Image Flip(Image pImage, int pAxis)
        {
            if (pAxis == 1)
            {
                // ROTATE the image
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // RETURN the image
                return pImage;
            }

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
        /// <param name="pImageToCrop"></param>
        /// <param name="pCropBoxX"></param>
        /// <param name="pCropBoxY"></param>
        /// <param name="pCropWidth"></param>
        /// <param name="pCropHeight"></param>
        /// <returns></returns>
        public Image Crop(Image pImageToCrop, int pCropBoxX, int pCropBoxY, int pCropWidth, int pCropHeight)
        {
            Bitmap bmp2 = new Bitmap(pImageToCrop.Width, pImageToCrop.Height);

            // DECLARE & INSTANTIATE a new Graphics object, pass in the empty bitmap object made prior.
            Graphics graphic = Graphics.FromImage(bmp2);

            // CALL DrawImage on the Graphics Object to redraw pImageToResize onto the bitmap with the specified size
            graphic.DrawImage(pImageToCrop, 0, 0, pImageToCrop.Width, pImageToCrop.Height);      

            Bitmap crpImg = new Bitmap(pCropWidth, pCropHeight);

            Console.WriteLine("CropX: " + pCropBoxX + ", CropY: " + pCropBoxY + ", CropWidth: " + pCropWidth + ", CropHeight: " + pCropHeight);


            for (int i = 0; i < pCropWidth; i++)
            {   
                for (int j = 0; j < pCropHeight; j++)
                {
                    Color pixelColor = bmp2.GetPixel(pCropBoxX + i, pCropBoxY + j);
                            crpImg.SetPixel(i, j, pixelColor);

                }
            }
            return crpImg;
        }


    }
}
