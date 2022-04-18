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

        #endregion

        #region Properties

        // DECLARE a set property for "_image".  Call it "Image".
        public Image Image
        {
            set {
                    pictureBoxEditImage.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBoxEditImage.Image = value;

                    if  (pictureBoxEditImage.Image != null && (pictureBoxEditImage.Image.Height > pictureBoxEditImage.Height || pictureBoxEditImage.Image.Width > pictureBoxEditImage.Width))
                    {
                        //pictureBoxEditImage.SizeMode = PictureBoxSizeMode.StretchImage;
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

        /// <summary>
        /// Windows Forms Method:  Called when the form is loaded.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void ImageView_Load(object sender, EventArgs e)
        {


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

        /// <summary>
        /// Windows Forms Method:  Called when text is changed in the Crop Location Y box
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void textBoxCropLocationY_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Windows Forms Method:  Called when text is changed in the Crop Location X box
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void textBoxCropLocationX_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Windows Forms Method:  Called when text is changed in the Crop Height box
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void textBoxCropHeight_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Windows Forms Method:  Called when text is changed in the Crop Width box
        /// </summary>
        /// <param name="sender">The sender</param>
        private void textBoxCropWidth_TextChanged(object sender, EventArgs e)
        {

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
            int scaleValue = trackBarScale.Value;
            if (scaleValue < 25)
            {
                scaleValue = 25;
            }
            // SET the ParameterOne to path:
            ((ICommand<int>)_commands["AdjustScale"]).ParameterOne = scaleValue;
            // SIGNAL to the CommandInvoker to fire the command:
            _executePointer(_commands["AdjustScale"]);

            trackBarScale.Value = 50;
        }

        //private void buttonCrop_Click(object sender, EventArgs e)
        //{
        //    // SET the ParameterOne to path:
        //    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterOne = Int32.Parse(this.textBoxCropLocationX.Text);
        //    // SET the ParameterOne to path:
        //    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterTwo = Int32.Parse(this.textBoxCropLocationY.Text);
        //    // SET the ParameterOne to path:
        //    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterThree = Int32.Parse(this.textBoxCropWidth.Text);
        //    // SET the ParameterOne to path:
        //    ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterFour = Int32.Parse(this.textBoxCropHeight.Text);
        //    // SIGNAL to the CommandInvoker to fire the command:
        //    _executePointer(_commands["CropImage"]);
        //}

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

        /// <summary>
        /// Insert Reference from here onwards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonStartCrop_Click(object sender, EventArgs e)
        {
            pictureBoxEditImage.MouseDown += new MouseEventHandler(pictureBoxEditImage_MouseDown);

            pictureBoxEditImage.MouseMove += new MouseEventHandler(pictureBoxEditImage_MouseMove);

            pictureBoxEditImage.MouseEnter += new EventHandler(pictureBoxEditImage_MouseEnter);
            Controls.Add(pictureBoxEditImage);
        }

        private void buttonEndCrop_Click(object sender, EventArgs e)
        {
            int pictureBoxCentreX = pictureBoxEditImage.Width / 2;
            int pictureBoxCentreY = pictureBoxEditImage.Height / 2;

            int imageLeft = pictureBoxCentreX - (pictureBoxEditImage.Image.Width / 2);
            int imageRight = pictureBoxCentreX + (pictureBoxEditImage.Image.Width / 2) - 2;
            int imageTop = pictureBoxCentreY - (pictureBoxEditImage.Image.Height / 2);
            int imageBottom = pictureBoxCentreY + (pictureBoxEditImage.Image.Height / 2) - 2;

            if (rectangleWidth > 0 && rectangleHeight > 0 && cropX > 0 && cropY > 0)
            {
                Cursor = Cursors.Default;

                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterOne = cropX-imageLeft;
                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterTwo = cropY-imageTop;
                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterThree = rectangleWidth;
                // SET the ParameterOne to path:
                ((ICommand<int, int, int, int>)_commands["CropImage"]).ParameterFour = rectangleHeight;
                // SIGNAL to the CommandInvoker to fire the command:
                _executePointer(_commands["CropImage"]);

                //pictureBoxEditImage.DrawToBitmap(bmp2, pictureBoxEditImage.ClientRectangle);

                //pictureBoxEditImage.Image = (Image)crpImg;
                pictureBoxEditImage.SizeMode = PictureBoxSizeMode.CenterImage;


                cropX = 0;
                cropY = 0;
                rectangleWidth = 0;
                rectangleHeight = 0;

            }
            
        }

        int cropX, cropY, rectangleWidth, rectangleHeight;

        public Pen cropPen = new Pen(Color.White);

        private void pictureBoxEditImage_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                cropX = e.X;
                cropY = e.Y;
                
                //Console.WriteLine(cropX);

                //Console.WriteLine(cropY);



                //int pictureBoxCentreX = pictureBoxEditImage.Location.X + pictureBoxEditImage.Width  /  2;
                //int pictureBoxCentreY = pictureBoxEditImage.Location.Y + pictureBoxEditImage.Height / 2;

                int pictureBoxCentreX = pictureBoxEditImage.Width / 2;
                int pictureBoxCentreY =  pictureBoxEditImage.Height / 2;

                int imageLeft = pictureBoxCentreX - (pictureBoxEditImage.Image.Width / 2); 
                int imageRight = pictureBoxCentreX + (pictureBoxEditImage.Image.Width / 2) -2;
                int imageTop = pictureBoxCentreY - (pictureBoxEditImage.Image.Height  /  2);
                int imageBottom = pictureBoxCentreY + (pictureBoxEditImage.Image.Height / 2)-2;

                //if (cropX > imageRight)
                //{
                 //   cropX = imageRight;
                //}

                // PREVENTS crop on left boundary
                if (cropX < imageLeft)
                {
                    cropX = imageLeft;
                }

                //if (cropY > imageBottom)
                //{
                 //   cropY = imageBottom;
                //}

                if (cropY < imageTop)
                {
                    cropY = imageTop;
                }
            }
        }

        

        private void pictureBoxEditImage_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                int mouseLocationX = e.X;
                int mouseLocationY = e.Y;

                pictureBoxEditImage.Refresh();

                int pictureBoxCentreX = pictureBoxEditImage.Width / 2;
                int pictureBoxCentreY = pictureBoxEditImage.Height / 2;

                int imageLeft = pictureBoxCentreX - (pictureBoxEditImage.Image.Width / 2);
                int imageRight = pictureBoxCentreX + (pictureBoxEditImage.Image.Width / 2);
                int imageTop = pictureBoxCentreY - (pictureBoxEditImage.Image.Height / 2);
                int imageBottom = pictureBoxCentreY + (pictureBoxEditImage.Image.Height / 2);

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
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Default;
        }
    }
}
