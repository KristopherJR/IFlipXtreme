//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    /// <summary>
    /// ImageStorage Class: Holds the list of the full size imported images, and loads them 
    /// </summary>
    public class ImageStorage
    {
        #region Fields
        // DECLARE a new List of type Image to hold the list of imported images.  Call it "_imageStore"
        private List<Image> _imageStore;
        #endregion

        #region Properties
        //DECLARE a get property to access _imageStore
        public List<Image> ImageStore
        {
            get { return _imageStore; }
        }
        #endregion

        /// <summary>
        /// Constructor for class ImageStorage.
        /// </summary>
        public ImageStorage()
        {
            // INSTANTIATE _imageStore as a new List of type Image
            _imageStore = new List<Image>();
        }

        /// <summary>
        /// LoadImage Method: Loads an image from the path specified, stores it in _imageStore
        /// </summary>
        /// <param name="pImagePath">The path of the image to import</param>
        /// <returns>Returns True if import was successfully creates</returns>
        public bool LoadImage(string pImagePath)
        {
            // TRY to import images, will exit if path is invalid
            try
            {
                //  IF _imageStore already has 8 elements
                if (_imageStore.Count == 8)
                {
                    // FOR elements 7-1
                    for (int i = 7; i > 0; i--)
                    {
                        // REPLACE this image with the previous image in the list (Shift all images up by 1, final image gets deleted)
                        _imageStore[i] = _imageStore[i - 1];
                    }
                    // SET the first image in the list to the new image
                    _imageStore[0] = Image.FromFile(pImagePath);
                }
                // ELSE (If _imageStore != 8)
                else
                {
                    // INSERT the image at the start of the List and push all elements along by 1
                    _imageStore.Insert(0,Image.FromFile(pImagePath));
                }
            }
            // CATCH if exception is thrown
            catch (Exception e)
            {
                // WRITE the error message to the console
                Console.WriteLine(e.Message);

                // RETURN False (As the import did not run successfully)
                return false;
            }

            // RETURN True (As the import ran successfully)
            return true;
        }
    }
}
