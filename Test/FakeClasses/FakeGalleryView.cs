using System;
using System.Collections.Generic;
using System.Drawing;
using 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public class FakeGalleryView : ISubscriber
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
        public FakeGalleryView()
        {
            _imageList = new List<Image>();
            _commands = new Dictionary<string, ICommand>();
            
        }

        public void ImportButtonPressed()
        {
            // EXECUTE the Command object
            if(_commands.ContainsKey("Import"))
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
        public void Update(FakeImportImageEventArgs e)
        {
            _imageList = e.Images;

            RefreshThumbnails();
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
        #endregion
    }
}
