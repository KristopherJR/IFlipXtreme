//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

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
        #endregion

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
        #endregion

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

        //public void GalleryView_Load()
        //{
            
        //}

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
                        selectedBox.BackColor = Color.Green;

                        Console.WriteLine("you just clicked: " + selectedBox.Name);
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
        #endregion

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
                string path = fileDialog.FileName;

                if (_commands.ContainsKey("LoadImage"))
                {

                    ((ICommand<string>)_commands["LoadImage"]).ParameterOne = path;

                    _executePointer(_commands["LoadImage"]);
                    ResetSelection();
                }
            }          
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _toggleFormPointer();
        }

        #region  ㅤ
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
            // IF the image count = 8:
            if(((String)labelVersion.Tag).Length == 8)
            {
                for(int i = 0; i < 8; i++)
                {
                    // SET the path to the default images:
                    ((ICommand<string>)_commands["LoadImage"]).ParameterOne = path + i.ToString() + ".txt";
                    // FIRE the "LoadImage" Command to load the default Image collection:
                    _executePointer(_commands["LoadImage"]);
                }
            }
        }
        #endregion
    }
}
