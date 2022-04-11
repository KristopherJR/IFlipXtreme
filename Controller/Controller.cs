using Library;
using View;
using Model;

namespace Controller
{
    public class Controller : IController
    {
        private Model.Model _model;
        private GalleryView _galleryView;
        private CommandInvoker _commandInvoker;

        #region Properties
        public GalleryView GalleryView
        {
            get { return _galleryView; }
        }

        public Model.Model Model
        {
            get { return _model; }
        }
        #endregion

        public Controller()
        {
            _model = new Model.Model();
            _galleryView = new GalleryView();
            _commandInvoker = new CommandInvoker();

            _model.Subscribe(_galleryView);

            _galleryView.ExecutePointer = _commandInvoker.Execute;

            Action<string> loadImageAction = _model.LoadImage;

            Command<string> command = new Command<string>(loadImageAction);

            _galleryView.Commands.Add("Import", command);
        }
    }
}
