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

        public Image Resize(Image pImageToResize, int pWidth, int pHeight)
        {

            Bitmap bitmap = new Bitmap(pWidth, pHeight);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.DrawImage(pImageToResize, 0, 0, pWidth, pHeight);


            return bitmap;
        }

    }
}
