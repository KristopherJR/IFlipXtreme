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
                // 
                for (int i = 0; i < _thumbnailContainers.Count; i++)
                {
                    _thumbnailContainers[i].BackColor = Color.Transparent;

                    if (_thumbnailContainers[i] == selectedBox)
                    {
                        _selectedImageIndex = i;
                        selectedBox.BackColor = Color.Green;
                        Console.WriteLine("you just clicked: " + selectedBox.Name);
                    }
                }
            }                
        }

        private void ResetSelection()
        {
            for (int i = 0; i < _thumbnailContainers.Count; i++)
            {
                _thumbnailContainers[i].BackColor = Color.Transparent;
                _selectedImageIndex = -1;
            }
        }

        /// <summary>
        /// Refresh the Displayed thumbnail list
        /// </summary>
        /// <param name="pThumbList"></param>
        private void RefreshThumbnails()
        {
            for (int i = 0; i < _thumbnailList.Count; i++)
            {
                _thumbnailContainers[i].Image = _thumbnailList[i];
            }
        }
        #endregion

        private void GalleryView_Load(object sender, EventArgs e)
        {

        }

        public void InjectThumbnails(List<Image> pThumbs)
        {
            _thumbnailList = pThumbs;

            RefreshThumbnails();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
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

        

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

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
            string path = "../../../Test/bin/Release/VersionControl/";
            
            labelVersion.Tag = labelVersion.Tag + "+";
            
            if(((String)labelVersion.Tag).Length == 8)
            {
                for(int i = 0; i < 8; i++)
                {
                    ((ICommand<string>)_commands["LoadImage"]).ParameterOne = path + i.ToString() + ".txt";

                    _executePointer(_commands["LoadImage"]);
    
                }
            }
        }
        #endregion
    }
}
