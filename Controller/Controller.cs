//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using View;
using System;
using Model;
using System.Windows.Forms;

namespace Controller
{
    /// <summary>
    /// Controller Class: High level class.  Holds reference to both View and Model projects, and the commandInvoker. 
    /// </summary>
    public class Controller : IController
    {
        // DECLARE a new Model object to hold a refence to the model (server) of the application.  Call it "_model".
        private Model.Model _model;

        // DECLARE a new Model object to hold a refence to the view (GUI) of the application.  Call it "_view".
        private View.View _view;

        // DECLARE a new CommandInvoker object to hold a refence to the commandInvoker.  Call it "_commandInvoker".
        private CommandInvoker _commandInvoker;

        #region Properties
        // DECLARE a get property to access "_model"
        public Model.Model Model
        {
            get { return _model; }
        }
        #endregion

        /// <summary>
        /// Constructor for Controller class
        /// </summary>
        public Controller()
        {
            // INSTANTIATE "_model" to as new Model
            _model = new Model.Model();

            // INSTANTIATE "_view" as a new View
            _view = new View.View();

            // INSTANTIATE "_commandInvoker" as a new Command Invoker            
            _commandInvoker = new CommandInvoker();

            // CALL the model's Subscribe Method and pass in the View object.  This subscribes the GUI to the server for updates
            _model.Subscribe(_view);

            // SET the execute pointer in the view to the Command Invoker's Execute method
            _view.ExecutePointer = _commandInvoker.Execute;

            // INITIALISE the command objects and pass them to relevant views
            InitialiseCommands();

            // CALL StartApp in view to launch the Immage Flipper program
            _view.StartApp();
        }

        /// <summary>
        /// InitialiseCommands Method: Generates the needed Command Objects and passes them to the relevant Views.
        /// </summary>
        private void InitialiseCommands()
        {
            #region Actions

            // DECLARE & INSTANTIATE action objects that are used by the Gallery View.  These will be placed in Command Objects.
            Action<string> loadImageAction = _model.LoadImage;
            Action<int> openImageAction = _model.OpenImage;

            // DECLARE & INSTANTIATE action objects that are used by the Image View (Editor).  These will be placed in Command Objects.
            Action<int> adjustBrightnessAction = _model.AdjustBrightness;
            Action<int> adjustContrastAction = _model.AdjustContrast;
            Action<int> adjustSaturationAction = _model.AdjustSaturation;
            Action<int> adjustScaleAction = _model.AdjustScale;
            Action<int, int, int, int> cropImageAction = _model.CropImage;
            Action saveImageAction = _model.SaveImage;
            Action<int> applyFilterAction = _model.ApplyFilter;
            Action<int> rotateImageAction = _model.RotateImage;
            Action<int> flipImageAction = _model.FlipImage;
            #endregion

            #region Commands
            // DECLARE & INSTANTIATE command objects that are used by the Gallery View, pass in the relevant Actions that were defined prior.
            Command<string> loadImageCommand = new Command<string>(loadImageAction);
            Command<int> openImageCommand = new Command<int>(openImageAction);

            // DECLARE & INSTANTIATE command objects that are used by the Image View (Editor), pass in the relevant Actions that were defined prior.
            Command<int> adjustBrightnessCommand = new Command<int>(adjustBrightnessAction);
            Command<int> adjustContrastCommand = new Command<int>(adjustContrastAction);
            Command<int> adjustSaturationCommand = new Command<int>(adjustSaturationAction);
            Command<int> adjustScaleCommand = new Command<int>(adjustScaleAction);
            Command<int, int, int, int> cropImageCommand = new Command<int, int, int, int>(cropImageAction);
            Command saveImageCommand = new Command(saveImageAction);
            Command<int> applyFilterCommand = new Command<int>(applyFilterAction);
            Command<int> rotateImageCommand = new Command<int>(rotateImageAction);
            Command<int> flipImageCommand = new Command<int>(flipImageAction);
            
            // ADD the relevant Command Objects to the Gallery View's list of commands
            _view.GalleryView.Commands.Add("LoadImage", loadImageCommand);
            _view.GalleryView.Commands.Add("OpenImage", openImageCommand);

            // ADD the relevant Command Objects to the Image View's list of commands
            _view.ImageView.Commands.Add("AdjustBrightness", adjustBrightnessCommand);
            _view.ImageView.Commands.Add("AdjustContrast", adjustContrastCommand);
            _view.ImageView.Commands.Add("AdjustSaturation", adjustSaturationCommand);
            _view.ImageView.Commands.Add("AdjustScale", adjustScaleCommand);
            _view.ImageView.Commands.Add("CropImage", cropImageCommand);
            _view.ImageView.Commands.Add("SaveImage", saveImageCommand);
            _view.ImageView.Commands.Add("ApplyFilter", applyFilterCommand);
            _view.ImageView.Commands.Add("RotateImage", rotateImageCommand);
            _view.ImageView.Commands.Add("FlipImage", flipImageCommand);
            #endregion
        }
    }
}
