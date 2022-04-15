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
        GalleryView _gallery;

        ImageView _editor;

        Action<ICommand> _executePointer;

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

        public View()
        {
            _gallery = new GalleryView();

            _editor = new ImageView();            
        }

        public void StartApp()
        {
            Application.Run(_gallery);
        }

        public void Update(EventArgs e)
        {
            try
            {
                _gallery.InjectThumbnails((e as UpdateViewEventArgs).ImageList);

                _editor.InjectCurrentImage((e as UpdateViewEventArgs).Image);
            }
            catch (Exception ex)
            { }
        }
    }
}
