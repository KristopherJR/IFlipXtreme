using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    public class ImageStorage
    {
        #region Fields
        private List<Image> _imageStore;
        #endregion

        #region Properties
        public List<Image> ImageStore
        {
            get { return _imageStore; }
        }
        #endregion

        public FakeImageStorage()
        {
            _imageStore = new List<Image>();
        }

        /// <summary>
        /// Loads a specified image from path
        /// </summary>
        /// <param name="pImagePath"></param>
        /// <returns></returns>
        public bool LoadImage(string pImagePath)
        {
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
                else
                {
                    // ADD new image to the end of _imageStore, if it is not full
                    _imageStore.Add(Image.FromFile(pImagePath));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }



    }
}
