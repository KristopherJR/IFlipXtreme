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

        // DECLARE an Action to hold the Image that is currently being edited.  Call it "_image".
        private Image _image;

        #endregion

        #region Properties

        // DECLARE a set property for "_image".  Call it "Image".
        public Image Image
        {
            set { _image = value; }
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

        // DECLARE a set/get property for "_commands".  Call it "Commands".
        public Dictionary<string, ICommand> Commands
        {
            set { _commands = value; }
            get { return _commands;  }
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

        /// <summary>
        /// Windows Forms Method:  Called when the form is loaded.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            _toggleFormPointer();
        }

        /// <summary>
        /// Windows Forms Method:  Called when the Save Button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            _toggleFormPointer();
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

        #endregion
    }
}
