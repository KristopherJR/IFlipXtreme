//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class UpdateViewEventArgs : EventArgs
    {
        #region FIELDS
        // DECLARE a List<Image>, call it _imageList:
        private List<Image> _imageList;

        // DECLARE a Image, call it _image:
        private Image _image;
        #endregion

        #region PROPERTIES
        // DECLARE a GET property for ImageList:
        public List<Image> ImageList
        {
            // RETURN _imageList:
            get { return _imageList; }
        }


        public Image Image
        {
            // RETURN _imageList:
            get { return _image; }
        }

        #endregion
        /// <summary>
        /// Constructor for UpdateImageListEventArgs.
        /// </summary>
        /// <param name="pImageList">A List containing all Images in the Models ImageStorage.</param>
        public UpdateViewEventArgs(List<Image> pImageList, Image pImage)
        {
            // ASSIGN _imageList:
            _imageList = pImageList;

            _image = pImage;
        }
    }
}
