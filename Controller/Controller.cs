using Library;
using View;
using System;
using Model;
using System.Windows.Forms;

namespace Controller
{
    public class Controller : IController
    {
        private Model.Model _model;
        private View.View _view;
        private CommandInvoker _commandInvoker;

        #region Properties
        public Model.Model Model
        {
            get { return _model; }
        }
        #endregion

        public Controller()
        {
            _model = new Model.Model();

            _view = new View.View();

            //_galleryView = new GalleryView();
            
            _commandInvoker = new CommandInvoker();

            _model.Subscribe(_view);

            _view.ExecutePointer = _commandInvoker.Execute;

            #region Actions
            Action<string> loadImageAction = _model.LoadImage;
            Action<int> adjustBrightnessAction = _model.AdjustBrightness;
            Action<int> adjustContrastAction = _model.AdjustContrast;
            Action<int> adjustSaturationAction = _model.AdjustSaturation;
            Action<int> adjustScaleAction = _model.AdjustScale;
            Action<int,int,int,int> cropImageAction = _model.CropImage;
            Action saveImageAction = _model.SaveImage;
            Action<int> applyFilterAction = _model.ApplyFilter;
            Action<int> rotateImageAction = _model.RotateImage;
            Action<int> flipImageAction = _model.FlipImage;
            #endregion

            #region Commands
            Command<string> loadImageCommand = new Command<string>(loadImageAction);
            Command<int> adjustBrightnessCommand = new Command<int>(adjustBrightnessAction);
            Command<int> adjustContrastCommand = new Command<int>(adjustContrastAction);
            Command<int> adjustSaturationCommand = new Command<int>(adjustSaturationAction);
            Command<int> adjustScaleCommand = new Command<int>(adjustScaleAction);
            Command<int,int,int,int> cropImageCommand = new Command<int,int,int,int>(cropImageAction);
            Command saveImageCommand = new Command(saveImageAction);
            Command<int> applyFilterCommand = new Command<int>(applyFilterAction);
            Command<int> rotateImageCommand = new Command<int>(rotateImageAction);
            Command<int> flipImageCommand = new Command<int>(flipImageAction);

            _view.GalleryView.Commands.Add("LoadImage", loadImageCommand);
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

            _view.StartApp();
        }
    }
}
