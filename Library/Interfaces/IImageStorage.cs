//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle

using System.Collections.Generic;
using System.Drawing;

namespace Library
{
    /// <summary>
    /// IImageStorage Interface
    /// </summary>
    public interface IImageStorage
    {
        //DECLARE a get property to access _imageStore
        List<Image> ImageStore { get; }

        /// <summary>
        /// LoadImage Method: Loads an image from the path specified, stores it in _imageStore
        /// </summary>
        /// <param name="pImagePath">The path of the image to import</param>
        /// <returns>Returns True if import was successfully creates</returns>
        bool LoadImage(string pImagePath);

        /// <summary>
        /// SaveImage Method: Saves a passed image to its original path, and in to the image list
        /// </summary>
        /// <param name="pImage">The Image to save.</param>
        /// <param name="pIndex">The Index of the Image in the ImageStorage List.</param>
        void SaveImage(Image pImage, int pIndex);

        /// <summary>
        /// SaveImage Method: Saves a passed image to its original path, and in to the image list
        /// </summary>
        /// <param name="pImage">The Image to save.</param>
        /// <param name="pIndex">The Index of the Image in the ImageStorage List.</param>
        /// <param name="path">The path to save the new Image at.</param>
        void SaveImage(Image pImage, int pIndex, string path);
    }
}