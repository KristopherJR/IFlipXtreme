using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class FakeGalleryView
    {
        public void ImportButtonPressed()
        {
            // EXECUTE the Command object
            _execute(_importImage);
        }
       
    }
}
