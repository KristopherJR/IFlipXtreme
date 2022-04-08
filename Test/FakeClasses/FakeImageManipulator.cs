using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
