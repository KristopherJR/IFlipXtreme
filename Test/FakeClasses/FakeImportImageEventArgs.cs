using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class FakeImportImageEventArgs : EventArgs
    {
        // DECLARE a List<Image>, call it _images:
        private List<Image> _images;

        // DECLARE a get property for Images:
        public List<Image> Images
        {
            get { return _images; }
        }
        
        /// <summary>
        /// Constructor for FakeImportImageEventArgs.
        /// </summary>
        /// <param name="pImages">A List containing all Images in the ImageStorage.</param>
        public FakeImportImageEventArgs(List<Image> pImages)
        {
            // ASSIGN pImages to _images:
            _images = pImages;
        }
    }
}
