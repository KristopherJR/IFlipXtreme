using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FakeClasses
{
    public class FakeController
    {
        public FakeImageStorage FakeImageStorage;
        public FakeGalleryView FakeGalleryView;

        public FakeController()
        {
            FakeImageStorage = new FakeImageStorage();
            FakeGalleryView = new FakeGalleryView();
        }
    }
}
