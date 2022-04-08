using System;

namespace Test
{
    public class FakeController
    {
        private FakeModel _fakeModel;
        private FakeGalleryView _fakeGalleryView;

        #region Properties



        public FakeGalleryView FakeGalleryView
        {
            get { return _fakeGalleryView; }
        }

        public FakeModel FakeModel
        {
            get { return _fakeModel; }
        }
        #endregion

        public FakeController()
        {
            _fakeModel = new FakeModel();
            _fakeGalleryView = new FakeGalleryView();

            _fakeModel.Subscribe(_fakeGalleryView);

            Action<string> loadImageAction = _fakeModel.LoadImage;

            Command<string> command = new Command<string>(loadImageAction);

            _fakeGalleryView.Commands.Add("Import", command);
        }
    }
}
