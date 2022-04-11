using System;
using System.Collections.Generic;
using System.Drawing;

namespace Library
{
    public class ImportImageEventArgs : EventArgs
    {
        // DECLARE a List<Image>, call it _images:
        private List<Image> _images;

        // DECLARE a get property for Images:
        public List<Image> Images
        {
            get { return _images; }
        }
        
        /// <summary>
        /// Constructor for ImportImageEventArgs.
        /// </summary>
        /// <param name="pImages">A List containing all Images in the ImageStorage.</param>
        public ImportImageEventArgs(List<Image> pImages) : base()
        {
            // ASSIGN pImages to _images:
            _images = pImages;
        }
    }
}
