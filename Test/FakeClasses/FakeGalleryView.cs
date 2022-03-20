using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.FakeClasses;

namespace Test
{
    public class FakeGalleryView
    {
        #region Fields
        private List<Image> _imageList;
        private Dictionary<string, FakeICommand> _commands;
        #endregion

        #region Properties
        public List<Image> ImageList
        {
            get { return _imageList; }
        }

        public Dictionary<string, FakeICommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }
        #endregion

        #region Methods
        public FakeGalleryView()
        {
            _imageList = new List<Image>();
            
        }

        public void ImportButtonPressed()
        {
            // EXECUTE the Command object
            if(_commands.ContainsKey("Import"))
            {
                List<Type> parameters = new List<Type>();
                parameters.Add((Type)(object) "../../../assets/OrangeFish.png");
                _commands["Import"].InjectParameters(parameters);

                _commands["Import"].Execute();
            }
            //_execute(_importImage);
        }
        #endregion
    }
}
