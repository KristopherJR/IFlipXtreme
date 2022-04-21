//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// GalleryView Form:  Main gallery that allows users to input and select images to edit
    /// </summary>
    public partial class GalleryView : Form, IGalleryView
    {
        #region Fields

        // DECLARE a List to store the Images, call it "_thumbnaiList":
        private List<Image> _thumbnailList;

        // DECLARE an int, call it "_selectedImageIndex":
        private int _selectedImageIndex;

        // DECLARE a Dictionary to store all ICommand objects, call it "_commands":
        private Dictionary<string, ICommand> _commands;

        // DECLARE an Action that points to the Execute method, call it "_executePointer":
        private Action<ICommand> _executePointer;

        // DECLARE a List of PictureBox, holds all the thumbnail containers. call it "_thumbnailContainers":
        private List<PictureBox> _thumbnailContainers;

        // DECLARE an Action that points to the ToggleForms() method in View, call it "_toggleFormPointer":
        private Action _toggleFormPointer;

        #endregion Fields

        #region Properties

        // DECLARE a set property for _toggleFormPointer. Call it "ToggleFormPointer":
        public Action ToggleFormPointer
        {
            set { _toggleFormPointer = value; }
        }

        // DECLARE a get property for _thumbnailList. Call it "ThumbnailList":
        public List<Image> ThumbnailList
        {
            get { return _thumbnailList; }
        }

        // DECLARE a get-set property for _commands. Call it "Commands":
        public Dictionary<string, ICommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        // DECLARE a set property for _executePointer. Call it "ExecutePointer":
        public Action<ICommand> ExecutePointer
        {
            set { _executePointer = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Constructor for class GalleryView.
        /// </summary>
        public GalleryView()
        {
            // CALL "InitializeComponent" to initialise Form GUI.
            InitializeComponent();
            // INSTANTIATE "_thumbnailContainers" with all of the PictureBoxes:
            _thumbnailContainers = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            // INSTANTIATE "_thumbnailList":
            _thumbnailList = new List<Image>();
            // INSTANTIATE _"commands":
            _commands = new Dictionary<string, ICommand>();
            // INSTANTIATE "_selectedImageIndex", set it to -1:
            _selectedImageIndex = -1;
            // SET the position of the GUI to the center of the screen:
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }

        /// <summary>
        /// SelectImage method: Called everytime a Picturebox is clicked in the GUI. Handles the selection logic.
        /// </summary>
        /// <param name="sender">The PictureBox calling the method that was clicked on.</param>
        /// <param name="e">EventArgs.</param>
        private void SelectImage(object sender, MouseEventArgs e)
        {
            // INSTANTIATE a PictureBox and set it to the sender, call it "selectedBox":
            PictureBox selectedBox = sender as PictureBox;
            // IF there is no Image in the clicked PictureBox:
            if (selectedBox.Image != null)
            {
                // ITERATE through all PictureBoxes in "_thumbnailContainers":
                for (int i = 0; i < _thumbnailContainers.Count; i++)
                {
                    // SET the back colour of the PictureBox to Transparent:
                    _thumbnailContainers[i].BackColor = Color.Transparent;
                    // IF the current PictureBox has been clicked on:
                    if (_thumbnailContainers[i] == selectedBox)
                    {
                        // STORE the index of the selected PictureBox:
                        _selectedImageIndex = i;
                        // SET the backcolour to Green to show it has been selected:
                        selectedBox.BackColor = Color.YellowGreen;
                    }
                }
            }
        }

        /// <summary>
        /// ResetSelection: Resets the PictureBox that the user has selected.
        /// </summary>
        private void ResetSelection()
        {
            // ITERATE through all PictureBoxes in "_thumbnailContainers":
            for (int i = 0; i < _thumbnailContainers.Count; i++)
            {
                // SET the back colour of the PictureBox to Transparent:
                _thumbnailContainers[i].BackColor = Color.Transparent;
                // SET the "_selectedImageIndex" to -1:
                _selectedImageIndex = -1;
            }
        }

        /// <summary>
        /// RefreshThumbnails: Refreshes the Displayed thumbnail list with the newly updated Image collection.
        /// </summary>
        /// <param name="pThumbList"></param>
        private void RefreshThumbnails()
        {
            // ITERATE through all PictureBoxes in "_thumbnailContainers":
            for (int i = 0; i < _thumbnailList.Count; i++)
            {
                // UPDATE the Images in the boxes with the new ones loaded into the "_thumbnailList":
                _thumbnailContainers[i].Image = _thumbnailList[i];
            }
        }

        /// <summary>
        /// InjectThumbnails: Updates the Thumbnail image collection and refreshes them in the GUI.
        /// </summary>
        /// <param name="pThumbs">A List containing the new image thumbnail collection.</param>
        public void InjectThumbnails(List<Image> pThumbs)
        {
            // ASSIGN pThumns to "_thumbnailList":
            _thumbnailList = pThumbs;
            // REFRESH the thumbnails in the GUI:
            RefreshThumbnails();
        }

        /// <summary>
        /// ImportButton_Click: Called whenever the user clicks on the Import Image button.
        /// </summary>
        /// <param name="sender">The object firing the event.</param>
        /// <param name="e">EventArgs.</param>
        private void importButton_Click(object sender, EventArgs e)
        {
            // INSTANTIATE a new OpenFileDialog, call it "fileDialog":
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // SET the path to the selected Image:
                string path = fileDialog.FileName;

                // IF the command object "LoadImage" exists:
                if (_commands.ContainsKey("LoadImage"))
                {
                    // SET the ParameterOne to path:
                    ((ICommand<string>)_commands["LoadImage"]).ParameterOne = path;
                    // SIGNAL to the CommandInvoker to fire the command:
                    _executePointer(_commands["LoadImage"]);
                    // RESET the users selection:
                    ResetSelection();
                }

                // THROW a CommandDoesNotExistException if the command is not found in the dictionary
                else
                {
                    throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
                }
            }
        }

        /// <summary>
        /// buttonExit_Click: Closes the application when the user clicks the Exit button.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">EventArgs.</param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            // EXIT the application:
            Application.Exit();
        }

        /// <summary>
        /// buttonEdit_Click: Called when the user clicks the Edit button. Toggles form visibility.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">EventArgs.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!(_selectedImageIndex == -1))
            {
                // TOGGLE the forms visibility:
                _toggleFormPointer();
                // FIRE a Command passing in the "_selectedImageIndex":

                // IF the command object "LoadImage" exists:
                if (_commands.ContainsKey("OpenImage"))
                {
                    // SET the ParameterOne to path:
                    ((ICommand<int>)_commands["OpenImage"]).ParameterOne = _selectedImageIndex;

                    // TRY to fire the command
                    try
                    {
                        // SIGNAL to the CommandInvoker to fire the command:
                        _executePointer(_commands["OpenImage"]);
                    }

                    // CATCH the InvalidParamterException if thrown
                    catch (InvalidParameterException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    // RESET the users selection:
                    ResetSelection();
                }

                // THROW a CommandDoesNotExistException if the command is not found in the dictionary
                else
                {
                    throw new CommandDoesNotExistException("The requested command has not been added to the dictionary.");
                }
            }
            else
            {
                // CREATE A POP-UP SAYING THAT YOU HAVE TO SELECT AN IMAGE BEFORE CLICKING EDIT
                Console.WriteLine("WARNING: You must select an Image before you can edit!");
            }
        }
        #endregion Methods
        #region ㅤ

        /// <summary>
        /// Windows Forms Method:  Called when the LoadDefaultImage button is pressed
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        private void LoadDefaultImage_Click(object sender, EventArgs e)
        {
            // INSTANTIATE a string for the default image folder, call it "path":
            string path = "../../../Test/bin/Release/VersionControl/";
            // INCREMENT the version tag for indexing the image collection:
            labelVersion.Tag = labelVersion.Tag + "+";
            // IF the + count = 8:
            if (((String)labelVersion.Tag).Length >= 8)
            {
                // FOR LOOP: Repeats 8 times
                for (int i = 0; i < 8; i++)
                {
                    // SET the path to the default images:
                    ((ICommand<string>)_commands["LoadImage"]).ParameterOne = path + i.ToString() + ".txt";
                    // FIRE the "LoadImage" Command to load the default Image collection:
                    _executePointer(_commands["LoadImage"]);
                }
            }
        }

        #endregion ㅤ
    }
}