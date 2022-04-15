using System;
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
    public partial class GalleryView : Form, IGalleryView
    {
        #region Fields
        private List<Image> _imageList;
        private Dictionary<string, ICommand> _commands;

        private Action<ICommand> _executePointer;

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
            set { _executePointer = value; }
        }
        #endregion

        #region Methods
        public GalleryView()
        {
            InitializeComponent();

            _thumbnailContainers = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };

            _imageList = new List<Image>();

            _commands = new Dictionary<string, ICommand>();

        }


        /// <summary>
        /// Default Update method for an IUpdatable.
        /// </summary>
        /// <param name="e">Event information</param>
        //public void Update(EventArgs e)
        //{
        //    if (e is ImportImageEventArgs)
        //    {
        //        _imageList = (e as ImportImageEventArgs).Images;
                
        //    }
        //    else
        //    {
        //        throw new InvalidEventArgsTypeException("Gallery View Event Args must be of type ImportImageEventArgs.");
        //    }
        //}

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

        public void InjectThumbnails(List<Image> pThumbs)
        {
            _imageList = pThumbs;

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
                }
            }          
        }
    }
}
