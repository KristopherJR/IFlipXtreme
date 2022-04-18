//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Imaging;


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
        /// Adjusts the brightness of an System.Drawing.Image to the brightness value provided and returns it.
        /// 
        /// Code adapted from: https://ukacademe.com/TutorialExamples/CSharp/Image_Brightness_in_CSharp#:~:text=Image%20Brightness%20In%20C%23&text=The%20idea%20is%20easy%3A%20move,to%2064%2C%2016%2C%20127.
        /// </summary>
        /// <param name="pImageToAdjust">The System.Drawing.Image to adjust.</param>
        /// <param name="pNewBrightness">The new brightness value for the Image.</param>
        /// <returns></returns>
        public System.Drawing.Image AdjustBrightness(System.Drawing.Image pImageToAdjust, int pNewBrightness)
        {
            // DECLARE a new float and assign the value call it "newBrightness"
            float newBrightness = ((float)pNewBrightness) / 50f;

            // DECLARE & INSTANTIATE
            System.Drawing.Imaging.ColorMatrix colourMatrix = new System.Drawing.Imaging.ColorMatrix(new float[][]
                {
                    new float[] { newBrightness, 0, 0, 0, 0},
                    new float[] {0, newBrightness, 0, 0, 0},
                    new float[] {0, 0, newBrightness, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1},
                });

            System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            attributes.SetColorMatrix(colourMatrix);

            // Draw the Image onto the new bitmap while applying the new ColorMatrix.
            System.Drawing.Point[] points =
            {
                new System.Drawing.Point(0, 0),
                new System.Drawing.Point(pImageToAdjust.Width, 0),
                new System.Drawing.Point(0, pImageToAdjust.Height),
            };

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, pImageToAdjust.Width, pImageToAdjust.Height);

            // Make the result bitmap.
            Bitmap adjustedImage = new Bitmap(pImageToAdjust.Width, pImageToAdjust.Height);
            using (System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(adjustedImage))
            {
                gr.DrawImage(pImageToAdjust, points, rect, System.Drawing.GraphicsUnit.Pixel, attributes);
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
        public System.Drawing.Image AdjustSaturation(System.Drawing.Image pImageToAdjust, int pNewSaturation)
        {
            float rwgt = 0.3086f;
            float gwgt = 0.6094f;
            float bwgt = 0.0820f;


            float s = ((float)pNewSaturation  /  100f) + 0.5f;

            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix();

            float a = (1.0f - s) * rwgt + s;
            float b = (1.0f - s) * rwgt;
            float c = (1.0f - s) * rwgt;
            float d = (1.0f - s) * gwgt;
            float e = (1.0f - s) * gwgt + s;
            float f = (1.0f - s) * gwgt;
            float g = (1.0f - s) * bwgt;
            float h = (1.0f - s) * bwgt;
            float i = (1.0f - s) * bwgt + s;

            System.Drawing.Imaging.ColorMatrix colourMatrix = new System.Drawing.Imaging.ColorMatrix(new float[][]
                {
                    new float[] {a,     b,      c,      0,      0},
                    new float[] {d,     e,      f,      0,      0},
                    new float[] {g,     h,      i,      0,      0},
                    new float[] {0,     0,      0,      1,      0},
                    new float[] {0,     0,      0,      0,      1},
                });


            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();

            imageAttributes.SetColorMatrix(colourMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(pImageToAdjust);

            graphics.DrawImage(
                pImageToAdjust,  
                new System.Drawing.Rectangle(0,0, pImageToAdjust.Width, pImageToAdjust.Height),
                0,0,
                pImageToAdjust.Width,
                pImageToAdjust.Height,
                System.Drawing.GraphicsUnit.Pixel,
                imageAttributes);

            return pImageToAdjust;
        }


        /// <summary>
        /// Adjusts the contrast of an System.Drawing.Image to the contrast value provided and returns it.
        /// 
        /// Code adapted from: https://www.c-sharpcorner.com/uploadfile/75a48f/control-image-contrast-using-asp-net/
        /// </summary>
        /// <param name="pImageToAdjust">The System.Drawing.Image to adjust.</param>
        /// <param name="pNewContrast">The new contrast value for the Image.</param>
        /// <returns></returns>
        public System.Drawing.Image AdjustContrast(System.Drawing.Image pImageToAdjust, int pNewContrast)
        {
            
            Bitmap temp = (Bitmap)pImageToAdjust;
            Bitmap bmap = (Bitmap)temp.Clone();

            float newContrast = (pNewContrast / 100f) + 0.5f;
            newContrast *= newContrast;

            System.Drawing.Color col;

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
            System.Drawing.Color.FromArgb((byte)pRed, (byte)pGreen, (byte)pBlue));
                }
            }
            pImageToAdjust = (Bitmap)bmap.Clone();

            return pImageToAdjust;
        }



        /// <summary>
        /// Resize Method: Returns an Image resized to a specified size.
        /// </summary>
        /// <param name="pImageToResize">The input Image to be resized</param>
        /// <param name="pSize">The new size that the output System.Drawing.Image should be</param>
        /// <returns>The newly resized image</returns>
        public System.Drawing.Image Resize(System.Drawing.Image pImageToResize, System.Drawing.Size pSize)
        {
            // DECLARE & INSTANTIATE a new Bitmap with the size specified in pSize.
            Bitmap bitmap = new Bitmap(pSize.Width, pSize.Height);

            // DECLARE & INSTANTIATE a new Graphics object, pass in the empty bitmap object made prior.
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap);

            // CALL DrawImage on the Graphics Object to redraw pImageToResize onto the bitmap with the specified size
            graphic.DrawImage(pImageToResize, 0, 0, pSize.Width, pSize.Height);

            // RETURN the bitmap of the now rescaled pImageToResize
            return bitmap;
        }

        /// <summary>
        /// Rotate Method:  Rotates the supplied System.Drawing.Image by a selected amount od 90 degree steps
        /// </summary>
        /// <param name="pImage">The System.Drawing.Image to be rotated</param>
        /// <param name="pRotateVal">The amount to roate by (in 90 degree steps)</param>
        /// <returns></returns>
        public System.Drawing.Image Rotate(System.Drawing.Image pImage, int pRotateVal)
        {
            System.Drawing.Image adjustedImage = pImage;
            // IF System.Drawing.Image should be rotated by 90 degrees
            if (pRotateVal == 1)
            {
                adjustedImage.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                return adjustedImage;
            }

            // IF System.Drawing.Image should be rotated by 270 degrees
            else if (pRotateVal == -1)
            {
                adjustedImage.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                return adjustedImage;
            }

            // IF System.Drawing.Image should be rotated by 0 degrees / invalid rotateVal
            else
            {
                // RETURN the image
                return pImage;
            }

        }

        /// <summary>
        /// Flip Method: Flips a supplied System.Drawing.Image in the specified axis
        /// </summary>
        /// <param name="pImage">The System.Drawing.Image to be flipped</param>
        /// <param name="pAxis">The axis to be flipped</param>
        /// <returns></returns>
        public System.Drawing.Image Flip(System.Drawing.Image pImage, int pAxis)
        {
            if (pAxis == 1)
            {
                // ROTATE the image
                pImage.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);

                // RETURN the image
                return pImage;
            }

            else
            {
                // ROTATE the image
                pImage.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);

                // RETURN the image
                return pImage;
            }

        }

        public System.Drawing.Image Crop(System.Drawing.Image pImageToCrop, int pCropBoxX, int pCropBoxY, int pCropWidth, int pCropHeight)
        {
            Bitmap bmp2 = new Bitmap(pImageToCrop.Width, pImageToCrop.Height);

            // DECLARE & INSTANTIATE a new Graphics object, pass in the empty bitmap object made prior.
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bmp2);

            // CALL DrawImage on the Graphics Object to redraw pImageToResize onto the bitmap with the specified size
            graphic.DrawImage(pImageToCrop, 0, 0, pImageToCrop.Width, pImageToCrop.Height);      

            Bitmap crpImg = new Bitmap(pCropWidth, pCropHeight);

            //int xValueToCrop;
            //int yValueToCrop;

            for (int i = 0; i < pCropWidth; i++)
            {
                for (int j = 0; j < pCropHeight; j++)
                {
                    // if (!(pCropBoxX  +  i >= pImageToCrop.Width || pCropBoxY  +  j >= pImageToCrop.Height))
                    //{
                    //xValueToCrop = pCropBoxX + i;
                    //yValueToCrop = pCropBoxY + j;

                    //Console.WriteLine("pCropBoxX: " + (pCropBoxX).ToString());
                    //Console.WriteLine("pCropBoxY: " + (pCropBoxY).ToString());
                    //Console.WriteLine("pCropWidth: " + (pCropWidth).ToString());
                    //Console.WriteLine("pCropHeight: " + (pCropHeight).ToString());

                    //Console.WriteLine("X Pixel Targeted: " + (pCropBoxX + i).ToString());
                    //Console.WriteLine("Y Pixel Targeted: " + (pCropBoxY + j).ToString());
                    //Console.WriteLine("Crop Width is " + (crpImg.Width).ToString() + " and Crop Height is " + (crpImg.Height).ToString());
                    //Console.WriteLine("Size of Image: " + (bmp2.Width).ToString() + " "+ (bmp2.Height).ToString());

                    System.Drawing.Color pixelColor = bmp2.GetPixel(pCropBoxX + i, pCropBoxY + j);
                            crpImg.SetPixel(i, j, pixelColor);
                    //}
                    //if (pCropBoxX + i > pImageToCrop.Width) xValueToCrop = pImageToCrop.Width;
                }
            }
            return crpImg;
        }


    }
}
