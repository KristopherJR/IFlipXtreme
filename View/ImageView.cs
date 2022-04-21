//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// ImageView Form:  Main editing window for the Image Flipper application
    /// </summary>
    public partial class ImageView : Form, IImageView
    {
        #region Fields

        // DECLARE a dictionary to hold commands, call it "_commands"
        private Dictionary<string, ICommand> _commands;

        // DECLARE an Action of type ICommand to hold a pointer to the CommandInvoker's "Execute" Method, call it "_executePointer".
        private Action<ICommand> _executePointer;

        // DECLARE an Action to hold a pointer to Form's "ToggleForms" Method, call it "_toggleFormPointer".
        private Action _toggleFormPointer;

        // DECLARE a bool to check if an Image has been stretched, call it "_isImageStretched":
        private bool _isImageStretched = false;

        // DECLARE an int to define the X co-ordinate of the centre of the PictureBox, call it "_pictureBoxCentreX":
        private int _pictureBoxCentreX;

        // DECLARE an int to define the Y co-ordinate of the centre of the PictureBox, call it "_pictureBoxCentreY":
        private int _pictureBoxCentreY;

        // DECLARE an int for the left boundary of the Image, call it "_imageLeft":
        private int _imageLeft;

        // DECLARE an int for the right boundary of the Image, call it "_imageRight":
        private int _imageRight;

        // DECLARE an int for the top boundary of the Image, call it "_imageTop":
        private int _imageTop;

        // DECLARE an int for the bottom boundary of the Image, call it "_imageBottom":
        private int _imageBottom;

        // DECLARE ints for the crop-selection, "_cropX", "_cropY", "_rectangleWidth", and "_rectangleWidth":
        private int _cropX, _cropY, _rectangleWidth, _rectangleHeight;

        // DECLARE a Pen that the user can use to draw their cropping selection, call it "_cropPen":
        private Pen _cropPen = new Pen(Color.White);

        // DECLARE a Size, call it "_originalImageSize":
        private Size _originalImageSize;

        // DECLARE a bool to determine if the user is cropping, call it "_cropping":
        private bool _cropping;

        #endregion Fields

        #region Properties

        // DECLARE a set property for "_image".  Call it "Image".
        public Image Image
        {
            set
            {
                // RESET the "labelIsStrecthed" text:
                labelIsStretched.Text = "";
                // SET the PictureBox SizeMode to "CenterImage" by default:
                pictureBoxEditImage.SizeMode = PictureBoxSizeMode.CenterImage;
                // SET "_isImageStretched" to false by default:
                _isImageStretched = false;

                // SET the PictureBox Image to the one provided:
                pictureBoxEditImage.Image = value;

                // IF the PictureBox Image is not null:
                if (pictureBoxEditImage.Image != null)
                {
                    // STORE the original size of the provided Image:
                    _originalImageSize = pictureBoxEditImage.Image.Size;
                    // IF the provided Image is larger than the PictureBox:
                    if (pictureBoxEditImage.Image.Height > pictureBoxEditImage.Height || pictureBoxEditImage.Image.Width > pictureBoxEditImage.Width)
                    {
                        // SET the PictureBox SizeMode to "StretchImage":
                        pictureBoxEditImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        // SET "_isImageStretched" to true:
                        _isImageStretched = true;
                        // REFRESH the Image in the PictureBox:
                        pictureBoxEditImage.Refresh();
                    }

                    // SET the label depending on if the Image is Stretched or not:
                    if (pictureBoxEditImage.SizeMode == PictureBoxSizeMode.CenterImage) labelIsStretched.Text = "This is the real size of the image";
                    else if (pictureBoxEditImage.SizeMode == PictureBoxSizeMode.StretchImage) labelIsStretched.Text = "This image is Stretched";
                    // DISPLAY the resolution of the current Image in "labelResolution":
                    labelResolution.Text = pictureBoxEditImage.Image.Height.ToString() + ":" + pictureBoxEditImage.Image.Width.ToString();
                }
            }
        }

        // DECLARE a set property for "_toggleFormPointer".  Call it "ToggleFormPointer".
        public Action ToggleFormPointer
        {
            set { _toggleFormPointer = value; }
        }

        // DECLARE a set property for "_executePointer".  Call it "ExecutePointer".
        public Action<ICommand> ExecutePointer
        {
            set { _executePointer = value; }
        }

        // DECLARE a get-set property for "_commands".  Call it "Commands".
        public Dictionary<string, ICommand> Commands
        {
            set { _commands = value; }
            get { return _commands; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// ImageView Constructor
        /// </summary>
        public ImageView()
        {
            // CALL "InitializeComponent" to initialise Form GUI.
            InitializeComponent();

            // INSTANTIATE "_commands" as a new Dictionary of type <string, Icommand>.
            _commands = new Dictionary<string, ICommand>();

            // Centre the form on the users monitor
            this.StartPosition = FormStartPosition.CenterScreen;

            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        /// <summary>
        /// CalculateImageBoundaries(): Calculates the boundaries of the Image for use when cropping and scaling.
        /// </summary>
        private void CalculateImageBoundaries()
        {
            // CHECK if the Image has been stretched:
            if (!_isImageStretched)
            {
                // CALCULATE the X and Y coords of the centre of the unstretched image
                _pictureBoxCentreX = pictureBoxEditImage.Width / 2;
                _pictureBoxCentreY = pictureBoxEditImage.Height / 2;

                // CALCULATE the left, right, bottom and top corners of the image relative to the picturebox
                _imageLeft = _pictureBoxCentreX - (pictureBoxEditImage.Image.Width / 2);
                _imageRight = _pictureBoxCentreX + (pictureBoxEditImage.Image.Width / 2);
                _imageTop = _pictureBoxCentreY - (pictureBoxEditImage.Image.Height / 2);
                _imageBottom = _pictureBoxCentreY + (pictureBoxEditImage.Image.Height / 2);
            }
            else
            {
                // IF it is stretched, set the boundaries to match the PictureBox:
                _imageRight = pictureBoxEditImage.Width;
                _imageLeft = 0;
                _imageBottom = pictureBoxEditImage.Height;
                _imageTop = 0;
            }
        }

        /// <summary>
        /// CalculateStretchReverseMultiplier(): Calculates the factor of which an Image has been shrunk. Needed for scaling changes to large images.
        /// </summary>
        /// <param name="pOriginal">The size of the Original Image. (Usually Big)</param>
        /// <param name="pStretched">The size of the Stretched Image.</param>
        /// <returns>A float array containing the X and Y multiplers.</returns>
        private float[] CalculateStretchReverseMultiplier(Size pOriginal, Size pStretched)
        {
            // DECLARE an "xMultiplier" and a "yMultiplier", set it to 1f by default:
            float xMultiplier = 1f;
            float yMultiplier = 1f;

            // IF the Image has been Stretched:
            if (pStretched.Height < pOriginal.Height || pStretched.Width < pOriginal.Width)
            {
                // SET the multiplers to the factor in which it has been stretched:
                xMultiplier = (float)pOriginal.Width / (float)pStretched.Width;
                yMultiplier = (float)pOriginal.Height / (float)pStretched.Height;
            }

            // RETURN the multiplers:
            return new float[] { xMultiplier, yMultiplier };
        }

        /// <summary>
        /// ResetEditor(): Resets the Editors controls to default values.
        /// </summary>
        private void ResetEditor()
        {
            // RESET all control values to default:
            trackBarBrightness.Value = 50;
            trackBarContrast.Value = 50;
            trackBarSaturation.Value = 50;
            trackBarScale.Value = 50;
        }

        /// <summary>
        /// Windows Forms Method: Called when the user releases the Brightness Slider.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void trackBarBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            // SET the ParameterOne to path:
            ((ICommand<int>)_commands["AdjustBrightness"]).ParameterOne = trackBarBrightness.Value;

            // TRY to execute the command
            try
            {
                // SIGNAL to the CommandInvoker to fire the command:
                _executePointer(_commands["AdjustBrightness"]);
            }

            // CATCH the InvalidParamterException if thrown:
            catch (InvalidParameterException ex)
            {
                // PRINT the exception message:
                Console.WriteLine(ex.Message);
            }
            // RESET to default value:
            trackBarBrightness.Value = 50;
        }

        /// <summary>
        /// Windows Forms Method: Called when the user releases the Contrast Slider.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void trackBarContrast_MouseUp(object sender, MouseEventArgs e)
        {
            // IF the command object "AdjustContrast" exists:
            if (_commands.ContainsKey("AdjustContrast"))
            {
                // SET the ParameterOne to path:
                ((ICommand<int>)_commands["AdjustContrast"]).ParameterOne = trackBarContrast.Value;

                // TRY to execute the command
                try
                {
                    // SIGNAL to the CommandInvoker to fire the command:
                    _executePointer(_commands["AdjustContrast"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }

            // RESET to default value:
            trackBarContrast.Value = 50;
        }

        /// <summary>
        /// Windows Forms Method: Called when the user releases the Saturation Slider.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void trackBarSaturation_MouseUp(object sender, MouseEventArgs e)
        {
            // IF the command object "AdjustSaturation" exists:
            if (_commands.ContainsKey("AdjustSaturation"))
            {
                // SET the ParameterOne to path:
                ((ICommand<int>)_commands["AdjustSaturation"]).ParameterOne = trackBarSaturation.Value;

                // TRY to execute the command
                try
                {
                    // SIGNAL to the CommandInvoker to fire the command:
                    _executePointer(_commands["AdjustSaturation"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }

            // RESET to default value:
            trackBarSaturation.Value = 50;
        }

        /// <summary>
        /// Windows Forms Method: Called when the user releases the Scale Slider.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void trackBarScale_MouseUp(object sender, MouseEventArgs e)
        {
            // IF the command object "AdjustScale" exists:
            if (_commands.ContainsKey("AdjustScale"))
            {
                // IF neither size value is bigger than 3840, biggest image that can be resized is 3840*3840, resulting in largest possible of ~8000*8000
                if ((pictureBoxEditImage.Image.Size.Width <= 3840 && pictureBoxEditImage.Image.Size.Height <= 3840) || trackBarScale.Value < 51)
                {
                    // SET scaleValue to the value of the scale track bar
                    int scaleValue = trackBarScale.Value;

                    // PREVENT the user setting a scale value less than 25:
                    if (scaleValue < 25)
                    {
                        scaleValue = 25;
                    }

                        // SET the ParameterOne to path:
                        ((ICommand<int>)_commands["AdjustScale"]).ParameterOne = scaleValue;

                    // TRY to execute the command
                    try
                    {
                        // SIGNAL to the CommandInvoker to fire the command:
                        _executePointer(_commands["AdjustScale"]);
                    }
                    // CATCH the InvalidParamterException if thrown:
                    catch (InvalidParameterException ex)
                    {
                        // PRINT the exception message:
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }

            // RESET to default value:
            trackBarScale.Value = 50;
        }

        /// <summary>
        /// Windows Forms Method: Called when the user clicks rotate right button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonRotateRight90_Click(object sender, EventArgs e)
        {
            // IF the command object "RotateImage" exists:
            if (_commands.ContainsKey("RotateImage"))
            {
                try
                {
                    // SET the ParameterOne to the correct rotate value:
                    ((ICommand<int>)_commands["RotateImage"]).ParameterOne = -1;
                    // FIRE the "RotateImage" Command:
                    _executePointer((ICommand<int>)_commands["RotateImage"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the user clicks rotate left button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonRotateLeft90_Click(object sender, EventArgs e)
        {
            // IF the command object "RotateImage" exists:
            if (_commands.ContainsKey("RotateImage"))
            {
                try
                {
                    // SET the ParameterOne to the correct rotate value:
                    ((ICommand<int>)_commands["RotateImage"]).ParameterOne = 1;
                    // FIRE the "RotateImage" Command:
                    _executePointer((ICommand<int>)_commands["RotateImage"]);
                }
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the user clicks the vertical flip button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonFlipVertical_Click(object sender, EventArgs e)
        {
            // IF the command object "FlipImage" exists:
            if (_commands.ContainsKey("FlipImage"))
            {
                // SET the ParameterOne to the correct flip value:
                ((ICommand<int>)_commands["FlipImage"]).ParameterOne = 0;

                // TRY to execute the command
                try
                {
                    // FIRE the "FlipImage" Command:
                    _executePointer((ICommand<int>)_commands["FlipImage"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the user clicks the horizontal flip button.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonFlipHorizontal_Click(object sender, EventArgs e)
        {
            // IF the command object "FlipImage" exists:
            if (_commands.ContainsKey("FlipImage"))
            {
                // SET the ParameterOne to the correct flip value:
                ((ICommand<int>)_commands["FlipImage"]).ParameterOne = 1;

                // TRY to execute the command
                try
                {
                    // FIRE the "FlipImage" Command:
                    _executePointer((ICommand<int>)_commands["FlipImage"]);
                }
                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the Grayscale Filter button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonGrayscaleFilter_Click(object sender, EventArgs e)
        {
            // IF the command object "ApplyFilter" exists:
            if (_commands.ContainsKey("ApplyFilter"))
            {
                ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 0;

                // TRY to execute the command
                try
                {
                    // FIRE the "ApplyFilter" Command:
                    _executePointer(_commands["ApplyFilter"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the Sunburn Filter button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonSunburnFilter_Click(object sender, EventArgs e)
        {
            // IF the command object "ApplyFilter" exists:
            if (_commands.ContainsKey("ApplyFilter"))
            {
                ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 1;
                // TRY to execute the command
                try
                {
                    // FIRE the "ApplyFilter" Command:
                    _executePointer(_commands["ApplyFilter"]);
                }
                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the Blur Filter button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonBlurFilter_Click(object sender, EventArgs e)
        {
            // IF the command object "ApplyFilter" exists:
            if (_commands.ContainsKey("ApplyFilter"))
            {
                ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 2;

                // TRY to execute the command
                try
                {
                    // FIRE the "ApplyFilter" Command:
                    _executePointer(_commands["ApplyFilter"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the Blur Filter button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonRandomFilter_Click(object sender, EventArgs e)
        {
            // IF the command object "ApplyFilter" exists:
            if (_commands.ContainsKey("ApplyFilter"))
            {
                ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 3;

                // TRY to execute the command
                try
                {
                    // FIRE the "ApplyFilter" Command:
                    _executePointer(_commands["ApplyFilter"]);
                }

                // CATCH the InvalidParamterException if thrown:
                catch (InvalidParameterException ex)
                {
                    // PRINT the exception message:
                    Console.WriteLine(ex.Message);
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the Revert Changes button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonRevertChanges_Click(object sender, EventArgs e)
        {
            // IF the command object "RevertChanges" exists:
            if (_commands.ContainsKey("RevertChanges"))
            {
                // EXECUTE the "RevertChanges" Command:
                _executePointer((ICommand)_commands["RevertChanges"]);
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }
        }

        /// <summary>
        /// Windows Forms Method:  Called when the form is loaded.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            // TOGGLE the form visibility:
            _toggleFormPointer();
            // RESET the editor:
            ResetEditor();
        }

        /// <summary>
        /// Windows Forms Method:  Called when the Save Button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param
        /// <param name="e">Event arguments</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // IF the command object "SaveImage" exists:
            if (_commands.ContainsKey("SaveImage"))
            {
                // FIRE the "SaveImage" Command:
                _executePointer((ICommand)_commands["SaveImage"]);
                // TOGGLE the form visibility:
                _toggleFormPointer();
                // RESET the editor:
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }

            ResetEditor();
        }

        /// <summary>
        /// Windows Forms Method: Called when the Save As Button is clicked.
        ///                       Allows the user to save an Image to a path of their choosing.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            // IF the command object "SaveImage" exists:
            if (_commands.ContainsKey("SaveImage"))
            {
                // INSTANTIATE a new SaveFileDialog, call it "saveFileDialog":
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // SET the Title of the SaveFileDialog:
                saveFileDialog.Title = "Save an Image File";
                // APPLY Image Filters so the user can see other Image files in the Dialog:
                saveFileDialog.Filter = "JPeg Image|*.jpg|Png Image|*.png|Bitmap Image|*.bmp|Gif Image|*.gif";

                // CHECK the user has provided an appropriate name and path to save the Image:
                if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    // STORE the user-defined path:
                    string path = saveFileDialog.FileName;
                    // SET the Path in the Command object:
                    ((ICommand<string>)_commands["SaveImageToPath"]).ParameterOne = path;
                    // EXECUTE the "SaveImageToPath" Command:
                    _executePointer((ICommand)_commands["SaveImageToPath"]);
                    // TOGGLE the Form visibility:
                    _toggleFormPointer();
                }
            }

            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }

            // RESET the Editor:
            ResetEditor();
        }

        // Code adapted from: https://www.youtube.com/watch?v=7IR6J8Kw8cE&ab_channel=SundayNotice

        #region Crop functionality

        /// <summary>
        /// Windows Forms Method: Called when the Start Crop button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonStartCrop_Click(object sender, EventArgs e)
        {
            // ADD Mouse Event Handlers to the PictureBox:
            pictureBoxEditImage.MouseDown += new MouseEventHandler(pictureBoxEditImage_MouseDown);
            pictureBoxEditImage.MouseMove += new MouseEventHandler(pictureBoxEditImage_MouseMove);
            pictureBoxEditImage.MouseEnter += new EventHandler(pictureBoxEditImage_MouseEnter);
            Controls.Add(pictureBoxEditImage);
            // SET 'cropping' to true:
            _cropping = true;
        }

        /// <summary>
        /// Windows Forms Method: Called when the End Crop button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonEndCrop_Click(object sender, EventArgs e)
        {
            // IF the command object "SaveImage" exists:
            if (_commands.ContainsKey("SaveImage"))
            {
                // SET 'cropping' to false:
                _cropping = false;
                // CALCULATE the current Image Boundaries:
                CalculateImageBoundaries();
                // SET the Crop Offsets using the Image Boundaries and users crop selection:
                float cropOffsetX = _cropX - _imageLeft;
                float cropOffsetY = _cropY - _imageTop;
                float cropWidth = _rectangleWidth;
                float cropHeight = _rectangleHeight;

                // CHECK if the Image has been stretched:
                if (_isImageStretched)
                {
                    // CALCULATE the scale factor of the Image (how much is has been stretched or shrunk):
                    float[] multipliers = CalculateStretchReverseMultiplier(_originalImageSize, pictureBoxEditImage.Size);

                    // ADJUST The cropping selection by the multiplers:
                    cropOffsetX = cropOffsetX * multipliers[0];
                    cropWidth = cropWidth * multipliers[0];
                    cropOffsetY = cropOffsetY * multipliers[1];
                    cropHeight = cropHeight * multipliers[1];
                }

                // CHECK the user has drawn a cropping selection bigger than nothing:
                if (_rectangleWidth > 0 && _rectangleHeight > 0 && _cropX > 0 && _cropY > 0)
                {
                    // RESET Their cursor back to default:
                    Cursor = Cursors.Default;

                    // SET the ParameterOne to path:
                    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterOne = (int)cropOffsetX;
                    // SET the ParameterTwo to path:
                    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterTwo = (int)cropOffsetY;
                    // SET the ParameterThree to path:
                    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterThree = (int)cropWidth;
                    // SET the ParameterFour to path:
                    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterFour = (int)cropHeight;

                    // TRY to execute the command
                    try
                    {
                        // SIGNAL to the CommandInvoker to fire the command:
                        _executePointer(_commands["CropImage"]);
                    }

                    // CATCH the InvalidParamterException if thorwn
                    catch (InvalidParameterException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Please draw a crop rectangle before ending your crop!");
                }

                
            }
            // THROW a CommandDoesNotExistException if the command is not found in the dictionary
            else
            {
                throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
            }

            // RESET the crop selection parameters:
            _cropX = 0;
            _cropY = 0;
            _rectangleWidth = 0;
            _rectangleHeight = 0;

            // RESET the cursor back to Default:
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Windows Forms Method: Call when the user clicks on the Image PictureBox.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void pictureBoxEditImage_MouseDown(object sender, MouseEventArgs e)
        {
            // PASS the MouseEventArgs to base:
            base.OnMouseDown(e);
            // IF the user has pressed the left mouse button:
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // SET their cursor to a Cross:
                Cursor = Cursors.Cross;
                // SET the "_cropPen" DashStyle to Dashed:
                _cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                // SET the "_cropX" and "_cropY" to the current Mouse position:
                _cropX = e.X;
                _cropY = e.Y;
                // CALCULATE the current Image boundaries:
                CalculateImageBoundaries();

                // PREVENT the user cropping past the left Image boundary:
                if (_cropX < _imageLeft)
                {
                    _cropX = _imageLeft;
                }
                // PREVENT the user cropping past the top Image boundary:
                if (_cropY < _imageTop)
                {
                    _cropY = _imageTop;
                }
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the mouse is moved in the main picturebox.  Used for crop functionality
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void pictureBoxEditImage_MouseMove(object sender, MouseEventArgs e)
        {
            // PASS eventargs to parent
            base.OnMouseMove(e);

            // IF left mouse button is pressed down
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // SET mouseLocation variables to the mouse location
                int mouseLocationX = e.X;
                int mouseLocationY = e.Y;

                // RESET & REDRAW the pictureBoxEditImage, needed to update the rectangle crop box that is drawn
                pictureBoxEditImage.Refresh();

                // CALL CalculateImageBoundaries to recalculate the edges of the image relative to the picture box
                CalculateImageBoundaries();

                // IF mouse is off the right side of the image
                if (mouseLocationX > _imageRight)
                {
                    // SET mouseLocationX to the right border of the image, to treat the mouse as if it is just at the edge of the image
                    mouseLocationX = _imageRight;
                }

                // IF mouse is off the bottom side of the image
                if (mouseLocationY > _imageBottom)
                {
                    // SET mouseLocationy to the bottom border of the image, to treat the mouse as if it is just at the edge of the image
                    mouseLocationY = _imageBottom;
                }

                // CALCULATE the width & height of the crop rectangle, the difference between where the mouse is now and where it was at the inital click
                _rectangleWidth = mouseLocationX - _cropX;
                _rectangleHeight = mouseLocationY - _cropY;

                // DECLARE and INSTANTIATE a new Graphics object.  Control of pictureBoxEditImage
                Graphics g = pictureBoxEditImage.CreateGraphics();

                // DRAW the crop rectangle
                g.DrawRectangle(_cropPen, _cropX, _cropY, _rectangleWidth, _rectangleHeight);

                // DISPOSE of the graphics object
                g.Dispose();
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the the mouse enters the pictureBox.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void pictureBoxEditImage_MouseEnter(object sender, EventArgs e)
        {
            // IF the user is currently cropping (Crop button and been pressed and end crop has not)
            if (_cropping)
            {
                // PASS eventargs to parent
                base.OnMouseEnter(e);

                // SET the cursor skin to a cross
                Cursor = Cursors.Cross;
            }
            else
            {
                // SET the cursor skin to the default cursor if the user is not cropping
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Windows Forms Method: Called when the the mouse leaves the pictureBox.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void pictureBoxEditImage_MouseLeave(object sender, EventArgs e)
        {
            // SET the cursor skin to the default cursor
            Cursor = Cursors.Default;
        }

        #endregion Crop functionality

        #endregion Methods
    }
}