﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace View
{
    public partial class GalleryView : Form, ISubscriber, IGalleryView
    {
        #region Fields
        private List<Image> _imageList;
        private Dictionary<string, ICommand> _commands;

        private Action<ICommand> _execute;

        List<PictureBox> _thumbnailContainers;

        #endregion

        #region Properties
        public List<Image> ImageList
        {
            get { return _imageList; }
        }

        public Dictionary<string, ICommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        public Action<ICommand> ExecutePointer
        {
            set { _execute = value; }
        }
        #endregion

        #region Methods
        public GalleryView()
        {
            InitializeComponent();

            _thumbnailContainers = new List<PictureBox>(8);

            _thumbnailContainers.Add(pictureBox1);
            _thumbnailContainers.Add(pictureBox2);
            _thumbnailContainers.Add(pictureBox3);
            _thumbnailContainers.Add(pictureBox4);
            _thumbnailContainers.Add(pictureBox5);
            _thumbnailContainers.Add(pictureBox6);
            _thumbnailContainers.Add(pictureBox7);
            _thumbnailContainers.Add(pictureBox8);

            Console.WriteLine(_thumbnailContainers.Count);

            _imageList = new List<Image>();
            _commands = new Dictionary<string, ICommand>();

        }

        public void ImportButtonPressed(string path)
        {
            // EXECUTE the Command object
            if (_commands.ContainsKey("Import"))
            {

                ((ICommand<string>)_commands["Import"]).ParameterOne = path;

                _execute(_commands["Import"]);
            }
        }

        /// <summary>
        /// Default Update method for an IUpdatable.
        /// </summary>
        /// <param name="e">Event information</param>
        public void Update(EventArgs e)
        {
            if (e is ImportImageEventArgs)
            {
                _imageList = (e as ImportImageEventArgs).Images;
                RefreshThumbnails();
            }
            else
            {
                throw new InvalidEventArgsTypeException("Gallery View Event Args must be of type ImportImageEventArgs.");
            }
        }

        /// <summary>
        /// Refresh the Displayed thumbnail list
        /// </summary>
        /// <param name="pThumbList"></param>
        private void RefreshThumbnails()
        {
            for (int i = 0; i < _imageList.Count; i++)
            {
                _thumbnailContainers[i].Image = _imageList[i];
            }
        }
        #endregion

        private void GalleryView_Load(object sender, EventArgs e)
        {

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;
                ImportButtonPressed(path);
            }
        }
    }
}
