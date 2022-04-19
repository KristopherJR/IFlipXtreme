//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System.Drawing;

namespace Test
{
    public class FakeImageManipulator
    {
        public FakeImageManipulator()
        {
        }

        public Image Resize(Image pImageToResize, Size pSize)
        {
            Bitmap bitmap = new Bitmap(pSize.Width, pSize.Height);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.DrawImage(pImageToResize, 0, 0, pSize.Width, pSize.Height);

            return bitmap;
        }
    }
}