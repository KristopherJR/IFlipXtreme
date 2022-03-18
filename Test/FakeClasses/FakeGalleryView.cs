using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class FakeGalleryView
    {
        private List<Image> _imageList;

        public List<Image> ImageList
        {
            get { return _imageList; }
        }

        public FakeGalleryView()
        {
            _imageList = new List<Image>();
        }

        public void ImportButtonPressed()
        {
            // EXECUTE the Command object
            //_execute(_importImage);
        }
       
    }
}
