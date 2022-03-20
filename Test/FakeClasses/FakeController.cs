using System;

namespace Test.FakeClasses
{
    public class FakeController
    {
        private FakeModel _fakeModel;
        private FakeGalleryView _fakeGalleryView;

        public FakeGalleryView FakeGalleryView
        {
            get { return _fakeGalleryView; }
        }

        public FakeController()
        {
            _fakeModel = new FakeModel();
            _fakeGalleryView = new FakeGalleryView();

            Action<string> loadImageAction = _fakeModel.FakeImageStorage.LoadImage;

            FakeCommandOneParameter command = new FakeCommandOneParameter((Action<Type>)loadImageAction);

            _fakeGalleryView.Commands.Add("Import", (FakeICommand)command);
        }
    }
}
