//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public class FakeGalleryView : ISubscriber
    {
        #region Fields

        private List<Image> _imageList;
        private Dictionary<string, ICommand> _commands;

        private Action<ICommand> _execute;

        private List<PictureBox> _thumbnailContainers;

        #endregion Fields

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

        #endregion Properties

        #region Methods

        public FakeGalleryView()
        {
            _imageList = new List<Image>();
            _commands = new Dictionary<string, ICommand>();
            _thumbnailContainers = new List<PictureBox>();
        }

        public void ImportButtonPressed()
        {
            // EXECUTE the Command object
            if (_commands.ContainsKey("Import"))
            {
                ((ICommand<string>)_commands["Import"]).ParameterOne = "../../../assets/OrangeFish.png";

                _execute(_commands["Import"]);
            }
            //_execute(_importImage);
        }

        /// <summary>
        /// Default Update method for an IUpdatable.
        /// </summary>
        /// <param name="e">Event information</param>
        public void Update(EventArgs e)
        {
            if (e is FakeImportImageEventArgs)
            {
                _imageList = (e as FakeImportImageEventArgs).Images;
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
            for (int i = 0; i < _thumbnailContainers.Count; i++)
            {
                _thumbnailContainers[i].Image = _imageList[i];
            }
        }

        #endregion Methods
    }
}