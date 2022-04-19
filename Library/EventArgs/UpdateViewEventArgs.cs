//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// UpdateViewEventArgs Class. Contains the Images for the Gallery and Editor which is passed by Model to View on an Update.
    /// </summary>
    public class UpdateViewEventArgs : EventArgs
    {
        #region FIELDS
        // DECLARE a List<Image>, call it _imageList:
        private List<Image> _imageList;

        // DECLARE a Image, call it _image:
        private Image _image;
        #endregion

        #region PROPERTIES
        // DECLARE a GET property for _imageList:
        public List<Image> ImageList
        {
            // RETURN _imageList:
            get { return _imageList; }
        }

        // DECLARE a GET property for _image:
        public Image Image
        {
            // RETURN _image:
            get { return _image; }
        }

        #endregion
        /// <summary>
        /// Constructor for UpdateImageListEventArgs.
        /// </summary>
        /// <param name="pImageList">A List containing all Images in the Models ImageStorage.</param>
        public UpdateViewEventArgs(List<Image> pImageList, Image pImage)
        {
            // ASSIGN pImageList:
            _imageList = pImageList;
            // ASSIGN pImage
            _image = pImage;
        }
    }
}
