using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class FakeGalleryView : ISubscriber
    {
        #region Fields
        private List<Image> _imageList;
        private Dictionary<string, ICommand> _commands;
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

                _commands["Import"].Execute();
            }
            //_execute(_importImage);
        }

        /// <summary>
        /// Default Update method for an IUpdatable.
        /// </summary>
        /// <param name="e">Event information</param>
        public void Update(EventArgs e)
        {
            
        }
        #endregion
    }
}
