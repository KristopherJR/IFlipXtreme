//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Test
{
    public class FakeImageStorage
    {
        #region Fields

        private List<Image> _imageStore;

        #endregion Fields

        #region Properties

        public List<Image> ImageStore
        {
            get { return _imageStore; }
        }

        #endregion Properties

        public FakeImageStorage()
        {
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

                    Image newImage;

                    using (FileStream file = new FileStream(pImagePath, FileMode.Open))
                    {
                        newImage = Image.FromStream(file);
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
                    Image newImage;

                    using (FileStream file = new FileStream(pImagePath, FileMode.Open))
                    {
                        newImage = Image.FromStream(file);
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
    }
}