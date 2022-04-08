using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class FakeImageStorage
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

        public bool LoadImage(string pImagePath)
        {
            try
            {

                _imageStore.Add(Image.FromFile(pImagePath));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        

    }
}
