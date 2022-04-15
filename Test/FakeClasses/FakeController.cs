//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Test
{
    public class FakeController
    {
        private FakeModel _fakeModel;
        private FakeGalleryView _fakeGalleryView;
        private CommandInvoker _commandInvoker;

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
            _commandInvoker = new CommandInvoker();

            _fakeModel.Subscribe(_fakeGalleryView);

            _fakeGalleryView.ExecutePointer = _commandInvoker.Execute;

            Action<string> loadImageAction = _fakeModel.LoadImage;

            Command<string> command = new Command<string>(loadImageAction);

            _fakeGalleryView.Commands.Add("Import", command);
        }
    }
}
