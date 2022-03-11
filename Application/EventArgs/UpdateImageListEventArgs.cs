using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UpdateImageListEventArgs : EventArgs
    {
        #region FIELDS
        // DECLARE a List<Image>, call it _imageList:
        private List<Image> _imageList;
        #endregion

        #region PROPERTIES
        // DECLARE a GET property for ImageList:
        public List<Image> ImageList
        {
            // RETURN _imageList:
            get { return _imageList; }
        }
        #endregion
        /// <summary>
        /// Constructor for UpdateImageListEventArgs.
        /// </summary>
        /// <param name="pImageList">A List containing all Images in the Models ImageStorage.</param>
        public UpdateImageListEventArgs(List<Image> pImageList)
        {
            // ASSIGN _imageList:
            _imageList = pImageList;
        }
    }
}
