//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Model
{
    /// <summary>
    /// ImageStorage Class: Holds the list of the full size imported images, and loads them
    /// </summary>
    public class ImageStorage : IImageStorage
    {
        #region Fields

        // DECLARE a new List of type Image to hold the list of imported images.  Call it "_imageStore"
        private List<Image> _imageStore;

        #endregion Fields

        #region Properties

        //DECLARE a get property to access _imageStore
        public List<Image> ImageStore
        {
            get { return _imageStore; }
        }

        #endregion Properties

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

                    // DECLARE a new Image, call it "newImage":
                    Image newImage;
                    // OPEN a new FileStream and load a File from the pImagePath:
                    using (FileStream file = new FileStream(pImagePath, FileMode.Open))
                    {
                        // OPEN the Image from the File:
                        newImage = Image.FromStream(file);
                        // CLOSE the File after loading from the FileStream:
                        file.Close();
                    }

                    // SET the first image in the list to the new image
                    _imageStore[0] = newImage;

                    // STORE the path of the imported image as the object's tag
                    _imageStore[0].Tag = pImagePath;
                }
                // ELSE (If _imageStore != 8)
                else
                {
                    // DECLARE a new Image, call it "newImage":
                    Image newImage;

                    // OPEN a new FileStream and load a File from the pImagePath:
                    using (FileStream file = new FileStream(pImagePath, FileMode.Open))
                    {
                        // OPEN the Image from the File:
                        newImage = Image.FromStream(file);
                        // CLOSE the File after loading from the FileStream:
                        file.Close();
                    }

                    // INSERT the image at the start of the List and push all elements along by 1
                    _imageStore.Insert(0, newImage);

                    // STORE the path of the imported image as the object's tag
                    _imageStore[0].Tag = pImagePath;
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

        /// <summary>
        /// SaveImage Method: Saves a passed image to its original path, and in to the image list
        /// </summary>
        /// <param name="pImage">The Image to save.</param>
        /// <param name="pIndex">The Index of the Image in the ImageStorage List.</param>
        public void SaveImage(Image pImage, int pIndex)
        {
            // GET the path of the image from the tag in the relevant element in Image List
            string path = (_imageStore[pIndex].Tag).ToString();
            // CALL the SaveImage method and pass in the parameters with the path:
            SaveImage(pImage, pIndex, path);
        }

        /// <summary>
        /// SaveImage Method: Saves a passed image to its original path, and in to the image list
        /// </summary>
        /// <param name="pImage">The Image to save.</param>
        /// <param name="pIndex">The Index of the Image in the ImageStorage List.</param>
        /// <param name="path">The path to save the new Image at.</param>
        public void SaveImage(Image pImage, int pIndex, string path)
        {
            // SET the path of the edited image back to its path, to put in back into the list
            pImage.Tag = path;

            // SET the image in the image list to the newly edited image
            _imageStore[pIndex] = pImage;

            // SAVE the edited image to path
            (pImage as Bitmap).Save(path);
        }
    }
}