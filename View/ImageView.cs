//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// ImageView Form:  Main editing window for the Image Flipper application
    /// </summary>
    public partial class ImageView : Form
    {
        #region Fields
        // DECLARE a dictionary to hold commands, call it "_commands"
        private Dictionary<string, ICommand> _commands;

        // DECLARE an Action of type ICommand to hold a pointer to the CommandInvoker's "Execute" Method.  Call it "_executePointer".
        Action<ICommand> _executePointer;

        // DECLARE an Action to hold a pointer to Form's "ToggleForms" Method.  Call it "_toggleFormPointer".
        private Action _toggleFormPointer;

        private bool isImageStretched = false;

        private int pictureBoxCentreX;
        private int pictureBoxCentreY;

        private int imageLeft;
        private int imageRight;
        private int imageTop;
        private int imageBottom;

        private Size _originalImageSize;

        private bool cropping;

        #endregion

        #region Properties

        // DECLARE a set property for "_image".  Call it "Image".
        public Image Image
        {
            set {
                labelIsStretched.Text = "";

                pictureBoxEditImage.SizeMode = PictureBoxSizeMode.CenterImage;
                isImageStretched = false;
                   
                    
                pictureBoxEditImage.Image = value;
                    

                if  (pictureBoxEditImage.Image != null )
                {
                    _originalImageSize = pictureBoxEditImage.Image.Size;
                    if (pictureBoxEditImage.Image.Height > pictureBoxEditImage.Height || pictureBoxEditImage.Image.Width > pictureBoxEditImage.Width)
                    {
                        pictureBoxEditImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        isImageStretched = true;
                        pictureBoxEditImage.Refresh();
                    }


                    if (pictureBoxEditImage.SizeMode == PictureBoxSizeMode.CenterImage) labelIsStretched.Text = "This image is Centered";
                    else if (pictureBoxEditImage.SizeMode == PictureBoxSizeMode.StretchImage) labelIsStretched.Text = "This image is Stretched";
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

        #endregion

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

        private void CalculateImageBoundaries()
        {
            if (!isImageStretched)
            {
                pictureBoxCentreX = pictureBoxEditImage.Width / 2;
                pictureBoxCentreY = pictureBoxEditImage.Height / 2;

                imageLeft = pictureBoxCentreX - (pictureBoxEditImage.Image.Width / 2);
                imageRight = pictureBoxCentreX + (pictureBoxEditImage.Image.Width / 2);
                imageTop = pictureBoxCentreY - (pictureBoxEditImage.Image.Height / 2);
                imageBottom = pictureBoxCentreY + (pictureBoxEditImage.Image.Height / 2);
            }
            else
            {
                imageRight = pictureBoxEditImage.Width;
                imageLeft = 0;
                imageBottom = pictureBoxEditImage.Height;
                imageTop = 0;
            }
        }

        private float[] CalculateStretchReverseMultiplier(Size pOriginal, Size pStretched)
        {
            float xMultiplier = 1f;
            float yMultiplier = 1f;

            if (pStretched.Height < pOriginal.Height || pStretched.Width < pOriginal.Width)
            {
                xMultiplier = (float)pOriginal.Width / (float)pStretched.Width;
                yMultiplier = (float)pOriginal.Height / (float)pStretched.Height;            
            }

            return new float[] {  xMultiplier,  yMultiplier  };
        }

        private void ResetEditor()
        {
            trackBarBrightness.Value = 50;
            trackBarContrast.Value = 50;
            trackBarSaturation.Value = 50;
            trackBarScale.Value = 50;
        }

        /// <summary>
        /// 
        /// 
        /// Code adapted from: https://ourcodeworld.com/articles/read/507/how-to-allow-only-numbers-inside-a-textbox-in-winforms-c-sharp
        /// </summary>
        /// <param name="pEnteredChar"></param>
        /// <returns></returns>
        private bool isNumerical(Char pEnteredChar)
        {
            if (!char.IsControl(pEnteredChar) && !char.IsDigit(pEnteredChar))
            {
                return true;
            }
            else return false;
        }

        private void trackBarBrightness_MouseUp(object sender, MouseEventArgs e)
        {
            // SET the ParameterOne to path:
            ((ICommand<int>)_commands["AdjustBrightness"]).ParameterOne = trackBarBrightness.Value;
            // SIGNAL to the CommandInvoker to fire the command:
            _executePointer(_commands["AdjustBrightness"]);

            trackBarBrightness.Value = 50;
        }

        #endregion

        private void trackBarContrast_MouseUp(object sender, MouseEventArgs e)
        {
            // SET the ParameterOne to path:
            ((ICommand<int>)_commands["AdjustContrast"]).ParameterOne = trackBarContrast.Value;
            // SIGNAL to the CommandInvoker to fire the command:
            _executePointer(_commands["AdjustContrast"]);

            trackBarContrast.Value = 50;
        }

        private void trackBarSaturation_MouseUp(object sender, MouseEventArgs e)
        {
            // SET the ParameterOne to path:
            ((ICommand<int>)_commands["AdjustSaturation"]).ParameterOne = trackBarSaturation.Value;
            // SIGNAL to the CommandInvoker to fire the command:
            _executePointer(_commands["AdjustSaturation"]);

            trackBarSaturation.Value = 50;
        }

        private void trackBarScale_MouseUp(object sender, MouseEventArgs e)
        {
            // IF neither size value is bigger than 3840, biggest image that can be resized is 3840*3840, resulting in largest possible of ~8000*8000
            if (pictureBoxEditImage.Image.Size.Width <= 3840 && pictureBoxEditImage.Image.Size.Height <= 3840)
            {
                int scaleValue = trackBarScale.Value;
                if (scaleValue < 25)
                {
                    scaleValue = 25;
                }
                // SET the ParameterOne to path:
                ((ICommand<int>)_commands["AdjustScale"]).ParameterOne = scaleValue;
                // SIGNAL to the CommandInvoker to fire the command:
                _executePointer(_commands["AdjustScale"]);
            }

            trackBarScale.Value = 50;
        }

        private void buttonRotateRight90_Click(object sender, EventArgs e)
        {
            // SET the ParameterOne to the correct rotate value:
            ((ICommand<int>)_commands["RotateImage"]).ParameterOne = -1;

            _executePointer((ICommand<int>)_commands["RotateImage"]);
        }

        private void buttonRotateLeft90_Click(object sender, EventArgs e)
        {
            // SET the ParameterOne to the correct rotate value:
            ((ICommand<int>)_commands["RotateImage"]).ParameterOne = 1;

            _executePointer((ICommand<int>)_commands["RotateImage"]);
        }

        private void buttonFlipVertical_Click(object sender, EventArgs e)
        {
            // SET the ParameterOne to the correct flip value:
            ((ICommand<int>)_commands["FlipImage"]).ParameterOne = 0;

            _executePointer((ICommand<int>)_commands["FlipImage"]);
        }

        private void buttonFlipHorizontal_Click(object sender, EventArgs e)
        {
            // SET the ParameterOne to the correct flip value:
            ((ICommand<int>)_commands["FlipImage"]).ParameterOne = 1;

            _executePointer((ICommand<int>)_commands["FlipImage"]);
        }

        private void textBoxCropLocationX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isNumerical(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Windows Forms Method:  Called when the form is loaded.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            _toggleFormPointer();
            ResetEditor();
        }

        /// <summary>
        /// Windows Forms Method:  Called when the Save Button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            _executePointer((ICommand)_commands["SaveImage"]);
            _toggleFormPointer();
            ResetEditor();
        }

        // Code adapted from: https://www.youtube.com/watch?v=7IR6J8Kw8cE&ab_channel=SundayNotice
        #region Crop functionality

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartCrop_Click(object sender, EventArgs e)
        {
            pictureBoxEditImage.MouseDown += new MouseEventHandler(pictureBoxEditImage_MouseDown);

            pictureBoxEditImage.MouseMove += new MouseEventHandler(pictureBoxEditImage_MouseMove);

            pictureBoxEditImage.MouseEnter += new EventHandler(pictureBoxEditImage_MouseEnter);
            Controls.Add(pictureBoxEditImage);

            cropping = true;
        }

        private void buttonEndCrop_Click(object sender, EventArgs e)
        {
            cropping = false;

            CalculateImageBoundaries();

            float cropOffsetX = cropX - imageLeft;
            float cropOffsetY = cropY - imageTop;

            float cropWidth = rectangleWidth;
            float cropHeight = rectangleHeight;

            if(isImageStretched)
            {
                float[] multipliers = CalculateStretchReverseMultiplier(_originalImageSize, pictureBoxEditImage.Size);

                //Console.WriteLine("Original Image Size: " + pictureBoxEditImage.Image.Size.ToString() + "Stretched Image Size: " + pictureBoxEditImage.Size.ToString());
                //Console.WriteLine("Mupltiply on X is: " + multipliers[0] + ", and multiply on Y is: " + multipliers[1]);

                



                cropOffsetX = cropOffsetX * multipliers[0];
                cropWidth = cropWidth * multipliers[0];

                cropOffsetY = cropOffsetY * multipliers[1];
                cropHeight = cropHeight * multipliers[1];
            }

            if (rectangleWidth > 0 && rectangleHeight > 0 && cropX > 0 && cropY > 0)
            {
                Cursor = Cursors.Default;

                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterOne = (int)cropOffsetX;
                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterTwo = (int)cropOffsetY;
                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterThree = (int)cropWidth;
                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterFour = (int)cropHeight;
                // SIGNAL to the CommandInvoker to fire the command:
                _executePointer(_commands["CropImage"]);

                cropX = 0;
                cropY = 0;
                rectangleWidth = 0;
                rectangleHeight = 0;

            }

            //if (pictureBoxEditImage.SizeMode == PictureBoxSizeMode.CenterImage) buttonIsStretched
            if (pictureBoxEditImage.SizeMode == PictureBoxSizeMode.StretchImage) Console.WriteLine("The image is stretched");
            Cursor = Cursors.Default;

        }

        int cropX, cropY, rectangleWidth, rectangleHeight;

        public Pen cropPen = new Pen(Color.White);

        private void pictureBoxEditImage_MouseDown(object sender, MouseEventArgs e)
        {
            //CalculateImageBoundaries();
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                cropX = e.X;
                cropY = e.Y;

                CalculateImageBoundaries();

                // PREVENTS crop on left boundary
                if (cropX < imageLeft)
                {
                    cropX = imageLeft;
                }

                if (cropY < imageTop)
                {
                    cropY = imageTop;
                }
            }
        }

        private void buttonGrayscaleFilter_Click(object sender, EventArgs e)
        {
            ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 0;
            _executePointer(_commands["ApplyFilter"]);
        }

        private void buttonSunburnFilter_Click(object sender, EventArgs e)
        {
            ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 1;
            _executePointer(_commands["ApplyFilter"]);
        }

        private void buttonBlurFilter_Click(object sender, EventArgs e)
        {
            ((ICommand<int>)_commands["ApplyFilter"]).ParameterOne = 2;
            _executePointer(_commands["ApplyFilter"]);
        }

        private void buttonRevertChanges_Click(object sender, EventArgs e)
        {
            _executePointer((ICommand)_commands["RevertChanges"]);
        }

        private void pictureBoxEditImage_MouseMove(object sender, MouseEventArgs e)
        {
            //CalculateImageBoundaries();

            base.OnMouseMove(e);
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                int mouseLocationX = e.X;
                int mouseLocationY = e.Y;

                pictureBoxEditImage.Refresh();

                CalculateImageBoundaries();

                if (mouseLocationX > imageRight)
                {
                    mouseLocationX = imageRight;
                }

                if (mouseLocationY > imageBottom)
                {
                    mouseLocationY = imageBottom;
                }

                

                rectangleWidth = mouseLocationX - cropX;
                rectangleHeight = mouseLocationY - cropY;
                



                Graphics g = pictureBoxEditImage.CreateGraphics();
                g.DrawRectangle(cropPen, cropX, cropY, rectangleWidth, rectangleHeight);
                g.Dispose();
            }
        }

        private void pictureBoxEditImage_MouseEnter(object sender, EventArgs e)
        {
            if(cropping)
            {
                base.OnMouseEnter(e);
                Cursor = Cursors.Cross;
                
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void pictureBoxEditImage_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }


        #endregion
    }
}
