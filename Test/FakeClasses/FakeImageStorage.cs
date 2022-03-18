using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class FakeImageStorage
    {
        private List<Image> _imageStore;
        public FakeImageStorage()
        {
            _imageStore = new List<Image>();
        }

        public void LoadImage(string pImagePath)
        {
            _imageStore.Add(Image.FromFile(pImagePath));
        }

    }
}
