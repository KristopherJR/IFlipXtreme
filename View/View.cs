//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public class View : ISubscriber
    {
        #region Fields
        GalleryView _gallery;

        ImageView _editor;

        Action<ICommand> _executePointer;
        #endregion

        #region Properties

        public Action<ICommand> ExecutePointer
        {
            set 
            {
                _executePointer = value;
                _gallery.ExecutePointer = value;
                _editor.ExecutePointer = value;
            }
        }
        public GalleryView GalleryView
        {
            get { return _gallery; }
        }

        public ImageView ImageView
        {
            get { return _editor; }
        }
        #endregion

        #region Method

        public View()
        {
            _gallery = new GalleryView();

            _editor = new ImageView();

            _gallery.ToggleFormPointer = ToggleForms;

            _editor.ToggleFormPointer = ToggleForms;
        }

        public void StartApp()
        {
            Application.Run(_gallery);
        }

        public void ToggleForms()
        {
            _gallery.Visible = !_gallery.Visible;

            _editor.Visible = !_editor.Visible;
        }    
       
        public void Update(EventArgs e)
        {
            try
            {
                _gallery.InjectThumbnails((e as UpdateViewEventArgs).ImageList);

                _editor.Image = ((e as UpdateViewEventArgs).Image);
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
